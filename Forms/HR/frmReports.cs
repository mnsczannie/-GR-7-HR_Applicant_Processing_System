using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            LoadTab(tabAll, "");
            LoadTab(tabPending, "submitted");
            LoadTab(tabInterviews, "interview_scheduled");
            LoadTab(tabAccepted, "accepted");
            LoadTab(tabRejected, "rejected");
            LoadMissingRequirements();
        }

        // ─────────────────────────────────────────────
        // TAB CHANGE — lazy re-load not needed since
        // we load all tabs on startup, but wired anyway
        // ─────────────────────────────────────────────
        private void tabReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = tabReports.SelectedTab;
            if (tab == tabAll) LoadTab(tabAll, "");
            else if (tab == tabPending) LoadTab(tabPending, "submitted");
            else if (tab == tabInterviews) LoadTab(tabInterviews, "interview_scheduled");
            else if (tab == tabAccepted) LoadTab(tabAccepted, "accepted");
            else if (tab == tabRejected) LoadTab(tabRejected, "rejected");
            else if (tab == tabMissing) LoadMissingRequirements();
        }

        private void LoadTab(TabPage tab, string statusFilter)
        {
            string whereClause = string.IsNullOrEmpty(statusFilter)
                ? ""
                : "WHERE ap.status = @Status";

            string query = $@"
                SELECT a.first_name + ' ' + a.last_name  AS applicant_name,
                       jv.title                          AS position,
                       jv.department,
                       ap.status,
                       CONVERT(varchar, ap.submitted_at, 101) AS date_submitted
                FROM   applications ap
                JOIN   applicants    a  ON ap.applicant_id    = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id  = jv.job_vacancy_id
                {whereClause}
                ORDER BY ap.submitted_at DESC";

            var dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(statusFilter))
                    cmd.Parameters.AddWithValue("@Status", statusFilter);
                conn.Open();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }

            var grid = GetGridFromTab(tab);
            if (grid != null) grid.DataSource = dt;
        }

        private void LoadMissingRequirements()
        {
            string query = @"
                SELECT a.first_name + ' ' + a.last_name AS applicant_name,
                       jv.title                         AS position,
                       rt.requirement_name              AS missing_requirement
                FROM   requirement_types rt
                CROSS JOIN applications ap
                JOIN   applicants    a  ON ap.applicant_id   = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
                WHERE  NOT EXISTS (
                    SELECT 1 FROM applicant_documents ad
                    WHERE  ad.application_id      = ap.application_id
                      AND  ad.requirement_type_id = rt.requirement_type_id
                )
                  AND  ap.status NOT IN ('accepted', 'rejected')
                ORDER BY a.last_name, rt.requirement_name";

            var dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }

            dgvMissing.DataSource = dt;
        }

        private DataGridView GetGridFromTab(TabPage tab)
        {
            foreach (Control c in tab.Controls)
                if (c is DataGridView dgv) return dgv;
            return null;
        }

        // ─────────────────────────────────────────────
        // EXPORT TO CSV
        // ─────────────────────────────────────────────
        private void btnExport_Click(object sender, EventArgs e)
        {
            var grid = GetGridFromTab(tabReports.SelectedTab);
            if (grid == null || grid.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = $"Report_{tabReports.SelectedTab.Text}_{DateTime.Now:yyyyMMdd}.csv";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                var sb = new StringBuilder();

                // Header row
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    sb.Append(grid.Columns[i].HeaderText);
                    if (i < grid.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();

                // Data rows
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        string val = row.Cells[i].Value?.ToString() ?? "";
                        // Escape commas
                        if (val.Contains(",")) val = $"\"{val}\"";
                        sb.Append(val);
                        if (i < grid.Columns.Count - 1) sb.Append(",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
