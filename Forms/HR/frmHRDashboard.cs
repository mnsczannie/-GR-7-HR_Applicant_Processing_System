using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRDashboard : Form
    {
        public frmHRDashboard()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────
        private void frmHRDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser.FullName}  ({SessionManager.CurrentUser.Role})";
            LoadSummaryCards();
            ApplyRoleVisibility();
        }

        private void LoadSummaryCards()
        {
            string query = @"
                SELECT
                    COUNT(*)                                              AS total,
                    SUM(CASE WHEN status = 'submitted'           THEN 1 ELSE 0 END) AS pending,
                    SUM(CASE WHEN status = 'interview_scheduled' THEN 1 ELSE 0 END) AS interviews,
                    SUM(CASE WHEN status = 'accepted'            THEN 1 ELSE 0 END) AS accepted,
                    SUM(CASE WHEN status = 'rejected'            THEN 1 ELSE 0 END) AS rejected
                FROM applications";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblTotal.Text = reader["total"].ToString();
                        lblPending.Text = reader["pending"].ToString();
                        lblInterviews.Text = reader["interviews"].ToString();
                        lblAccepted.Text = reader["accepted"].ToString();
                        lblRejected.Text = reader["rejected"].ToString();
                    }
                }
            }
        }

        private void ApplyRoleVisibility()
        {
            string role = SessionManager.CurrentUser?.Role ?? string.Empty;
            btnMaintenance.Visible = (role == "admin");
        }

        // ─────────────────────────────────────────────
        // BUTTON HANDLERS
        // ─────────────────────────────────────────────
        private void btnApplicantReview_Click(object sender, EventArgs e)
        {
            var form = new frmApplicantReview();
            form.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var form = new frmReports();
            form.Show();
        }

        private void btnVacancyManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vacancy Management — handled by Micaller's module.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Maintenance — handled by Micaller's module.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to logout?",
                                                   "Logout", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                SessionManager.Clear();
                var login = new frmHRLogin();
                login.Show();
                this.Close();
            }
        }
    }
}
