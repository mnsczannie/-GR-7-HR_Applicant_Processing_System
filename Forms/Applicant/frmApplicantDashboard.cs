using HRApplicantSystem.Forms.Applicant;
using HRApplicantSystem.Helpers;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRApplicantSystem
{
    public partial class frmApplicantDashboard : Form
    {
        public frmApplicantDashboard()
        {
            InitializeComponent();
        }

        private void frmApplicantDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }
        private void LoadDashboard()
        {
            if (SessionManager.CurrentApplicant == null)
            {
                lblWelcome.Text = "Welcome Guest";
                return;
            }

            int applicantId = SessionManager.CurrentApplicant.ApplicantId;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // -------------------------
                    // APPLICATION STATUS ONLY
                    // -------------------------
                    string query = @"
                SELECT TOP 1 status
                FROM applications
                WHERE applicant_id = @id
                ORDER BY submitted_at DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", applicantId);
                    object result = cmd.ExecuteScalar();
                    lblAppStatus.Text = (result != null)
                        ? "Application Status: " + result.ToString()
                        : "Application Status: No application yet";

                    // MISSING DOCUMENTS COUNT
                    string docQuery = @"
    SELECT COUNT(*)
    FROM applicant_documents
    WHERE applicant_id = @id
    AND status <> 'submitted'";

                    SqlCommand docCmd = new SqlCommand(docQuery, conn);
                    docCmd.Parameters.AddWithValue("@id", applicantId);
                    int missingDocs = (int)docCmd.ExecuteScalar();

                    // UPCOMING INTERVIEW
                    string interviewQuery = @"
    SELECT TOP 1 scheduled_date, location
    FROM interview_schedules
    WHERE application_id IN
    (
        SELECT application_id
        FROM applications
        WHERE applicant_id = @id
    )
    ORDER BY scheduled_date ASC";

                    SqlCommand intCmd = new SqlCommand(interviewQuery, conn);
                    intCmd.Parameters.AddWithValue("@id", applicantId);

                    SqlDataReader reader = intCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        string location = reader.GetString(1);

                        lblInterview.Text =
                            "Upcoming Interview: " +
                            date.ToString("yyyy-MM-dd HH:mm") +
                            " @ " + location;
                    }

                    // RECENT UPDATES (STATUS HISTORY)
                    string historyQuery = @"
    SELECT TOP 5
        application_id,
        old_status,
        new_status,
        remarks,
        changed_at
    FROM status_history
    WHERE application_id IN
    (
        SELECT application_id
        FROM applications
        WHERE applicant_id = @id
    )
    ORDER BY changed_at DESC";

                    SqlDataAdapter da = new SqlDataAdapter(historyQuery, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", applicantId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStatusHistory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnOpenProfile_Click(object sender, EventArgs e)
        {
            frmMyProfile profile = new frmMyProfile();
            profile.ShowDialog();
        }

        private void btnJobVacancies_Click(object sender, EventArgs e)
        {
            frmJobVacancies form = new frmJobVacancies();
            form.ShowDialog();
        }

        private void btnMyApplication_Click(object sender, EventArgs e)
        {
            frmMyApplication form = new frmMyApplication();
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentApplicant = null;

            frmApplicantLogin login = new frmApplicantLogin();
            login.Show();

            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword form = new frmChangePassword();
            form.ShowDialog();
        }

        private void lblMissingDocs_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

      
    }
}