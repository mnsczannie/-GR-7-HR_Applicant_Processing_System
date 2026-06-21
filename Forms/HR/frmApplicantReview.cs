using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

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
            LoadDepartments();
            LoadData();
        }

        private void LoadDepartments()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT name FROM departments ORDER BY name", conn);
                    var reader = cmd.ExecuteReader();
                    cboDepartment.Items.Clear();
                    cboDepartment.Items.Add("All Departments");
                    while (reader.Read())
                        cboDepartment.Items.Add(reader["name"].ToString());
                    cboDepartment.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading departments: " + ex.Message); }
        }

        private void LoadData()
        {
            string q = txtSearch.Text.Trim();
            string status = cboStatus.SelectedItem?.ToString() ?? "submitted";
            string dept = cboDepartment.SelectedItem?.ToString() ?? "All Departments";

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT a.application_id AS [AppID],
                        ap.applicant_id AS [ApplicantID],
                        ap.full_name AS [Applicant], ap.email AS [Email],
                        p.title AS [Position], d.name AS [Department],
                        a.status AS [Status], a.submitted_at AS [Submitted]
                        FROM applications a
                        INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                        INNER JOIN job_vacancies v ON a.vacancy_id = v.vacancy_id
                        INNER JOIN positions p ON v.position_id = p.position_id
                        INNER JOIN departments d ON v.department_id = d.department_id
                        WHERE a.status = @status";
                    if (!string.IsNullOrEmpty(q))
                        sql += " AND (ap.full_name LIKE @q OR p.title LIKE @q)";
                    if (dept != "All Departments")
                        sql += " AND d.name = @dept";
                    sql += " ORDER BY a.submitted_at DESC";

                    var ada = new SqlDataAdapter(sql, conn);
                    ada.SelectCommand.Parameters.AddWithValue("@status", status);
                    if (!string.IsNullOrEmpty(q))
                        ada.SelectCommand.Parameters.AddWithValue("@q", "%" + q + "%");
                    if (dept != "All Departments")
                        ada.SelectCommand.Parameters.AddWithValue("@dept", dept);

                    var dt = new DataTable();
                    ada.Fill(dt);
                    dgvApplications.DataSource = dt;
                    if (dgvApplications.Columns["AppID"] != null)
                        dgvApplications.Columns["AppID"].Visible = false;
                    if (dgvApplications.Columns["ApplicantID"] != null)
                        dgvApplications.Columns["ApplicantID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private int AppId()
        {
            if (dgvApplications.SelectedRows.Count == 0) return -1;
            return Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["AppID"].Value);
        }

        private int AplId()
        {
            if (dgvApplications.SelectedRows.Count == 0) return -1;
            return Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["ApplicantID"].Value);
        }

        private string AplEmail()
        {
            if (dgvApplications.SelectedRows.Count == 0) return null;
            return dgvApplications.SelectedRows[0].Cells["Email"].Value?.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadData();
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) => LoadData();
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e) => LoadData();

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            string email = AplEmail();
            if (email == null) { MessageBox.Show("Select a row first."); return; }
            new frmHRApplicantProfile(email).ShowDialog();
        }

        private void btnViewDocuments_Click(object sender, EventArgs e)
        {
            int id = AplId();
            if (id == -1) { MessageBox.Show("Select a row first."); return; }
            new frmHRViewDocuments(id).ShowDialog();
        }

        private void btnLockForReview_Click(object sender, EventArgs e)
        {
            int id = AppId();
            if (id == -1) { MessageBox.Show("Select a row first."); return; }
            try
            {
                StatusHistoryLogger.LogStatusChange(id, "submitted", "under_review",
                    SessionManager.CurrentUser.UserId, "Locked for review.");
                MessageBox.Show("Application locked for review.");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnOpenScreening_Click(object sender, EventArgs e)
        {
            int appId = AppId();
            if (appId == -1) { MessageBox.Show("Select an application first."); return; }
            new frmScreening(appId).Show();
            this.Hide();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            int id = AppId();
            if (id == -1) { MessageBox.Show("Select a row first."); return; }
            if (MessageBox.Show("Mark this application as Withdrawn?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                StatusHistoryLogger.LogStatusChange(id, "under_review", "withdrawn",
                    SessionManager.CurrentUser.UserId, "Withdrawn by HR.");
                MessageBox.Show("Application marked as Withdrawn.");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}