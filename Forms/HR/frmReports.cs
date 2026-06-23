using System;
using System.Data;
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
            UITheme.Apply(this);
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
            LoadApplicants();
        }

        private void LoadDashboardStats()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    lblTotalApplicants.Text = GetCount(conn,
                        "SELECT COUNT(*) FROM applicants").ToString();
                    lblPending.Text = GetCount(conn, @"
                        SELECT COUNT(*) FROM applications
                        WHERE status IN ('draft','submitted','under_review')").ToString();
                    lblInterviewed.Text = GetCount(conn,
                        "SELECT COUNT(*) FROM interview_schedules").ToString();
                    lblAccepted.Text = GetCount(conn, @"
                        SELECT COUNT(*) FROM hiring_decisions
                        WHERE final_decision = 'accepted'").ToString();
                    lblRejected.Text = GetCount(conn, @"
                        SELECT COUNT(*) FROM hiring_decisions
                        WHERE final_decision = 'rejected'").ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading stats: " + ex.Message); }
        }

        private int GetCount(SqlConnection conn, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn))
                return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void LoadReport(string sql, string reportTitle = "")
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        _printData = dt;
                        dgvReports.DataSource = dt;
                        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        if (!string.IsNullOrEmpty(reportTitle))
                            lblReportTitle.Text = $"{reportTitle}  —  {dt.Rows.Count} record(s)";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void LoadApplicants()
        {
            LoadReport(@"
                SELECT ap.applicant_id AS [ID],
                    ap.full_name AS [Full Name], ap.email AS [Email],
                    ap.phone AS [Phone], ap.city AS [City],
                    COUNT(a.application_id) AS [Total Applications],
                    ap.created_at AS [Registered On]
                FROM applicants ap
                LEFT JOIN applications a ON a.applicant_id = ap.applicant_id
                GROUP BY ap.applicant_id, ap.full_name, ap.email,
                         ap.phone, ap.city, ap.created_at
                ORDER BY ap.created_at DESC", "Applicant List");
        }

        private void LoadPending()
        {
            LoadReport(@"
                SELECT a.application_id AS [App ID],
                    ap.full_name AS [Applicant], ap.email AS [Email],
                    p.title AS [Position], d.name AS [Department],
                    et.label AS [Employment Type], a.status AS [Status],
                    a.submitted_at AS [Submitted On], a.updated_at AS [Last Updated]
                FROM applications a
                INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                INNER JOIN positions p ON p.position_id = v.position_id
                INNER JOIN departments d ON d.department_id = v.department_id
                INNER JOIN employment_types et ON et.type_id = v.employment_type_id
                WHERE a.status IN ('draft','submitted','under_review')
                ORDER BY a.updated_at DESC", "Pending Applications");
        }

        private void LoadInterviews()
        {
            LoadReport(@"
                SELECT ap.full_name AS [Applicant], ap.email AS [Email],
                    p.title AS [Position], d.name AS [Department],
                    s.scheduled_date AS [Interview Date],
                    s.scheduled_time AS [Interview Time],
                    s.status AS [Interview Status], s.location AS [Location]
                FROM interview_schedules s
                INNER JOIN applications a ON a.application_id = s.application_id
                INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                INNER JOIN positions p ON p.position_id = v.position_id
                INNER JOIN departments d ON d.department_id = v.department_id
                ORDER BY s.scheduled_date DESC", "Interview Schedule");
        }

        private void LoadAccepted()
        {
            LoadReport(@"
                SELECT ap.full_name AS [Applicant], ap.email AS [Email],
                    ap.phone AS [Phone], p.title AS [Position],
                    d.name AS [Department], et.label AS [Employment Type],
                    hd.decided_at AS [Date Accepted], hd.remarks AS [Remarks]
                FROM hiring_decisions hd
                INNER JOIN applications a ON a.application_id = hd.application_id
                INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                INNER JOIN positions p ON p.position_id = v.position_id
                INNER JOIN departments d ON d.department_id = v.department_id
                INNER JOIN employment_types et ON et.type_id = v.employment_type_id
                WHERE hd.final_decision = 'accepted'
                ORDER BY hd.decided_at DESC", "Accepted Applicants");
        }

        private void LoadRejected()
        {
            LoadReport(@"
                SELECT ap.full_name AS [Applicant], ap.email AS [Email],
                    p.title AS [Position], d.name AS [Department],
                    hd.decided_at AS [Date Rejected], hd.remarks AS [Remarks]
                FROM hiring_decisions hd
                INNER JOIN applications a ON a.application_id = hd.application_id
                INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                INNER JOIN positions p ON p.position_id = v.position_id
                INNER JOIN departments d ON d.department_id = v.department_id
                WHERE hd.final_decision = 'rejected'
                ORDER BY hd.decided_at DESC", "Rejected Applicants");
        }

        private void LoadMissingRequirements()
        {
            LoadReport(@"
                SELECT ap.full_name AS [Applicant], ap.email AS [Email],
                    p.title AS [Position], d.name AS [Department],
                    rt.label AS [Missing Document],
                    a.status AS [Application Status],
                    a.submitted_at AS [Submitted On]
                FROM applicant_documents ad
                INNER JOIN applicants ap ON ap.applicant_id = ad.applicant_id
                INNER JOIN requirement_types rt ON rt.req_type_id = ad.req_type_id
                INNER JOIN applications a ON a.applicant_id = ap.applicant_id
                INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                INNER JOIN positions p ON p.position_id = v.position_id
                INNER JOIN departments d ON d.department_id = v.department_id
                WHERE ad.status = 'missing'
                ORDER BY ap.full_name, rt.label", "Missing Requirements");
        }

        private void btnApplicants_Click(object sender, EventArgs e) => LoadApplicants();
        private void btnPending_Click(object sender, EventArgs e) => LoadPending();
        private void btnInterviews_Click(object sender, EventArgs e) => LoadInterviews();
        private void btnAccepted_Click(object sender, EventArgs e) => LoadAccepted();
        private void btnRejected_Click(object sender, EventArgs e) => LoadRejected();
        private void btnMissing_Click(object sender, EventArgs e) => LoadMissingRequirements();

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportFullReport();
        }

        private void ExportFullReport()
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "HTML Report (*.html)|*.html";
                saveDialog.FileName = $"HR_Report_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                saveDialog.Title = "Export Full HR Report";
                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(@"<!DOCTYPE html>
<html><head><meta charset='utf-8'>
<title>HR Applicant System — Full Report</title>
<style>
  body { font-family: Verdana, sans-serif; margin: 40px; background: #f4f6f9; color: #333; }
  h1 { color: #1f3864; border-bottom: 3px solid #1f5c99; padding-bottom: 10px; }
  h2 { color: #1f5c99; margin-top: 40px; border-left: 5px solid #1f5c99; padding-left: 10px; }
  .meta { color: #888; font-size: 12px; margin-bottom: 30px; }
  table { border-collapse: collapse; width: 100%; margin-bottom: 20px; background: white; }
  th { background: #1f5c99; color: white; padding: 10px 14px; text-align: left; }
  td { padding: 9px 14px; border-bottom: 1px solid #eee; }
  .no-data { color: #aaa; font-style: italic; padding: 12px; }
  .footer { margin-top: 50px; color: #aaa; font-size: 11px; text-align: center; }
</style></head><body>");

                    sb.AppendLine($"<h1>HR Applicant System — Full Report</h1>");
                    sb.AppendLine($"<p class='meta'>Generated: {DateTime.Now:MMMM dd, yyyy — hh:mm tt}</p>");

                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        sb.AppendLine("<h2>1. Applicant List</h2>");
                        AppendTable(conn, sb, @"
                            SELECT ap.applicant_id AS [ID], ap.full_name AS [Full Name],
                                ap.email AS [Email], ap.phone AS [Phone], ap.city AS [City],
                                COUNT(a.application_id) AS [Total Applications],
                                CONVERT(varchar, ap.created_at, 107) AS [Registered On]
                            FROM applicants ap
                            LEFT JOIN applications a ON a.applicant_id = ap.applicant_id
                            GROUP BY ap.applicant_id, ap.full_name, ap.email,
                                     ap.phone, ap.city, ap.created_at
                            ORDER BY ap.created_at DESC");

                        sb.AppendLine("<h2>2. Pending Applications</h2>");
                        AppendTable(conn, sb, @"
                            SELECT a.application_id AS [App ID], ap.full_name AS [Applicant],
                                p.title AS [Position], d.name AS [Department],
                                a.status AS [Status],
                                CONVERT(varchar, a.submitted_at, 107) AS [Submitted On]
                            FROM applications a
                            INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                            INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                            INNER JOIN positions p ON p.position_id = v.position_id
                            INNER JOIN departments d ON d.department_id = v.department_id
                            WHERE a.status IN ('draft','submitted','under_review')
                            ORDER BY a.updated_at DESC", statusCol: "Status");

                        sb.AppendLine("<h2>3. Interview Schedule</h2>");
                        AppendTable(conn, sb, @"
                            SELECT ap.full_name AS [Applicant], p.title AS [Position],
                                CONVERT(varchar, s.scheduled_date, 107) AS [Date],
                                s.status AS [Interview Status], s.location AS [Location]
                            FROM interview_schedules s
                            INNER JOIN applications a ON a.application_id = s.application_id
                            INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                            INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                            INNER JOIN positions p ON p.position_id = v.position_id
                            ORDER BY s.scheduled_date DESC", statusCol: "Interview Status");

                        sb.AppendLine("<h2>4. Accepted Applicants</h2>");
                        AppendTable(conn, sb, @"
                            SELECT ap.full_name AS [Applicant], ap.email AS [Email],
                                p.title AS [Position], d.name AS [Department],
                                CONVERT(varchar, hd.decided_at, 107) AS [Date Accepted]
                            FROM hiring_decisions hd
                            INNER JOIN applications a ON a.application_id = hd.application_id
                            INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                            INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                            INNER JOIN positions p ON p.position_id = v.position_id
                            INNER JOIN departments d ON d.department_id = v.department_id
                            WHERE hd.final_decision = 'accepted'
                            ORDER BY hd.decided_at DESC");

                        sb.AppendLine("<h2>5. Rejected Applicants</h2>");
                        AppendTable(conn, sb, @"
                            SELECT ap.full_name AS [Applicant], ap.email AS [Email],
                                p.title AS [Position], d.name AS [Department],
                                CONVERT(varchar, hd.decided_at, 107) AS [Date Rejected]
                            FROM hiring_decisions hd
                            INNER JOIN applications a ON a.application_id = hd.application_id
                            INNER JOIN applicants ap ON ap.applicant_id = a.applicant_id
                            INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                            INNER JOIN positions p ON p.position_id = v.position_id
                            INNER JOIN departments d ON d.department_id = v.department_id
                            WHERE hd.final_decision = 'rejected'
                            ORDER BY hd.decided_at DESC");

                        sb.AppendLine("<h2>6. Missing Requirements</h2>");
                        AppendTable(conn, sb, @"
                            SELECT ap.full_name AS [Applicant], p.title AS [Position],
                                rt.label AS [Missing Document], a.status AS [Application Status]
                            FROM applicant_documents ad
                            INNER JOIN applicants ap ON ap.applicant_id = ad.applicant_id
                            INNER JOIN requirement_types rt ON rt.req_type_id = ad.req_type_id
                            INNER JOIN applications a ON a.applicant_id = ap.applicant_id
                            INNER JOIN job_vacancies v ON v.vacancy_id = a.vacancy_id
                            INNER JOIN positions p ON p.position_id = v.position_id
                            WHERE ad.status = 'missing'
                            ORDER BY ap.full_name", statusCol: "Application Status");
                    }

                    sb.AppendLine($"<div class='footer'>HR Applicant System | {DateTime.Now:yyyy}</div>");
                    sb.AppendLine("</body></html>");

                    System.IO.File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(saveDialog.FileName)
                        { UseShellExecute = true });
                    MessageBox.Show("Report exported successfully!",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Export error: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AppendTable(SqlConnection conn, StringBuilder sb, string sql, string statusCol = "")
        {
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0) { sb.AppendLine("<p class='no-data'>No records found.</p>"); return; }

                sb.AppendLine($"<p style='color:#888;font-size:12px'>{dt.Rows.Count} record(s)</p>");
                sb.AppendLine("<table><thead><tr>");
                foreach (DataColumn col in dt.Columns)
                    sb.AppendLine($"<th>{col.ColumnName}</th>");
                sb.AppendLine("</tr></thead><tbody>");

                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendLine("<tr>");
                    foreach (DataColumn col in dt.Columns)
                    {
                        string val = row[col]?.ToString() ?? "";
                        sb.AppendLine($"<td>{val.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")}</td>");
                    }
                    sb.AppendLine("</tr>");
                }
                sb.AppendLine("</tbody></table>");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new frmHRDashboard().Show();
            this.Close();
        }
    }
}