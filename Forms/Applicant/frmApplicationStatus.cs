using HRApplicantSystem.Forms.HR;
using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmApplicationStatus : Form
    {
        private string userEmail;

        public frmApplicationStatus(string email)
        {
            InitializeComponent();
            userEmail = email;
            UITheme.Apply(this);
        }

        private void frmApplicationStatus_Load_1(object sender, EventArgs e)
        {
            LoadStatusDetails();
            LoadStatusHistory();
        }

        private void LoadStatusHistory()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT sh.changed_at AS [Date],
                                sh.old_status AS [From], sh.new_status AS [To],
                                ISNULL(u.full_name,'System') AS [Changed By],
                                ISNULL(sh.remarks,'') AS [Remarks]
                                FROM status_history sh
                                LEFT JOIN users u ON sh.changed_by = u.user_id
                                INNER JOIN applications a ON sh.application_id = a.application_id
                                INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                                WHERE ap.email = @Email ORDER BY sh.changed_at";
                var ada = new SqlDataAdapter(sql, conn);
                ada.SelectCommand.Parameters.AddWithValue(
                    "@Email",
                    userEmail);

                var dt = new DataTable();
                ada.Fill(dt);
                dgvHistory.DataSource = dt;
            }
        }


        private void LoadStatusDetails()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT 
                            a.status,
                            s.scheduled_date,
                            s.scheduled_time,
                            s.location,
                            hd.final_decision,
                            sr.remarks
                          FROM applications a
                          INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                          LEFT JOIN interview_schedules s ON s.application_id = a.application_id
                          LEFT JOIN hiring_decisions hd ON hd.application_id = a.application_id
                          LEFT JOIN screening_results sr ON sr.application_id = a.application_id
                          WHERE ap.email = @Email
                          ORDER BY a.last_updated DESC
                          OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", userEmail);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // 1. CURRENT STATUS
                                string currentStatus = dr["status"].ToString();
                                lblCurrentStatus.Text = "Current Status: " + currentStatus;

                                ResetStepColors();

                                switch (currentStatus)
                                {
                                    case "submitted":
                                    case "draft":
                                        lblStep1.BackColor = Color.Green;
                                        break;
                                    case "under_review":
                                    case "screened":
                                        lblStep1.BackColor = Color.Green;
                                        lblStep2.BackColor = Color.Orange;
                                        break;
                                    case "interview_scheduled":
                                    case "interviewed":
                                        lblStep1.BackColor = Color.Green;
                                        lblStep2.BackColor = Color.Green;
                                        lblStep3.BackColor = Color.Orange;
                                        break;
                                    case "accepted":
                                    case "rejected":
                                        lblStep1.BackColor = Color.Green;
                                        lblStep2.BackColor = Color.Green;
                                        lblStep3.BackColor = Color.Green;
                                        lblStep4.BackColor = Color.Blue;
                                        break;
                                }

                                // 2. REMARKS
                                string remarks = dr["remarks"] == DBNull.Value ? "" : dr["remarks"].ToString();
                                lblRemarks.Text = string.IsNullOrEmpty(remarks)
                                    ? "Remarks: No remarks yet."
                                    : "Remarks: " + remarks;

                                // 3. INTERVIEW SCHEDULE
                                // 3. INTERVIEW SCHEDULE — hide if accepted or rejected
                                if (currentStatus == "accepted")
                                {
                                    lblSchedule.Text = "Schedule: N/A (Accepted)";
                                    lblSchedule.ForeColor = Color.Green;
                                }
                                else if (currentStatus == "rejected")
                                {
                                    lblSchedule.Text = "Schedule: N/A (Rejected)";
                                    lblSchedule.ForeColor = Color.Red;
                                }
                                else if (currentStatus == "interview_cancelled")
                                {
                                    lblSchedule.Text = "Schedule: Interview was cancelled.";
                                    lblSchedule.ForeColor = Color.OrangeRed;
                                }
                                else if (dr["scheduled_date"] != DBNull.Value)
                                {
                                    string date = Convert.ToDateTime(dr["scheduled_date"]).ToString("MMMM dd, yyyy");
                                    string time = dr["scheduled_time"].ToString();
                                    string venue = dr["location"].ToString();
                                    lblSchedule.Text = $"Schedule: {date}\n Time: {time}\n Where: {venue}";
                                    lblSchedule.ForeColor = Color.Black;
                                }
                                else
                                {
                                    lblSchedule.Text = "Schedule: Not yet scheduled";
                                    lblSchedule.ForeColor = Color.Black;
                                }

                                // 4. FINAL RESULT
                                string result = dr["final_decision"] == DBNull.Value ? "" : dr["final_decision"].ToString();
                                if (string.IsNullOrEmpty(result))
                                {
                                    lblResult.Text = "Final Result: ";
                                    lblResult.ForeColor = Color.Orange;
                                }
                                else
                                {
                                    lblResult.Text = "Final Result: " + result.ToUpper();
                                    lblResult.ForeColor = result == "accepted" ? Color.Green : Color.Red;
                                }
                            }
                            else
                            {
                                lblCurrentStatus.Text = "No application found.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ResetStepColors()
        {
            lblStep1.BackColor = Color.Gray;
            lblStep2.BackColor = Color.Gray;
            lblStep3.BackColor = Color.Gray;
            lblStep4.BackColor = Color.Gray;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }

     

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmApplicantDashboard(userEmail).Show();
            this.Hide();
        }
    }
}