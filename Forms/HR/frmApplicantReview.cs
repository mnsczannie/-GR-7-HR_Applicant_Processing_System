using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmApplicantReview : Form
    {
        public frmApplicantReview()
        {
            InitializeComponent();
        }

        private void frmApplicantReview_Load(object sender, EventArgs e)
        {
            LoadDepartmentFilter();
            LoadApplications();
        }

        private void LoadDepartmentFilter()
        {
            string query = "SELECT DISTINCT department FROM job_vacancies WHERE department IS NOT NULL ORDER BY department";

            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("All Departments");

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        cboDepartment.Items.Add(reader["department"].ToString());
                }
            }

            cboDepartment.SelectedIndex = 0;
        }

        private void LoadApplications()
        {
            string search = txtSearch.Text.Trim();
            string status = cboStatus.SelectedItem?.ToString() ?? "submitted";
            string department = cboDepartment.SelectedItem?.ToString() ?? "All Departments";

            string query = @"
                SELECT ap.application_id,
                       a.first_name + ' ' + a.last_name  AS applicant_name,
                       jv.title                          AS position,
                       jv.department,
                       ap.status,
                       CONVERT(varchar, ap.submitted_at, 101) AS date_submitted
                FROM   applications ap
                JOIN   applicants    a  ON ap.applicant_id    = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id  = jv.job_vacancy_id
                WHERE  ap.status = @Status
                  AND  (@Search = '' OR a.first_name + ' ' + a.last_name LIKE '%' + @Search + '%'
                                    OR jv.title LIKE '%' + @Search + '%')
                  AND  (@Department = 'All Departments' OR jv.department = @Department)
                ORDER BY ap.submitted_at DESC";

            var dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Search", search);
                cmd.Parameters.AddWithValue("@Department", department);
                conn.Open();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }

            dgvApplications.DataSource = dt;

            if (dgvApplications.Columns["application_id"] != null)
                dgvApplications.Columns["application_id"].Visible = false;

            SetColumnHeader("applicant_name", "Applicant");
            SetColumnHeader("position", "Position");
            SetColumnHeader("department", "Department");
            SetColumnHeader("status", "Status");
            SetColumnHeader("date_submitted", "Date Submitted");
        }

        private void SetColumnHeader(string colName, string header)
        {
            if (dgvApplications.Columns[colName] != null)
                dgvApplications.Columns[colName].HeaderText = header;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadApplications();
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) => LoadApplications();
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e) => LoadApplications();

        private int? GetSelectedApplicationId()
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an application first.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["application_id"].Value);
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationId();
            if (id == null) return;

            string query = @"
                SELECT a.first_name, a.last_name, a.email, a.phone,
                       jv.title AS position, ap.status, ap.submitted_at
                FROM   applications ap
                JOIN   applicants    a  ON ap.applicant_id   = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
                WHERE  ap.application_id = @AppId";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AppId", id.Value);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string info = $"Name:      {reader["first_name"]} {reader["last_name"]}\n" +
                                      $"Email:     {reader["email"]}\n" +
                                      $"Phone:     {reader["phone"]}\n" +
                                      $"Position:  {reader["position"]}\n" +
                                      $"Status:    {reader["status"]}\n" +
                                      $"Submitted: {reader["submitted_at"]}";
                        MessageBox.Show(info, "Applicant Profile",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnViewDocuments_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationId();
            if (id == null) return;

            string query = @"
                SELECT rt.requirement_name,
                       CASE WHEN ad.document_id IS NOT NULL THEN 'Submitted' ELSE 'Missing' END AS doc_status
                FROM   requirement_types rt
                LEFT JOIN applicant_documents ad
                       ON rt.requirement_type_id = ad.requirement_type_id
                      AND ad.application_id      = @AppId";

            var dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AppId", id.Value);
                conn.Open();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }

            var viewer = new Form
            {
                Text = "Submitted Documents",
                Width = 400,
                Height = 300,
                StartPosition = FormStartPosition.CenterParent
            };
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            grid.DataSource = dt;
            viewer.Controls.Add(grid);
            viewer.ShowDialog(this);
        }

        private void btnLockForReview_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationId();
            if (id == null) return;

            DialogResult confirm = MessageBox.Show("Lock this application for review?",
                                                   "Confirm", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        string updateSql = @"
                            UPDATE applications
                            SET    status     = 'under_review',
                                   updated_at = GETDATE()
                            WHERE  application_id = @AppId
                              AND  status = 'submitted'";

                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AppId", id.Value);
                            int rows = cmd.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                MessageBox.Show("Application is no longer in 'submitted' status.",
                                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                tx.Rollback();
                                return;
                            }
                        }

                        SystemHelper.StatusHistoryLogger.Log(
                            conn, tx, id.Value, "under_review",
                            SessionManager.CurrentUser.UserId);

                        tx.Commit();
                        MessageBox.Show("Application locked for review.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadApplications();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error locking application:\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnOpenScreening_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationId();
            if (id == null) return;

            string statusCheck = "SELECT status FROM applications WHERE application_id = @AppId";
            string currentStatus = "";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(statusCheck, conn))
            {
                cmd.Parameters.AddWithValue("@AppId", id.Value);
                conn.Open();
                var result = cmd.ExecuteScalar();
                currentStatus = result?.ToString() ?? "";
            }

            if (currentStatus != "under_review")
            {
                MessageBox.Show("Please lock the application for review first before opening screening.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var screeningForm = new frmScreening(id.Value);
            screeningForm.Show();
        }
    }
}
