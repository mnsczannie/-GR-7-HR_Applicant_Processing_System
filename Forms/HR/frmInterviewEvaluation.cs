using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmInterviewEvaluation : Form
    {
        private int _appId = -1;
        private int _schedId = -1;

        public frmInterviewEvaluation()
        {
            InitializeComponent();
            dgvInterviewed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInterviewed.ReadOnly = true;
            dgvInterviewed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInterviewed.AllowUserToAddRows = false;
            dgvInterviewed.RowHeadersVisible = false;

            dgvInterviewed.SelectionChanged += (s, e) =>
            {
                if (dgvInterviewed.SelectedRows.Count == 0) return;
                var row = dgvInterviewed.SelectedRows[0];
                if (row.Cells["SchedID"].Value == null || row.Cells["AppID"].Value == null) return;

                _schedId = Convert.ToInt32(row.Cells["SchedID"].Value);
                _appId = Convert.ToInt32(row.Cells["AppID"].Value);
                lblApplicantName.Text = row.Cells["Applicant"].Value?.ToString() ?? "";
                lblJobApplied.Text = row.Cells["Position"].Value?.ToString() ?? "";
            };
        }

        private void frmInterviewEvaluation_Load(object sender, EventArgs e)
        {
            LoadScheduleInfo();
        }

        private void LoadScheduleInfo()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT s.schedule_id AS [SchedID],
                        a.application_id AS [AppID],
                        ap.full_name AS [Applicant],
                        p.title AS [Position],
                        it.label AS [Interview Type],
                        s.scheduled_date AS [Date]
                        FROM interview_schedules s
                        INNER JOIN applications a ON s.application_id = a.application_id
                        INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                        INNER JOIN job_vacancies v ON a.vacancy_id = v.vacancy_id
                        INNER JOIN positions p ON v.position_id = p.position_id
                        INNER JOIN interview_types it ON s.interview_type_id = it.interview_type_id
                        WHERE s.status = 'completed'
                          AND s.interviewer_id = @userId
                          AND NOT EXISTS (
                              SELECT 1 FROM interview_evaluations ie
                              WHERE ie.schedule_id = s.schedule_id
                          )
                        ORDER BY s.scheduled_date DESC";

                    var ada = new SqlDataAdapter(sql, conn);
                    ada.SelectCommand.Parameters.AddWithValue("@userId", SessionManager.CurrentUser.UserId);
                    var dt = new DataTable();
                    ada.Fill(dt);
                    dgvInterviewed.DataSource = dt;

                    if (dgvInterviewed.Columns["SchedID"] != null)
                        dgvInterviewed.Columns["SchedID"].Visible = false;
                    if (dgvInterviewed.Columns["AppID"] != null)
                        dgvInterviewed.Columns["AppID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Save(string result)
        {
            if (_schedId == -1 || _appId == -1)
            {
                MessageBox.Show("Select a completed interview from the list.");
                return;
            }

            if (!decimal.TryParse(txtScore.Text.Trim(), out decimal score) || score < 0 || score > 100)
            {
                MessageBox.Show("Enter a valid score between 0 and 100.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            using (var cmd = new SqlCommand(@"
                                INSERT INTO interview_evaluations
                                    (schedule_id, application_id, score, remarks,
                                     result, recommendation, evaluated_by, evaluated_at)
                                VALUES (@sid, @aid, @sc, @rm, @rs, @rec, @by, GETDATE())", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@sid", _schedId);
                                cmd.Parameters.AddWithValue("@aid", _appId);
                                cmd.Parameters.AddWithValue("@sc", score);
                                cmd.Parameters.AddWithValue("@rm", txtRemarks.Text.Trim());
                                cmd.Parameters.AddWithValue("@rs", result);
                                cmd.Parameters.AddWithValue("@rec", txtRecommendation.Text.Trim());
                                cmd.Parameters.AddWithValue("@by", SessionManager.CurrentUser.UserId);
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = new SqlCommand(@"
                                UPDATE applications
                                SET status = 'evaluated', updated_at = GETDATE()
                                WHERE application_id = @appId", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@appId", _appId);
                                cmd.ExecuteNonQuery();
                            }

                            StatusHistoryLogger.LogStatusChange(
                                _appId, "for_interview", "evaluated",
                                SessionManager.CurrentUser.UserId,
                                $"Interview result: {result}");

                            tx.Commit();

                            lblResult.Text = $"Result: {result.ToUpper()}";
                            lblResult.ForeColor = result == "pass" ? Color.Green : Color.Red;

                            MessageBox.Show($"Evaluation saved. Result: {result.ToUpper()}",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadScheduleInfo();
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
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnPass_Click(object sender, EventArgs e) => Save("pass");
        private void btnFail_Click(object sender, EventArgs e) => Save("fail");

        private void btnNext_Click(object sender, EventArgs e)
        {
            new frmHiringDecision().Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new frmInterviewSchedule().Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void txtRemarks_TextChanged(object sender, EventArgs e) { }
    }
}