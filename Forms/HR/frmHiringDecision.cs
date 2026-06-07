using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHiringDecision : Form
    {
        private readonly int _applicationId;

        public frmHiringDecision(int applicationId)
        {
            InitializeComponent();
            _applicationId = applicationId;
        }

        // ─────────────────────────────────────────────
        // LOAD — enforce role gate immediately
        // ─────────────────────────────────────────────
        private void frmHiringDecision_Load(object sender, EventArgs e)
        {
            string role = SessionManager.CurrentUser?.Role ?? string.Empty;
            if (role != "admin" && role != "hr_manager")
            {
                MessageBox.Show("Access denied. Only Admin or HR Manager can make hiring decisions.",
                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }

            LoadApplicantAndEvaluation();
        }

        private void LoadApplicantAndEvaluation()
        {
            string query = @"
                SELECT a.first_name + ' ' + a.last_name  AS full_name,
                       jv.title                          AS position,
                       ie.score,
                       ie.result                         AS eval_result,
                       ie.recommendation
                FROM   applications ap
                JOIN   applicants    a  ON ap.applicant_id    = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id  = jv.job_vacancy_id
                LEFT JOIN interview_evaluations ie
                       ON ie.application_id = ap.application_id
                WHERE  ap.application_id = @AppId
                ORDER BY ie.evaluated_at DESC";

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

                        string score = reader["score"] == DBNull.Value ? "N/A" : reader["score"].ToString();
                        string result = reader["eval_result"] == DBNull.Value ? "N/A" : reader["eval_result"].ToString();
                        string rec = reader["recommendation"] == DBNull.Value ? "—" : reader["recommendation"].ToString();

                        lblEvalSummary.Text = $"Score: {score}   |   Result: {result}\nRecommendation: {rec}";
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        // SAVE
        // ─────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Second role check
            string role = SessionManager.CurrentUser?.Role ?? string.Empty;
            if (role != "admin" && role != "hr_manager")
            {
                MessageBox.Show("Access denied.",
                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!rdoAccepted.Checked && !rdoRejected.Checked && !rdoOnHold.Checked)
            {
                MessageBox.Show("Please select Accepted, Rejected, or On Hold.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string decision;
            string newAppStatus;

            if (rdoAccepted.Checked)
            {
                decision = "accepted";
                newAppStatus = "accepted";
            }
            else if (rdoRejected.Checked)
            {
                decision = "rejected";
                newAppStatus = "rejected";
            }
            else
            {
                decision = "on_hold";
                newAppStatus = "for_final_review";
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to mark this applicant as '{decision.ToUpper()}'?",
                "Confirm Decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert hiring decision record
                        string insertSql = @"
                            INSERT INTO hiring_decisions
                                   (application_id, decision, final_remarks, decided_by, decided_at)
                            VALUES (@AppId, @Decision, @Remarks, @UserId, GETDATE())";

                        using (var cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.Parameters.AddWithValue("@Decision", decision);
                            cmd.Parameters.AddWithValue("@Remarks", txtFinalRemarks.Text.Trim());
                            cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.UserId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update application status
                        string updateSql = @"
                            UPDATE applications
                            SET    status     = @Status,
                                   updated_at = GETDATE()
                            WHERE  application_id = @AppId";

                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Status", newAppStatus);
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.ExecuteNonQuery();
                        }

                        SystemHelper.StatusHistoryLogger.Log(
                            conn, tx, _applicationId, newAppStatus,
                            SessionManager.CurrentUser.UserId);

                        tx.Commit();

                        MessageBox.Show($"Applicant has been marked as {decision.ToUpper()}.",
                                        "Decision Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error saving hiring decision:\n" + ex.Message,
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
