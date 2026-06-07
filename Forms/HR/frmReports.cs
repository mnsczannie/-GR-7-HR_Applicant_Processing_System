using System;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmReports : Form
    {
        private DataTable _printData = null;

        public frmReports()
        {
            InitializeComponent();
        }

        // Load all tabs on form load, and also when user switches tabs
        private void frmReports_Load(object sender, EventArgs e)
        {
            LoadTab(tabAll, "");
            LoadTab(tabPending, "submitted");
            LoadTab(tabInterviews, "for_interview");
            LoadTab(tabAccepted, "accepted");
            LoadTab(tabRejected, "rejected");
            LoadMissingRequirements();
        }

        private void tabReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = tabReports.SelectedTab;
            if (tab == tabAll) LoadTab(tabAll, "");
            else if (tab == tabPending) LoadTab(tabPending, "submitted");
            else if (tab == tabInterviews) LoadTab(tabInterviews, "for_interview");
            else if (tab == tabAccepted) LoadTab(tabAccepted, "accepted");
            else if (tab == tabRejected) LoadTab(tabRejected, "rejected");
            else if (tab == tabMissing) LoadMissingRequirements();
        }

        private void LoadTab(TabPage tab, string statusFilter)
        {
            string whereClause = string.IsNullOrEmpty(statusFilter) ? "" : "WHERE ap.status = @Status";

            string query = $@"
                SELECT a.first_name + ' ' + a.last_name       AS applicant_name,
                       jv.title                               AS position,
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

        // This report shows applicants who have missing required documents for their application.
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
                  AND  ap.status NOT IN ('accepted', 'rejected', 'withdrawn')
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
                MessageBox.Show("No data to export.", "Export",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = $"Report_{tabReports.SelectedTab.Text}_{DateTime.Now:yyyyMMdd}.csv";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                var sb = new StringBuilder();

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    sb.Append(grid.Columns[i].HeaderText);
                    if (i < grid.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        string val = row.Cells[i].Value?.ToString() ?? "";
                        if (val.Contains(",")) val = $"\"{val}\"";
                        sb.Append(val);
                        if (i < grid.Columns.Count - 1) sb.Append(",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Exported successfully.", "Export",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ─────────────────────────────────────────────
        // PRINT
        // ─────────────────────────────────────────────
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var grid = GetGridFromTab(tabReports.SelectedTab);
            if (grid == null || grid.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Store data for print event
            _printData = (DataTable)grid.DataSource;

            var printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            var preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 900,
                Height = 600
            };
            preview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_printData == null) return;

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float rowHeight = 20f;

            var titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            var headerFont = new Font("Segoe UI", 9, FontStyle.Bold);
            var dataFont = new Font("Segoe UI", 8);

            // Title
            string title = $"Report — {tabReports.SelectedTab.Text}   ({DateTime.Now:MM/dd/yyyy})";
            e.Graphics.DrawString(title, titleFont, Brushes.Black, x, y);
            y += rowHeight * 2;

            // Column headers
            float colWidth = (e.MarginBounds.Width / (float)_printData.Columns.Count);
            foreach (DataColumn col in _printData.Columns)
            {
                e.Graphics.DrawString(col.ColumnName, headerFont, Brushes.Black, x, y);
                x += colWidth;
            }
            y += rowHeight;
            x = e.MarginBounds.Left;

            // Data rows
            foreach (DataRow row in _printData.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    e.Graphics.DrawString(item?.ToString() ?? "", dataFont, Brushes.Black, x, y);
                    x += colWidth;
                }
                y += rowHeight;
                x = e.MarginBounds.Left;

                if (y > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
    }
}
