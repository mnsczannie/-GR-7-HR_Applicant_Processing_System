using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmInterviewSchedule : Form
    {
        private readonly int _applicationId;

        public frmInterviewSchedule(int applicationId)
        {
            InitializeComponent();
            _applicationId = applicationId;
        }

        // ─────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────
        private void frmInterviewSchedule_Load(object sender, EventArgs e)
        {
            LoadApplicantInfo();
            LoadInterviewers();
            LoadInterviewTypes();
            LoadStatusOptions();

            // Defaults
            dtpDate.Value = DateTime.Today.AddDays(1);
            dtpTime.Value = DateTime.Today.AddHours(9);
        }

        private void LoadApplicantInfo()
        {
            string query = @"
                SELECT a.first_name + ' ' + a.last_name AS full_name,
                       jv.title                         AS position
                FROM   applications ap
                JOIN   applicants   a  ON ap.applicant_id    = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
                WHERE  ap.application_id = @AppId";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AppId", _applicationId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblApplicantName.Text = reader["full_name"].ToString();
                        lblPosition.Text = reader["position"].ToString();
                    }
                }
            }
        }

        private void LoadInterviewers()
        {
            string query = @"
                SELECT user_id, first_name + ' ' + last_name AS full_name
                FROM   users
                WHERE  role IN ('hr_staff', 'hr_manager')
                ORDER BY full_name";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);

                cboInterviewer.DisplayMember = "full_name";
                cboInterviewer.ValueMember = "user_id";
                cboInterviewer.DataSource = dt;
            }
        }

        private void LoadInterviewTypes()
        {
            string query = "SELECT interview_type_id, type_name FROM interview_types ORDER BY type_name";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);

                cboInterviewType.DisplayMember = "type_name";
                cboInterviewType.ValueMember = "interview_type_id";
                cboInterviewType.DataSource = dt;
            }
        }

        private void LoadStatusOptions()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("scheduled");
            cboStatus.Items.Add("completed");
            cboStatus.Items.Add("cancelled");
            cboStatus.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────────
        // SAVE
        // ─────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboInterviewer.SelectedValue == null)
            {
                MessageBox.Show("Please select an interviewer.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboInterviewType.SelectedValue == null)
            {
                MessageBox.Show("Please select an interview type.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime scheduledDateTime = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        string insertSql = @"
                            INSERT INTO interview_schedules
                                   (application_id, scheduled_at, interviewer_id,
                                    interview_type_id, location_or_link, status, created_by)
                            VALUES (@AppId, @ScheduledAt, @InterviewerId,
                                    @TypeId, @Location, @Status, @UserId)";

                        using (var cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.Parameters.AddWithValue("@ScheduledAt", scheduledDateTime);
                            cmd.Parameters.AddWithValue("@InterviewerId", cboInterviewer.SelectedValue);
                            cmd.Parameters.AddWithValue("@TypeId", cboInterviewType.SelectedValue);
                            cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.UserId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update application status
                        string updateSql = @"
                            UPDATE applications
                            SET    status     = 'interview_scheduled',
                                   updated_at = GETDATE()
                            WHERE  application_id = @AppId";

                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.ExecuteNonQuery();
                        }

                        SystemHelper.StatusHistoryLogger.Log(
                            conn, tx, _applicationId, "interview_scheduled",
                            SessionManager.CurrentUser.UserId);

                        tx.Commit();

                        MessageBox.Show("Interview scheduled successfully.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error saving schedule:\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
