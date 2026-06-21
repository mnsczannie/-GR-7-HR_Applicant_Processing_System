using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHiringDecision : Form
    {
        private int _appId = -1;

        public frmHiringDecision()
        {
            InitializeComponent();
            dgvPassed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPassed.ReadOnly = true;
            dgvPassed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPassed.AllowUserToAddRows = false;
            dgvPassed.RowHeadersVisible = false;
        }

        private void frmHiringDecision_Load(object s, EventArgs e)
        {
            if (SessionManager.CurrentRole != "admin" && SessionManager.CurrentRole != "hr_manager")
            {
                MessageBox.Show("Access denied. Admin or HR Manager only.");
                this.Close();
                return;
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT a.application_id AS [AppID],
                        ap.full_name AS [Applicant], ap.email AS [Email],
                        p.title AS [Position], d.name AS [Department],
                        ie.score AS [Score], ie.recommendation AS [Recommendation],
                        CAST(CASE WHEN EXISTS (
                            SELECT 1 FROM applications x
                            WHERE x.applicant_id = a.applicant_id
                              AND x.status = 'accepted'
                              AND x.application_id <> a.application_id
                        ) THEN 1 ELSE 0 END AS BIT) AS [IsAlreadyAccepted]
                        FROM applications a
                        INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                        INNER JOIN job_vacancies v ON a.vacancy_id = v.vacancy_id
                        INNER JOIN positions p ON v.position_id = p.position_id
                        INNER JOIN departments d ON v.department_id = d.department_id
                        INNER JOIN interview_evaluations ie ON ie.application_id = a.application_id
                        WHERE a.status = 'evaluated' AND ie.result = 'pass'";

                    var ada = new SqlDataAdapter(sql, conn);
                    var dt = new DataTable();
                    ada.Fill(dt);
                    dgvPassed.DataSource = dt;

                    if (dgvPassed.Columns["AppID"] != null)
                        dgvPassed.Columns["AppID"].Visible = false;
                    if (dgvPassed.Columns["IsAlreadyAccepted"] != null)
                        dgvPassed.Columns["IsAlreadyAccepted"].Visible = false;

                    foreach (DataGridViewRow row in dgvPassed.Rows)
                    {
                        bool locked = row.Cells["IsAlreadyAccepted"].Value != DBNull.Value &&
                            Convert.ToBoolean(row.Cells["IsAlreadyAccepted"].Value);
                        if (locked)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 150, 150);
                            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 200);
                            row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(120, 120, 120);
                            row.DefaultCellStyle.Font = new Font(dgvPassed.Font, FontStyle.Italic);
                            row.Tag = "locked";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Decide(string decision)
        {
            if (_appId == -1) { MessageBox.Show("Select an applicant first."); return; }

            if (MessageBox.Show($"Mark as {decision.ToUpper()}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    if (decision == "accepted")
                    {
                        using (var check = new SqlCommand(@"
                            SELECT COUNT(*) FROM applications a
                            INNER JOIN applications b ON a.applicant_id = b.applicant_id
                            WHERE b.application_id = @id AND a.status = 'accepted'", conn))
                        {
                            check.Parameters.AddWithValue("@id", _appId);
                            if ((int)check.ExecuteScalar() > 0)
                            {
                                MessageBox.Show("This applicant is already accepted for another job.",
                                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    using (var cmd = new SqlCommand(@"
                        UPDATE applications
                        SET status = @status, updated_at = GETDATE()
                        WHERE application_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@status", decision);
                        cmd.Parameters.AddWithValue("@id", _appId);
                        cmd.ExecuteNonQuery();
                    }

                    if (decision == "accepted")
                    {
                        using (var cmd = new SqlCommand(@"
                            UPDATE applications
                            SET status = 'rejected', updated_at = GETDATE()
                            WHERE applicant_id = (
                                SELECT applicant_id FROM applications WHERE application_id = @id
                            )
                            AND application_id <> @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", _appId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (var cmd = new SqlCommand(@"
                        IF EXISTS (SELECT 1 FROM hiring_decisions WHERE application_id = @id)
                            UPDATE hiring_decisions
                            SET final_decision = @d, remarks = @rm,
                                decided_by = @by, decided_at = GETDATE()
                        ELSE
                            INSERT INTO hiring_decisions
                                (application_id, final_decision, remarks, decided_by, decided_at)
                            VALUES (@id, @d, @rm, @by, GETDATE())", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _appId);
                        cmd.Parameters.AddWithValue("@d", decision);
                        cmd.Parameters.AddWithValue("@rm", txtFinalRemarks.Text.Trim());
                        cmd.Parameters.AddWithValue("@by", SessionManager.CurrentUser.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }

                StatusHistoryLogger.LogStatusChange(
                    _appId, "evaluated", decision,
                    SessionManager.CurrentUser.UserId,
                    $"Final decision: {decision}");

                lblDecision.Text = $"Decision: {decision.ToUpper()}";
                lblDecision.ForeColor = decision == "accepted" ? Color.Green : Color.Red;
                lblStatus.Text = "Status: " + decision;

                MessageBox.Show($"Decision saved: {decision.ToUpper()}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void dgvPassed_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPassed.SelectedRows.Count == 0) return;

            var row = dgvPassed.SelectedRows[0];

            if (row.Tag?.ToString() == "locked")
            {
                _appId = -1;
                lblApplicantName.Text = row.Cells["Applicant"].Value?.ToString() ?? "";
                lblJobApplied.Text = $"{row.Cells["Position"].Value} – {row.Cells["Department"].Value}";
                lblInterviewScore.Text = row.Cells["Score"].Value?.ToString() ?? "";
                lblDecision.Text = "Final Decision: LOCKED";
                lblDecision.ForeColor = Color.FromArgb(150, 150, 150);
                lblStatus.Text = "Status: Already Accepted Elsewhere";
                lblStatus.ForeColor = Color.FromArgb(150, 150, 150);
                txtFinalRemarks.Clear();
                txtFinalRemarks.Enabled = false;
                btnHire.Enabled = false;
                btnReject.Enabled = false;
                return;
            }

            _appId = Convert.ToInt32(row.Cells["AppID"].Value);
            lblApplicantName.Text = row.Cells["Applicant"].Value?.ToString() ?? "";
            lblJobApplied.Text = $"{row.Cells["Position"].Value} – {row.Cells["Department"].Value}";
            lblInterviewScore.Text = row.Cells["Score"].Value?.ToString() ?? "";
            lblDecision.Text = $"Final Decision: {row.Cells["Recommendation"].Value}";
            lblDecision.ForeColor = Color.FromArgb(85, 85, 85);
            lblStatus.Text = "Status: evaluated";
            lblStatus.ForeColor = Color.FromArgb(212, 122, 0);
            txtFinalRemarks.Clear();
            txtFinalRemarks.Enabled = true;
            btnHire.Enabled = true;
            btnReject.Enabled = true;
        }

        private void btnHire_Click(object s, EventArgs e) => Decide("accepted");
        private void btnReject_Click(object s, EventArgs e) => Decide("rejected");

        private void btnBack_Click(object s, EventArgs e)
        {
            new frmHRDashboard().Show();
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void dgvPassed_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtFinalRemarks_TextChanged(object sender, EventArgs e) { }
    }
}