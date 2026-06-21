using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmInterviewSchedule : Form
    {
        private int _appId = -1;
        private int _schedInterviewerId = -1;
        private bool _selectedFromToSchedule = false;
        private bool _suppressSelectionEvents = false;

        public frmInterviewSchedule()
        {
            InitializeComponent();
            dgvToSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvToSchedule.ReadOnly = true;
            dgvToSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvToSchedule.AllowUserToAddRows = false;
            dgvToSchedule.RowHeadersVisible = false;
            dgvToSchedule.SelectionChanged += Dgv_ToSchedule_SelectionChanged;

            dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.ReadOnly = true;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.RowHeadersVisible = false;
            dgvSchedules.SelectionChanged += Dgv_Schedules_SelectionChanged;
        }

        private void frmInterviewSchedule_Load(object sender, EventArgs e)
        {
            btnComplete.Enabled = false;
            btnCancel.Enabled = false;
            btnReschedule.Enabled = false;
            btnSchedule.Enabled = false;
            dtpDate.MinDate = DateTime.Today;

            LoadInterviewers();
            LoadToSchedule();
            LoadSchedules();
        }

        private void LoadInterviewers()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT user_id, full_name FROM users WHERE is_active = 1 ORDER BY full_name", conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        cboInterviewer.Items.Clear();
                        while (dr.Read())
                            cboInterviewer.Items.Add(new InterviewerItem
                            {
                                Text = dr["full_name"].ToString(),
                                Value = Convert.ToInt32(dr["user_id"])
                            });
                        cboInterviewer.DisplayMember = "Text";
                        if (cboInterviewer.Items.Count > 0) cboInterviewer.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading interviewers: " + ex.Message); }
        }

        private void LoadToSchedule()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT a.application_id AS [AppID],
                        ap.full_name AS [Applicant], p.title AS [Position],
                        d.name AS [Department], a.status AS [Status]
                        FROM applications a
                        INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                        INNER JOIN job_vacancies v ON a.vacancy_id = v.vacancy_id
                        INNER JOIN positions p ON v.position_id = p.position_id
                        INNER JOIN departments d ON v.department_id = d.department_id
                        WHERE a.status = 'screened'
                        AND a.application_id NOT IN (SELECT application_id FROM interview_schedules)
                        ORDER BY a.submitted_at";
                    var ada = new SqlDataAdapter(sql, conn);
                    var dt = new DataTable();
                    ada.Fill(dt);
                    dgvToSchedule.DataSource = dt;
                    if (dgvToSchedule.Columns["AppID"] != null)
                        dgvToSchedule.Columns["AppID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading applicants to schedule: " + ex.Message); }
        }

        private void LoadSchedules()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT s.interviewer_id AS [InterviewerID],
                        s.schedule_id AS [SchedID], a.application_id AS [AppID],
                        ap.full_name AS [Applicant], p.title AS [Position],
                        it.label AS [Type], s.scheduled_date AS [Date],
                        s.scheduled_time AS [Time], s.location AS [Location],
                        s.status AS [Sched Status]
                        FROM interview_schedules s
                        INNER JOIN applications a ON s.application_id = a.application_id
                        INNER JOIN applicants ap ON a.applicant_id = ap.applicant_id
                        INNER JOIN job_vacancies v ON a.vacancy_id = v.vacancy_id
                        INNER JOIN positions p ON v.position_id = p.position_id
                        INNER JOIN interview_types it ON s.interview_type_id = it.interview_type_id
                        ORDER BY s.scheduled_date DESC";
                    var ada = new SqlDataAdapter(sql, conn);
                    var dt = new DataTable();
                    ada.Fill(dt);
                    dgvSchedules.DataSource = dt;
                    if (dgvSchedules.Columns["SchedID"] != null)
                        dgvSchedules.Columns["SchedID"].Visible = false;
                    if (dgvSchedules.Columns["AppID"] != null)
                        dgvSchedules.Columns["AppID"].Visible = false;
                    if (dgvSchedules.Columns["InterviewerID"] != null)
                        dgvSchedules.Columns["InterviewerID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading schedules: " + ex.Message); }
        }

        private void Dgv_ToSchedule_SelectionChanged(object s, EventArgs e)
        {
            if (_suppressSelectionEvents) return;
            if (dgvToSchedule.SelectedRows.Count == 0) return;
            var row = dgvToSchedule.SelectedRows[0];
            if (row.Cells["AppID"].Value == null) return;

            _suppressSelectionEvents = true;
            dgvSchedules.ClearSelection();
            _suppressSelectionEvents = false;

            _appId = Convert.ToInt32(row.Cells["AppID"].Value);
            _selectedFromToSchedule = true;

            lblApplicantName.Text = row.Cells["Applicant"].Value?.ToString() ?? "";
            lblJobApplied.Text = row.Cells["Position"].Value?.ToString() ?? "";
            lblSelectedApplicant.Text = "Selected: " + row.Cells["Applicant"].Value;
            lblStatus.Text = "Status: Not Scheduled";
            lblStatus.ForeColor = Color.OrangeRed;

            btnSchedule.Enabled = true;
            btnComplete.Enabled = false;
            btnCancel.Enabled = false;
            btnReschedule.Enabled = false;
            dtpDate.MinDate = DateTime.Today;
        }

        private void Dgv_Schedules_SelectionChanged(object s, EventArgs e)
        {
            if (_suppressSelectionEvents) return;
            if (dgvSchedules.SelectedRows.Count == 0) return;
            var row = dgvSchedules.SelectedRows[0];
            if (row.Cells["AppID"].Value == null) return;

            _suppressSelectionEvents = true;
            dgvToSchedule.ClearSelection();
            _suppressSelectionEvents = false;

            _appId = Convert.ToInt32(row.Cells["AppID"].Value);
            _schedInterviewerId = Convert.ToInt32(row.Cells["InterviewerID"].Value);
            _selectedFromToSchedule = false;

            string schedStatus = row.Cells["Sched Status"].Value?.ToString() ?? "";

            lblApplicantName.Text = row.Cells["Applicant"].Value?.ToString() ?? "";
            lblJobApplied.Text = row.Cells["Position"].Value?.ToString() ?? "";
            lblSelectedApplicant.Text = "Selected: " + row.Cells["Applicant"].Value;
            lblStatus.Text = "Status: " + schedStatus;
            lblStatus.ForeColor = Color.DimGray;

            btnSchedule.Enabled = false;

            bool isAssignedInterviewer = (_schedInterviewerId == SessionManager.CurrentUser.UserId);
            bool isActiveSchedule = string.Equals(schedStatus, "scheduled", StringComparison.OrdinalIgnoreCase);

            btnComplete.Enabled = isAssignedInterviewer && isActiveSchedule;
            btnCancel.Enabled = isActiveSchedule;
            btnReschedule.Enabled = isActiveSchedule;

            if (!isAssignedInterviewer)
                lblStatus.Text += " (You are not the assigned interviewer)";
        }

        private void btnSchedule_Click(object s, EventArgs e)
        {
            if (_appId == -1 || !_selectedFromToSchedule)
            {
                MessageBox.Show("Select an applicant from the 'To Schedule' list first.");
                return;
            }
            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Interview date cannot be earlier than today.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Interview location is required.");
                txtLocation.Focus();
                return;
            }
            if (cmbMode.SelectedItem == null)
            {
                MessageBox.Show("Select an interview mode.");
                return;
            }
            if (cboInterviewer.SelectedItem == null)
            {
                MessageBox.Show("Select an interviewer.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var chk = new SqlCommand(
                        "SELECT COUNT(*) FROM interview_schedules WHERE application_id = @app", conn))
                    {
                        chk.Parameters.AddWithValue("@app", _appId);
                        if ((int)chk.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("A schedule already exists for this applicant.");
                            LoadToSchedule(); LoadSchedules(); return;
                        }
                    }

                    int iviewerId = ((InterviewerItem)cboInterviewer.SelectedItem).Value;

                    using (var cmd = new SqlCommand(@"
                        INSERT INTO interview_schedules
                            (application_id, interviewer_id, interview_type_id,
                             scheduled_date, scheduled_time, location, status, created_by, created_at)
                        VALUES (@app, @iv, 1, @dt, @tm, @loc, 'scheduled', @by, GETDATE())", conn))
                    {
                        cmd.Parameters.AddWithValue("@app", _appId);
                        cmd.Parameters.AddWithValue("@iv", iviewerId);
                        cmd.Parameters.AddWithValue("@dt", dtpDate.Value.Date);
                        cmd.Parameters.AddWithValue("@tm", dtpTime.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@loc", txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@by", SessionManager.CurrentUser.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }

                StatusHistoryLogger.LogStatusChange(_appId, "screened", "interview_scheduled",
                    SessionManager.CurrentUser.UserId, "Interview scheduled.");

                lblStatus.Text = "Status: Scheduled";
                lblStatus.ForeColor = Color.Blue;
                ResetSelection();
                MessageBox.Show("Interview scheduled successfully!");
                LoadToSchedule(); LoadSchedules();
            }
            catch (Exception ex) { MessageBox.Show("Error scheduling interview: " + ex.Message); }
        }

        private void UpdateSched(string schedStatus, string appStatus)
        {
            if (_appId == -1) { MessageBox.Show("Select a schedule first."); return; }

            try
            {
                int rowsAffected;
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(@"
                        UPDATE interview_schedules
                        SET status = @schedStatus
                        WHERE application_id = @id AND status = 'scheduled'", conn))
                    {
                        cmd.Parameters.AddWithValue("@schedStatus", schedStatus);
                        cmd.Parameters.AddWithValue("@id", _appId);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }

                    if (rowsAffected > 0)
                    {
                        using (var cmd = new SqlCommand(@"
                            UPDATE applications
                            SET status = @appStatus, updated_at = GETDATE()
                            WHERE application_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@appStatus", appStatus);
                            cmd.Parameters.AddWithValue("@id", _appId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (rowsAffected == 0)
                    MessageBox.Show("This schedule was already updated. No changes made.");
                else
                {
                    StatusHistoryLogger.LogStatusChange(_appId, null, appStatus,
                        SessionManager.CurrentUser.UserId, $"Marked as {schedStatus}.");
                    lblStatus.Text = $"Status: {schedStatus}";
                    MessageBox.Show($"Marked as {schedStatus}.");
                }

                ResetSelection();
                LoadToSchedule(); LoadSchedules();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnComplete_Click(object s, EventArgs e) => UpdateSched("completed", "interviewed");
        private void btnCancel_Click(object s, EventArgs e) => UpdateSched("cancelled", "screened");

        private void btnReschedule_Click(object s, EventArgs e)
        {
            if (_appId == -1) { MessageBox.Show("Select a schedule first."); return; }
            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Interview date cannot be earlier than today.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Interview location is required."); txtLocation.Focus(); return;
            }
            if (cboInterviewer.SelectedItem == null)
            {
                MessageBox.Show("Select an interviewer."); return;
            }

            try
            {
                int iviewerId = ((InterviewerItem)cboInterviewer.SelectedItem).Value;
                int rowsAffected;
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(@"
                        UPDATE interview_schedules
                        SET interviewer_id = @iv,
                            scheduled_date = @dt,
                            scheduled_time = @tm,
                            location = @loc
                        WHERE application_id = @id AND status = 'scheduled'", conn))
                    {
                        cmd.Parameters.AddWithValue("@iv", iviewerId);
                        cmd.Parameters.AddWithValue("@dt", dtpDate.Value.Date);
                        cmd.Parameters.AddWithValue("@tm", dtpTime.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@loc", txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", _appId);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                if (rowsAffected == 0)
                    MessageBox.Show("Schedule is no longer active. No changes made.");
                else
                {
                    AuditLogger.LogAction(SessionManager.CurrentUser.UserId,
                        "Rescheduled interview", "interview_schedules", _appId);
                    MessageBox.Show("Interview rescheduled successfully!");
                }

                ResetSelection();
                LoadToSchedule(); LoadSchedules();
            }
            catch (Exception ex) { MessageBox.Show("Error rescheduling: " + ex.Message); }
        }

        private void btnNext_Click(object s, EventArgs e)
        {
            if (_appId == -1)
            {
                MessageBox.Show("Please select a scheduled interview first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new frmInterviewEvaluation().Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new frmHRDashboard().Show();
            this.Close();
        }

        private void ResetSelection()
        {
            _appId = -1;
            _selectedFromToSchedule = false;
            btnSchedule.Enabled = false;
            btnComplete.Enabled = false;
            btnCancel.Enabled = false;
            btnReschedule.Enabled = false;
            lblSelectedApplicant.Text = "Selected: (none)";
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void dgvSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvToSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private class InterviewerItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}