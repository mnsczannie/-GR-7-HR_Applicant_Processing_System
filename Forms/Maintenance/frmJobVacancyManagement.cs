using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmJobVacancyManagement : Form
    {
        private int selectedVacancyId = -1;

        public frmJobVacancyManagement()
        {
            InitializeComponent();
        }

        private void frmJobVacancyManagement_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0;
            PopulateDropdowns();
            PopulateRequirementsList();
            LoadVacancies();
        }

        private void PopulateDropdowns()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name FROM positions", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbPosition.DataSource = dt;
                        cmbPosition.DisplayMember = "name";
                        cmbPosition.ValueMember = "id";
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name FROM departments", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbDepartment.DataSource = dt;
                        cmbDepartment.DisplayMember = "name";
                        cmbDepartment.ValueMember = "id";
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT id, name FROM employment_types", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbEmpType.DataSource = dt;
                        cmbEmpType.DisplayMember = "name";
                        cmbEmpType.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error seeding lookup dropdown items: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateRequirementsList()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT id, name FROM requirement_types";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        clbRequirements.DataSource = dt;
                        clbRequirements.DisplayMember = "name";
                        clbRequirements.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading systemic requirements: {ex.Message}", "Component Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVacancies()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT 
                            jv.id AS [Vacancy ID],
                            p.name AS [Position],
                            d.name AS [Department],
                            et.name AS [Employment Type],
                            jv.description AS [Description],
                            jv.qualifications AS [Qualifications],
                            jv.slots AS [Slots Open],
                            jv.status AS [Status],
                            jv.position_id,
                            jv.department_id,
                            jv.employment_type_id
                        FROM job_vacancies jv
                        INNER JOIN positions p ON jv.position_id = p.id
                        INNER JOIN departments d ON jv.department_id = d.id
                        INNER JOIN employment_types et ON jv.employment_type_id = et.id";

                    string filter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
                    if (filter == "Open") query += " WHERE jv.status = 'open'";
                    else if (filter == "Closed") query += " WHERE jv.status = 'closed'";

                    query += " ORDER BY jv.id DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvVacancies.DataSource = dt;

                        if (dgvVacancies.Columns.Contains("position_id")) dgvVacancies.Columns["position_id"].Visible = false;
                        if (dgvVacancies.Columns.Contains("department_id")) dgvVacancies.Columns["department_id"].Visible = false;
                        if (dgvVacancies.Columns.Contains("employment_type_id")) dgvVacancies.Columns["employment_type_id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading structural job records data map: {ex.Message}", "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVacancies();
        }

        private void dgvVacancies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVacancies.Rows[e.RowIndex];
                selectedVacancyId = Convert.ToInt32(row.Cells["Vacancy ID"].Value);

                cmbPosition.SelectedValue = row.Cells["position_id"].Value;
                cmbDepartment.SelectedValue = row.Cells["department_id"].Value;
                cmbEmpType.SelectedValue = row.Cells["employment_type_id"].Value;
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
                txtQualifications.Text = row.Cells["Qualifications"].Value?.ToString();
                numSlots.Value = Convert.ToDecimal(row.Cells["Slots Open"].Value);

                LoadSelectedVacancyRequirements(selectedVacancyId);
            }
        }

        private void LoadSelectedVacancyRequirements(int vacancyId)
        {
            for (int i = 0; i < clbRequirements.Items.Count; i++)
            {
                clbRequirements.SetItemChecked(i, false);
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT requirement_type_id FROM vacancy_requirements WHERE vacancy_id = @VacancyId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                        conn.Open();

                        List<int> checkedIds = new List<int>();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                checkedIds.Add(reader.GetInt32(0));
                            }
                        }

                        for (int i = 0; i < clbRequirements.Items.Count; i++)
                        {
                            DataRowView drv = clbRequirements.Items[i] as DataRowView;
                            if (drv != null)
                            {
                                int currentId = Convert.ToInt32(drv["id"]);
                                if (checkedIds.Contains(currentId))
                                {
                                    clbRequirements.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resolving requirement tracks mappings: {ex.Message}", "Relational Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPosition.SelectedValue == null || cmbDepartment.SelectedValue == null || cmbEmpType.SelectedValue == null)
            {
                MessageBox.Show("Please ensure structural setup reference items are valid entities fields.", "Validation Flag", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int vacancyId = selectedVacancyId;

                    if (selectedVacancyId == -1)
                    {
                        string insertQuery = @"
                            INSERT INTO job_vacancies (position_id, department_id, employment_type_id, description, qualifications, slots, status)
                            VALUES (@PositionId, @DepartmentId, @EmpTypeId, @Desc, @Quals, @Slots, 'open');
                            SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PositionId", cmbPosition.SelectedValue);
                            cmd.Parameters.AddWithValue("@DepartmentId", cmbDepartment.SelectedValue);
                            cmd.Parameters.AddWithValue("@EmpTypeId", cmbEmpType.SelectedValue);
                            cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@Quals", txtQualifications.Text.Trim());
                            cmd.Parameters.AddWithValue("@Slots", (int)numSlots.Value);

                            vacancyId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    else
                    {

                        string updateQuery = @"
                            UPDATE job_vacancies 
                            SET position_id = @PositionId, department_id = @DepartmentId, employment_type_id = @EmpTypeId, 
                                description = @Desc, qualifications = @Quals, slots = @Slots
                            WHERE id = @VacancyId";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PositionId", cmbPosition.SelectedValue);
                            cmd.Parameters.AddWithValue("@DepartmentId", cmbDepartment.SelectedValue);
                            cmd.Parameters.AddWithValue("@EmpTypeId", cmbEmpType.SelectedValue);
                            cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@Quals", txtQualifications.Text.Trim());
                            cmd.Parameters.AddWithValue("@Slots", (int)numSlots.Value);
                            cmd.Parameters.AddWithValue("@VacancyId", vacancyId);

                            cmd.ExecuteNonQuery();
                        }

                        string deleteOldReqs = "DELETE FROM vacancy_requirements WHERE vacancy_id = @VacancyId";
                        using (SqlCommand cmdDelete = new SqlCommand(deleteOldReqs, conn, transaction))
                        {
                            cmdDelete.Parameters.AddWithValue("@VacancyId", vacancyId);
                            cmdDelete.ExecuteNonQuery();
                        }
                    }

                    string insertReqQuery = "INSERT INTO vacancy_requirements (vacancy_id, requirement_type_id) VALUES (@VacancyId, @ReqTypeId)";
                    foreach (var item in clbRequirements.CheckedItems)
                    {
                        DataRowView drv = item as DataRowView;
                        if (drv != null)
                        {
                            using (SqlCommand cmdReq = new SqlCommand(insertReqQuery, conn, transaction))
                            {
                                cmdReq.Parameters.AddWithValue("@VacancyId", vacancyId);
                                cmdReq.Parameters.AddWithValue("@ReqTypeId", Convert.ToInt32(drv["id"]));
                                cmdReq.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Job Opening configuration saved and linked properly.", "Processing Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadVacancies();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Transaction aborted tracking processing pipelines errors: {ex.Message}", "Database Rejection Block", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCloseVacancy_Click(object sender, EventArgs e)
        {
            UpdateVacancyStatus("closed", "Vacancy marked as Closed successfully.");
        }

        private void btnReopenVacancy_Click(object sender, EventArgs e)
        {
            UpdateVacancyStatus("open", "Vacancy successfully initialized back to Open state tracking pipelines.");
        }

        private void UpdateVacancyStatus(string newStatus, string completionMessage)
        {
            if (selectedVacancyId == -1)
            {
                MessageBox.Show("Please choose an active opening from the structural record tracks grid first.", "Action Context Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE job_vacancies SET status = @Status WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", newStatus);
                        cmd.Parameters.AddWithValue("@Id", selectedVacancyId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(completionMessage, "Status Synchronization Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadVacancies();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed manipulating status bounds constraints flags: {ex.Message}", "Processing Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedVacancyId = -1;
            if (cmbPosition.Items.Count > 0) cmbPosition.SelectedIndex = 0;
            if (cmbDepartment.Items.Count > 0) cmbDepartment.SelectedIndex = 0;
            if (cmbEmpType.Items.Count > 0) cmbEmpType.SelectedIndex = 0;

            txtDescription.Clear();
            txtQualifications.Clear();
            numSlots.Value = 0;

            for (int i = 0; i < clbRequirements.Items.Count; i++)
            {
                clbRequirements.SetItemChecked(i, false);
            }
        }
    }
}