using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
            UITheme.Apply(this);
        }

        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            string role = SessionManager.CurrentRole;
            if (role != "admin")
            {
                MessageBox.Show("Access denied.");
                this.Close();
                return;
            }

            LoadAuditTrail();
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
                            ap.full_name AS [Performed By],
                            al.action AS [Action],
                            al.target AS [Area],
                            al.target_id AS [Record ID]
                        FROM audit_logs al
                        LEFT JOIN applicants ap ON al.user_id = ap.applicant_id
                        ORDER BY al.performed_at DESC", conn))
                    {
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

        private void dgvAuditTrail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                string dateTime = dgvAuditTrail.Rows[e.RowIndex].Cells["Date & Time"].Value?.ToString() ?? "N/A";
                string performedBy = dgvAuditTrail.Rows[e.RowIndex].Cells["Performed By"].Value?.ToString() ?? "Unknown";
                string action = dgvAuditTrail.Rows[e.RowIndex].Cells["Action"].Value?.ToString() ?? "";
                string area = dgvAuditTrail.Rows[e.RowIndex].Cells["Area"].Value?.ToString() ?? "";
                string recordId = dgvAuditTrail.Rows[e.RowIndex].Cells["Record ID"].Value?.ToString() ?? "N/A";

                switch (area.ToLower())
                {
                    case "applicants":
                        if (action.ToLower().Contains("password"))
                            MessageBox.Show($"Security Log:\n\nUser: {performedBy}\nAction: {action}\nTime: {dateTime}", "Security Notification");
                        else
                            MessageBox.Show($"Session Activity:\n\n{performedBy} {action.ToLower()} on {dateTime}.", "Activity Log");
                        break;
                    case "documents":
                    case "applicant_documents":
                        MessageBox.Show($"Document Activity:\n\nUser: {performedBy}\nAction: {action}\nID: {recordId}\nTime: {dateTime}",
                            "Document Log");
                        break;
                    default:
                        MessageBox.Show($"Log Entry:\n\nUser: {performedBy}\nArea: {area}\nAction: {action}\nRecord ID: {recordId}\nTimestamp: {dateTime}", "Audit Trail");
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error reading audit trail: " + ex.Message); }
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            new frmDepartments().ShowDialog();
        }
        private void btnPositions_Click(object sender, EventArgs e)
        {
            new frmPositions().ShowDialog();
        }
        private void btnEmploymentTypes_Click(object sender, EventArgs e)
        {
            new frmEmploymentTypes().ShowDialog();
        }
        private void btnRequirementTypes_Click(object sender, EventArgs e)
        {
            new frmRequirementTypes().ShowDialog();
        }
        private void btnInterviewTypes_Click(object sender, EventArgs e)
        {
            new frmInterviewTypes().ShowDialog();
        }
        private void btnAssessmentTypes_Click(object sender, EventArgs e)
        {
            new frmAssessmentTypes().ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnUserManagement_Click_1(object sender, EventArgs e)
        {
            new frmUserManagement().ShowDialog();
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
    }
}