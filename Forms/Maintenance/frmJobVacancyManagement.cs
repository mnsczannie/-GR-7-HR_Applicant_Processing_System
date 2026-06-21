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

        public class RequirementItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }

        private void frmJobVacancyManagement_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadPositions();
            LoadEmploymentTypes();
            LoadRequirements();
            LoadVacancies();
        }

        private void LoadDepartments()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT department_id, name FROM departments ORDER BY name", conn);
                    var reader = cmd.ExecuteReader();
                    cmbDepartment.Items.Clear();
                    cmbDepartment.Items.Add(new RequirementItem { Text = "-- Select Department --", Value = 0 });
                    while (reader.Read())
                        cmbDepartment.Items.Add(new RequirementItem { Text = reader["name"].ToString(), Value = (int)reader["department_id"] });
                    cmbDepartment.DisplayMember = "Text";
                    cmbDepartment.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading departments: " + ex.Message); }
        }

        private void LoadPositions(int departmentId = 0)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = departmentId > 0
                        ? "SELECT position_id, title FROM positions WHERE department_id = @d ORDER BY title"
                        : "SELECT position_id, title FROM positions ORDER BY title";
                    var cmd = new SqlCommand(sql, conn);
                    if (departmentId > 0) cmd.Parameters.AddWithValue("@d", departmentId);
                    var reader = cmd.ExecuteReader();
                    cmbPosition.Items.Clear();
                    cmbPosition.Items.Add(new RequirementItem { Text = "-- Select Position --", Value = 0 });
                    while (reader.Read())
                        cmbPosition.Items.Add(new RequirementItem { Text = reader["title"].ToString(), Value = (int)reader["position_id"] });
                    cmbPosition.DisplayMember = "Text";
                    cmbPosition.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading positions: " + ex.Message); }
        }

        private void LoadEmploymentTypes()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT type_id, label FROM employment_types ORDER BY label", conn);
                    var reader = cmd.ExecuteReader();
                    cmbEmpType.Items.Clear();
                    cmbEmpType.Items.Add(new RequirementItem { Text = "-- Select Type --", Value = 0 });
                    while (reader.Read())
                        cmbEmpType.Items.Add(new RequirementItem { Text = reader["label"].ToString(), Value = (int)reader["type_id"] });
                    cmbEmpType.DisplayMember = "Text";
                    cmbEmpType.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading employment types: " + ex.Message); }
        }

        private void LoadRequirements()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT req_type_id, label FROM requirement_types ORDER BY label", conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        clbRequirements.Items.Clear();
                        while (dr.Read())
                            clbRequirements.Items.Add(new RequirementItem
                            {
                                Text = dr["label"].ToString(),
                                Value = Convert.ToInt32(dr["req_type_id"])
                            });
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading requirements: " + ex.Message); }
        }

        private void LoadVacancies(string filter = "")
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT v.vacancy_id, p.title AS Position,
                        d.name AS Department, et.label AS Type,
                        v.slots AS Slots, v.status AS Status
                        FROM job_vacancies v
                        INNER JOIN positions p ON v.position_id = p.position_id
                        INNER JOIN departments d ON v.department_id = d.department_id
                        INNER JOIN employment_types et ON v.employment_type_id = et.type_id";
                    if (!string.IsNullOrEmpty(filter))
                        sql += " WHERE p.title LIKE @f OR d.name LIKE @f";
                    var adapter = new SqlDataAdapter(sql, conn);
                    if (!string.IsNullOrEmpty(filter))
                        adapter.SelectCommand.Parameters.AddWithValue("@f", "%" + filter + "%");
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvVacancies.DataSource = table;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading vacancies: " + ex.Message); }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVacancies();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex <= 0) { LoadPositions(); return; }
            int deptId = ((RequirementItem)cmbDepartment.SelectedItem).Value;
            LoadPositions(deptId);
        }

        private void dgvVacancies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVacancies.Rows[e.RowIndex];
                selectedVacancyId = Convert.ToInt32(row.Cells["vacancy_id"].Value);
                numSlots.Value = Convert.ToDecimal(row.Cells["Slots"].Value);
                LoadSelectedVacancyRequirements(selectedVacancyId);
            }
        }

        private void LoadSelectedVacancyRequirements(int vacancyId)
        {
            for (int i = 0; i < clbRequirements.Items.Count; i++)
                clbRequirements.SetItemChecked(i, false);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT req_type_id FROM job_requirements WHERE job_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", vacancyId);
                        var checkedIds = new List<int>();
                        using (var dr = cmd.ExecuteReader())
                            while (dr.Read()) checkedIds.Add(dr.GetInt32(0));

                        for (int i = 0; i < clbRequirements.Items.Count; i++)
                        {
                            var item = clbRequirements.Items[i] as RequirementItem;
                            if (item != null && checkedIds.Contains(item.Value))
                                clbRequirements.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading requirements: " + ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex <= 0 ||
                cmbPosition.SelectedIndex <= 0 ||
                cmbEmpType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select Department, Position, and Employment Type.");
                return;
            }

            int deptId = ((RequirementItem)cmbDepartment.SelectedItem).Value;
            int posId = ((RequirementItem)cmbPosition.SelectedItem).Value;
            int empId = ((RequirementItem)cmbEmpType.SelectedItem).Value;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int vacancyId = selectedVacancyId;

                            if (selectedVacancyId == -1)
                            {
                                string insertSql = @"INSERT INTO job_vacancies 
                                    (position_id, department_id, employment_type_id, slots, status, posted_by, posted_at)
                                    OUTPUT INSERTED.vacancy_id
                                    VALUES (@pos, @dept, @emp, @slots, 'open', @postedBy, GETDATE())";
                                using (var cmd = new SqlCommand(insertSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@pos", posId);
                                    cmd.Parameters.AddWithValue("@dept", deptId);
                                    cmd.Parameters.AddWithValue("@emp", empId);
                                    cmd.Parameters.AddWithValue("@slots", (int)numSlots.Value);
                                    cmd.Parameters.AddWithValue("@postedBy", SessionManager.CurrentUser?.UserId ?? 1);
                                    vacancyId = Convert.ToInt32(cmd.ExecuteScalar());
                                }
                            }
                            else
                            {
                                string updateSql = @"UPDATE job_vacancies 
                                    SET position_id = @pos, department_id = @dept, employment_type_id = @emp, slots = @slots
                                    WHERE vacancy_id = @id";
                                using (var cmd = new SqlCommand(updateSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@pos", posId);
                                    cmd.Parameters.AddWithValue("@dept", deptId);
                                    cmd.Parameters.AddWithValue("@emp", empId);
                                    cmd.Parameters.AddWithValue("@slots", (int)numSlots.Value);
                                    cmd.Parameters.AddWithValue("@id", vacancyId);
                                    cmd.ExecuteNonQuery();
                                }

                                using (var cmd = new SqlCommand(
                                    "DELETE FROM job_requirements WHERE job_id = @id", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", vacancyId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            foreach (var item in clbRequirements.CheckedItems)
                            {
                                var req = item as RequirementItem;
                                if (req != null)
                                {
                                    using (var cmd = new SqlCommand(
                                        "INSERT INTO job_requirements (job_id, req_type_id) VALUES (@job, @req)",
                                        conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@job", vacancyId);
                                        cmd.Parameters.AddWithValue("@req", req.Value);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Vacancy saved!");
                            ClearForm();
                            LoadVacancies();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error saving vacancy: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnCloseVacancy_Click(object sender, EventArgs e)
        {
            if (dgvVacancies.SelectedRows.Count == 0) { MessageBox.Show("Select a vacancy first."); return; }
            int id = Convert.ToInt32(dgvVacancies.SelectedRows[0].Cells["vacancy_id"].Value);
            if (MessageBox.Show("Close this vacancy?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("UPDATE job_vacancies SET status = 'closed' WHERE vacancy_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Vacancy closed.");
                ClearForm();
                LoadVacancies();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnReopenVacancy_Click(object sender, EventArgs e)
        {
            if (dgvVacancies.SelectedRows.Count == 0) { MessageBox.Show("Select a vacancy first."); return; }
            int id = Convert.ToInt32(dgvVacancies.SelectedRows[0].Cells["vacancy_id"].Value);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("UPDATE job_vacancies SET status = 'open' WHERE vacancy_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Vacancy reopened!");
                ClearForm();
                LoadVacancies();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            selectedVacancyId = -1;
            cmbDepartment.SelectedIndex = 0;
            cmbPosition.SelectedIndex = 0;
            cmbEmpType.SelectedIndex = 0;
            txtDescription.Clear();
            txtQualifications.Clear();
            numSlots.Value = 0;
            for (int i = 0; i < clbRequirements.Items.Count; i++)
                clbRequirements.SetItemChecked(i, false);
            dgvVacancies.ClearSelection();
        }
    }
}