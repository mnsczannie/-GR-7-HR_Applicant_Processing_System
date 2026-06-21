using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmApplicantDashboard : Form
    {
        private string _userEmail;

        public frmApplicantDashboard(string email)
        {
            InitializeComponent();
            _userEmail = email;
        }

        private void frmApplicantDashboard_Load_1(object sender, EventArgs e)
        {
            LoadWelcomeName();
            LoadDashboardData();
            LoadAuditTrail();
        }

        private void LoadWelcomeName()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT full_name FROM applicants WHERE email = @Email", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", _userEmail);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            textBox1.Text = $"Welcome, {result}!";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading name: " + ex.Message); }
        }

        private void LoadDashboardData()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string appStatus = "";

                    // Application status
                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 1 a.status
                        FROM applications a
                        INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                        WHERE ap.email = @Email
                        ORDER BY a.updated_at DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", _userEmail);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            appStatus = result.ToString();
                            lblStatus.Text = "Application: " + appStatus;
                            switch (appStatus)
                            {
                                case "accepted": lblStatus.ForeColor = Color.Green; break;
                                case "rejected":
                                case "interview_cancelled": lblStatus.ForeColor = Color.Red; break;
                                case "draft": lblStatus.ForeColor = Color.Gray; break;
                                case "under_review":
                                case "screened":
                                case "interview_scheduled":
                                case "interviewed":
                                case "evaluated": lblStatus.ForeColor = Color.Blue; break;
                                default: lblStatus.ForeColor = Color.DarkOrange; break;
                            }
                        }
                        else
                        {
                            lblStatus.Text = "Application: None yet";
                            lblStatus.ForeColor = Color.Gray;
                        }
                    }

                    // Missing documents
                    using (var cmd = new SqlCommand(@"
                        SELECT
                            COUNT(jr.req_type_id) AS total_required,
                            SUM(CASE WHEN ad.status = 'submitted' AND ad.file_path IS NOT NULL
                                     THEN 1 ELSE 0 END) AS total_submitted
                        FROM applications a
                        INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                        INNER JOIN job_requirements jr ON jr.job_id = a.vacancy_id
                        LEFT JOIN applicant_documents ad
                            ON ad.req_type_id = jr.req_type_id
                            AND ad.applicant_id = ap.applicant_id
                        WHERE ap.email = @Email
                        AND a.updated_at = (
                            SELECT MAX(a2.updated_at) FROM applications a2
                            INNER JOIN applicants ap2 ON ap2.applicant_id = a2.applicant_id
                            WHERE ap2.email = @Email
                        )", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", _userEmail);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int total = Convert.ToInt32(dr["total_required"]);
                                int submitted = dr["total_submitted"] == DBNull.Value
                                    ? 0 : Convert.ToInt32(dr["total_submitted"]);
                                int missing = Math.Max(0, total - submitted);
                                if (total == 0)
                                {
                                    lblMissingDocs.Text = "Missing document count: N/A";
                                    lblMissingDocs.ForeColor = Color.Gray;
                                }
                                else
                                {
                                    lblMissingDocs.Text = $"Missing document count: {missing}";
                                    lblMissingDocs.ForeColor = missing == 0 ? Color.Green : Color.Red;
                                }
                            }
                            else
                            {
                                lblMissingDocs.Text = "Missing document count: N/A";
                                lblMissingDocs.ForeColor = Color.Gray;
                            }
                        }
                    }

                    // Interview schedule
                    if (appStatus == "accepted")
                    {
                        lblSchedule.Text = "Interview Schedule: N/A (Accepted)";
                        lblSchedule.ForeColor = Color.Green;
                    }
                    else
                    {
                        using (var cmd = new SqlCommand(@"
                            SELECT TOP 1 s.scheduled_date, s.scheduled_time
                            FROM interview_schedules s
                            INNER JOIN applications a ON s.application_id = a.application_id
                            INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                            WHERE ap.email = @Email
                            AND s.status NOT IN ('cancelled','completed')
                            AND s.scheduled_date >= CAST(GETDATE() AS DATE)", conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", _userEmail);
                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    string date = Convert.ToDateTime(dr["scheduled_date"]).ToString("MMMM dd, yyyy");
                                    lblSchedule.Text = $"Interview Schedule: {date} at {dr["scheduled_time"]}";
                                    lblSchedule.ForeColor = Color.Black;
                                }
                                else
                                {
                                    lblSchedule.Text = "No schedule yet.";
                                    lblSchedule.ForeColor = Color.Black;
                                }
                            }
                        }
                    }

                    // Upcoming interview count
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM interview_schedules s
                        INNER JOIN applications a ON s.application_id = a.application_id
                        INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                        WHERE ap.email = @Email
                        AND s.status NOT IN ('cancelled','completed')
                        AND s.scheduled_date >= CAST(GETDATE() AS DATE)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", _userEmail);
                        label1.Text = $"Upcoming Interview: {cmd.ExecuteScalar()}";
                    }

                    // Recent updates
                    switch (appStatus)
                    {
                        case "accepted":
                            lblUpdates.Text = "RECENT UPDATES:\n- Congratulations! You have been accepted.\n- Please wait for onboarding instructions.";
                            lblUpdates.ForeColor = Color.Green; break;
                        case "rejected":
                            lblUpdates.Text = "RECENT UPDATES:\n- Your application was not successful.\n- You may re-apply for other positions.";
                            lblUpdates.ForeColor = Color.Red; break;
                        case "interview_scheduled":
                            lblUpdates.Text = "RECENT UPDATES:\n- Your interview has been scheduled.\n- Please check the schedule details above.";
                            lblUpdates.ForeColor = Color.Blue; break;
                        case "interviewed":
                        case "evaluated":
                            lblUpdates.Text = "RECENT UPDATES:\n- Your interview is complete.\n- Results are being reviewed by HR.";
                            lblUpdates.ForeColor = Color.Blue; break;
                        case "screened":
                        case "under_review":
                            lblUpdates.Text = "RECENT UPDATES:\n- Your application is under review.\n- Ensure all documents are submitted.";
                            lblUpdates.ForeColor = Color.DarkOrange; break;
                        case "interview_cancelled":
                            lblUpdates.Text = "RECENT UPDATES:\n- Your interview has been cancelled.\n- Please contact HR for more information.";
                            lblUpdates.ForeColor = Color.Red; break;
                        default:
                            using (var cmd = new SqlCommand(@"
                                SELECT TOP 1 v.status FROM job_vacancies v
                                INNER JOIN applications a ON a.vacancy_id = v.vacancy_id
                                INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                                WHERE ap.email = @Email ORDER BY a.updated_at DESC", conn))
                            {
                                cmd.Parameters.AddWithValue("@Email", _userEmail);
                                string vacStatus = cmd.ExecuteScalar()?.ToString() ?? "";
                                if (vacStatus == "closed")
                                {
                                    lblUpdates.Text = "RECENT UPDATES:\n- The vacancy you applied for has been closed.";
                                    lblUpdates.ForeColor = Color.OrangeRed;
                                    lblStatus.Text = "Application: Vacancy Closed";
                                    lblStatus.ForeColor = Color.OrangeRed;
                                }
                                else
                                {
                                    lblUpdates.Text = "RECENT UPDATES:\n- Application review is ongoing.\n- Please check your email regularly.";
                                    lblUpdates.ForeColor = Color.Black;
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading dashboard: " + ex.Message); }
        }

        private void LoadAuditTrail()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(@"
                        SELECT al.performed_at AS [Date & Time],
                            al.action AS [Action],
                            al.target AS [Area],
                            al.target_id AS [Record ID]
                        FROM audit_logs al
                        INNER JOIN applicants ap ON al.user_id = ap.applicant_id
                        WHERE ap.email = @Email
                        ORDER BY al.performed_at DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", _userEmail);
                        var dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        dgvAuditTrail.DataSource = dt;

                        foreach (DataGridViewRow row in dgvAuditTrail.Rows)
                        {
                            string action = row.Cells["Action"].Value?.ToString().ToLower() ?? "";
                            if (action.Contains("submitted")) row.DefaultCellStyle.ForeColor = Color.Green;
                            else if (action.Contains("deleted") || action.Contains("withdrew")) row.DefaultCellStyle.ForeColor = Color.Red;
                            else if (action.Contains("uploaded")) row.DefaultCellStyle.ForeColor = Color.Blue;
                            else if (action.Contains("draft")) row.DefaultCellStyle.ForeColor = Color.Gray;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading audit trail: " + ex.Message); }
        }

        public void RefreshDashboardData()
        {
            LoadDashboardData();
            LoadAuditTrail();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            var profile = new frmMyProfile(_userEmail);
            profile.FormClosed += (s, args) => { this.Show(); RefreshDashboardData(); };
            profile.Show();
            this.Hide();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            new frmChangePassword(_userEmail).ShowDialog();
            RefreshDashboardData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuditLogger.LogActionByEmail(_userEmail, "Logged out", "applicants");
            new frmApplicantLogin().Show();
            this.Close();
        }

        private void btnViewStatus_Click(object sender, EventArgs e)
        {
            new frmApplicationStatus(_userEmail).Show();
        }

        private void btnJobVacancies_Click(object sender, EventArgs e)
        {
            new frmJobVacancies(_userEmail).Show();
            this.Hide();
        }

        private void btnMyApplication_Click(object sender, EventArgs e)
        {
            using (var form = new frmMyApplication(_userEmail))
                form.ShowDialog(this);
            LoadDashboardData();
            LoadAuditTrail();
        }

        private void dgvAuditTrail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                string dateTime = dgvAuditTrail.Rows[e.RowIndex].Cells["Date & Time"].Value?.ToString() ?? "N/A";
                string action = dgvAuditTrail.Rows[e.RowIndex].Cells["Action"].Value?.ToString() ?? "";
                string area = dgvAuditTrail.Rows[e.RowIndex].Cells["Area"].Value?.ToString() ?? "";
                string recordId = dgvAuditTrail.Rows[e.RowIndex].Cells["Record ID"].Value?.ToString() ?? "N/A";

                switch (area.ToLower())
                {
                    case "applicants":
                        if (action.ToLower().Contains("password"))
                            MessageBox.Show($"Security Log:\n\nAction: {action}\nTime: {dateTime}", "Security Notification");
                        else
                            MessageBox.Show($"Session Activity:\n\nYou {action.ToLower()} on {dateTime}.", "Activity Log");
                        break;
                    case "documents":
                    case "applicant_documents":
                        if (MessageBox.Show($"Document Activity:\n\nAction: {action}\nID: {recordId}\nTime: {dateTime}\n\nOpen profile to manage documents?",
                            "Document Log", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            btnProfile_Click(this, EventArgs.Empty);
                        break;
                    default:
                        MessageBox.Show($"Log Entry:\n\nArea: {area}\nAction: {action}\nRecord ID: {recordId}\nTimestamp: {dateTime}", "Audit Trail");
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error reading audit trail: " + ex.Message); }
        }

        private void lblStatus_Click(object sender, EventArgs e) { }
        private void lblMissingDocs_Click(object sender, EventArgs e) { }
        private void lblSchedule_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox4_Enter(object sender, EventArgs e) { }
    }
}