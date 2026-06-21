using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRDashboard : Form
    {
        public frmHRDashboard()
        {
            InitializeComponent();
        }

        private void frmHRDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser.FullName} ({SessionManager.CurrentUser.Role})";
            LoadSummaryCards();
            ApplyRoleVisibility();
        }

        private void LoadSummaryCards()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM applicants", conn))
                        lblTotal.Text = cmd.ExecuteScalar().ToString();

                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM applications WHERE status IN ('submitted','under_review')", conn))
                        lblPending.Text = cmd.ExecuteScalar().ToString();

                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM interview_schedules WHERE status = 'scheduled'", conn))
                        lblInterviews.Text = cmd.ExecuteScalar().ToString();

                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM hiring_decisions WHERE final_decision = 'accepted'", conn))
                        lblAccepted.Text = cmd.ExecuteScalar().ToString();

                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM hiring_decisions WHERE final_decision = 'rejected'", conn))
                        lblRejected.Text = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                lblTotal.Text = "—";
                lblPending.Text = "—";
                lblInterviews.Text = "—";
                lblAccepted.Text = "—";
                lblRejected.Text = "—";
                MessageBox.Show("Error loading summary: " + ex.Message);
            }
        }

        private void ApplyRoleVisibility()
        {
            string role = SessionManager.CurrentUser?.Role ?? string.Empty;
            btnMaintenance.Visible = (role == "admin");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSummaryCards();
            MessageBox.Show("Dashboard refreshed.", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApplicantReview_Click(object sender, EventArgs e)
        {
            new frmApplicantReview().Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new frmReports().Show();
            this.Hide();
        }

        private void btnVacancyManagement_Click(object sender, EventArgs e)
        {
            new HRApplicantSystem.Forms.Maintenance.frmJobVacancyManagement().Show();
            this.Hide();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            new HRApplicantSystem.Forms.Maintenance.frmMaintenance().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.Logout();
                new frmHRLogin().Show();
                this.Close();
            }
        }
    }
}