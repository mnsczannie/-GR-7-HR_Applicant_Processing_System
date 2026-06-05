using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmInterviewEvaluation : Form
    {
        private readonly int _applicationId;
        private int _scheduleId;

        public frmInterviewEvaluation(int applicationId)
        {
            InitializeComponent();
            _applicationId = applicationId;
        }

        // ─────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────
        private void frmInterviewEvaluation_Load(object sender, EventArgs e)
        {
            LoadScheduleInfo();
            ApplyRoleVisibility();
        }

        private void LoadScheduleInfo()
        {
            string query = @"
                SELECT isc.schedule_id,
                       a.first_name + ' ' + a.last_name                       AS full_name,
                       jv.title                                                AS position,
                       CONVERT(varchar, isc.scheduled_at, 120)                AS schedule_info,
                       u.first_name + ' ' + u.last_name                       AS interviewer,
                       it.type_name                                            AS interview_type
                FROM   interview_schedules isc
                JOIN   applications ap ON isc.application_id = ap.application_id
                JOIN   applicants   a  ON ap.applicant_id    = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id  = jv.job_vacancy_id
                JOIN   users         u  ON isc.interviewer_id = u.user_id
                JOIN   interview_types it ON isc.interview_type_id = it.interview_type_id
                WHERE  isc.application_id = @AppId
                ORDER BY isc.scheduled_at DESC";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AppId", _applicationId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        _scheduleId = Convert.ToInt32(reader["schedule_id"]);
                        lblApplicantName.Text = reader["full_name"].ToString();
                        lblScheduleInfo.Text = $"{reader["interview_type"]}  |  " +
                                                   $"{reader["schedule_info"]}  |  " +
                                                   $"Interviewer: {reader["interviewer"]}";
                    }
                }
            }
        }

        /// <summary>
        /// Show/hide Hiring Decision button based on role.
        /// </summary>
        private void ApplyRoleVisibility()
        {
            string role = SessionManager.CurrentUser?.Role ?? string.Empty;
            bool canDecide = role == "admin" || role == "hr_manager";
            btnHiringDecision.Visible = canDecide;
        }

        // ─────────────────────────────────────────────
        // SAVE
        // ─────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rdoPass.Checked && !rdoFail.Checked)
            {
                MessageBox.Show("Please select Pass or Fail.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = rdoPass.Checked ? "pass" : "fail";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        string insertSql = @"
                            INSERT INTO interview_evaluations
                                   (schedule_id, application_id, score, remarks,
                                    result, recommendation, evaluated_by, evaluated_at)
                            VALUES (@SchedId, @AppId, @Score, @Remarks,
                                    @Result, @Recommendation, @UserId, GETDATE())";

                        using (var cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@SchedId", _scheduleId);
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.Parameters.AddWithValue("@Score", (int)nudScore.Value);
                            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                            cmd.Parameters.AddWithValue("@Result", result);
                            cmd.Parameters.AddWithValue("@Recommendation", txtRecommendation.Text.Trim());
                            cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.UserId);
                            cmd.ExecuteNonQuery();
                        }

                        string updateSql = @"
                            UPDATE applications
                            SET    status     = 'interviewed',
                                   updated_at = GETDATE()
                            WHERE  application_id = @AppId";

                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.ExecuteNonQuery();
                        }

                        SystemHelper.StatusHistoryLogger.Log(
                            conn, tx, _applicationId, "interviewed",
                            SessionManager.CurrentUser.UserId);

                        tx.Commit();

                        MessageBox.Show("Evaluation saved successfully.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Re-check visibility in case state changed
                        ApplyRoleVisibility();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error saving evaluation:\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        // HIRING DECISION → role-gated
        // ─────────────────────────────────────────────
        private void btnHiringDecision_Click(object sender, EventArgs e)
        {
            // Double-check role before opening
            string role = SessionManager.CurrentUser?.Role ?? string.Empty;
            if (role != "admin" && role != "hr_manager")
            {
                MessageBox.Show("You do not have permission to make hiring decisions.",
                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var decisionForm = new frmHiringDecision(_applicationId);
            decisionForm.Show();
            this.Close();
        }
    }
}
