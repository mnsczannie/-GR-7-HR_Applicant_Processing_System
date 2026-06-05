using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmScreening : Form
    {
        private readonly int _applicationId;

        public frmScreening(int applicationId)
        {
            InitializeComponent();
            _applicationId = applicationId;
        }

        // ─────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────
        private void frmScreening_Load(object sender, EventArgs e)
        {
            LoadApplicantInfo();
            LoadDocumentsChecklist();
            btnProceed.Enabled = false;
        }

        private void LoadApplicantInfo()
        {
            string query = @"
                SELECT a.first_name + ' ' + a.last_name   AS full_name,
                       jv.title                            AS position
                FROM   applications ap
                JOIN   applicants   a  ON ap.applicant_id = a.applicant_id
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

        private void LoadDocumentsChecklist()
        {
            string query = @"
                SELECT rt.requirement_name,
                       CASE WHEN ad.document_id IS NOT NULL THEN 'Submitted' ELSE 'Missing' END AS status
                FROM   requirement_types rt
                LEFT JOIN applicant_documents ad
                       ON rt.requirement_type_id = ad.requirement_type_id
                      AND ad.application_id      = @AppId
                ORDER BY rt.requirement_name";

            var dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AppId", _applicationId);
                conn.Open();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }

            dgvDocuments.DataSource = dt;

            // Friendly column headers
            if (dgvDocuments.Columns["requirement_name"] != null)
                dgvDocuments.Columns["requirement_name"].HeaderText = "Requirement";
            if (dgvDocuments.Columns["status"] != null)
                dgvDocuments.Columns["status"].HeaderText = "Status";
        }

        // ─────────────────────────────────────────────
        // QUALIFIED / NOT QUALIFIED toggle
        // ─────────────────────────────────────────────
        private void rdoQualified_CheckedChanged(object sender, EventArgs e)
        {
            btnProceed.Enabled = rdoQualified.Checked;
        }

        // ─────────────────────────────────────────────
        // SAVE
        // ─────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rdoQualified.Checked && !rdoNotQualified.Checked)
            {
                MessageBox.Show("Please select Qualified or Not Qualified.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = rdoQualified.Checked ? "qualified" : "not_qualified";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert screening result
                        string insertSql = @"
                            INSERT INTO screening_results
                                   (application_id, result, remarks, screened_by, screened_at)
                            VALUES (@AppId, @Result, @Remarks, @UserId, GETDATE())";

                        using (var cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.Parameters.AddWithValue("@Result", result);
                            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                            cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.UserId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update application status
                        string updateSql = @"
                            UPDATE applications
                            SET    status     = 'screened',
                                   updated_at = GETDATE()
                            WHERE  application_id = @AppId";

                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@AppId", _applicationId);
                            cmd.ExecuteNonQuery();
                        }

                        // Log status change
                        SystemHelper.StatusHistoryLogger.Log(
                            conn, tx, _applicationId, "screened",
                            SessionManager.CurrentUser.UserId);

                        tx.Commit();

                        MessageBox.Show("Screening result saved successfully.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnProceed.Enabled = rdoQualified.Checked;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error saving screening result:\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        // PROCEED → open frmInterviewSchedule
        // ─────────────────────────────────────────────
        private void btnProceed_Click(object sender, EventArgs e)
        {
            var schedForm = new frmInterviewSchedule(_applicationId);
            schedForm.Show();
            this.Close();
        }
    }
}
