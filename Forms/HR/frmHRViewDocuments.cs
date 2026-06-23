using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRViewDocuments : Form
    {
        private readonly int _applicantId;
        public frmHRViewDocuments(int applicantId)
        { 
            InitializeComponent(); 
            _applicantId = applicantId;
            UITheme.Apply(this);
        }

        private void frmHRViewDocuments_Load(object s, EventArgs e)
        { LoadName(); LoadDocuments(); }

        private void LoadName()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT full_name FROM applicants WHERE applicant_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _applicantId);
                        object r = cmd.ExecuteScalar();
                        this.Text = $"Documents — {r}";
                        lblApplicantName.Text = r?.ToString() ?? "";
                    }
                }
            }
            catch { }
        }

        private void LoadDocuments()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        @"SELECT ad.doc_id AS [DocID], rt.label AS [Document Type],
                             ad.status AS [Status], ad.file_path AS [FilePath],
                             ad.remarks AS [Remarks],
                             ad.uploaded_at AS [Uploaded]
                      FROM applicant_documents ad
                      INNER JOIN requirement_types rt ON ad.req_type_id=rt.req_type_id
                      WHERE ad.applicant_id=@id ORDER BY rt.label", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _applicantId);
                        var ada = new SqlDataAdapter(cmd); var dt = new DataTable(); ada.Fill(dt);
                        dgvDocuments.DataSource = dt;
                        // Hide raw columns from display but keep them accessible
                        if (dgvDocuments.Columns["DocID"] != null) dgvDocuments.Columns["DocID"].Visible = false;
                        if (dgvDocuments.Columns["FilePath"] != null) dgvDocuments.Columns["FilePath"].Visible = false;
                        // Colour status
                        foreach (DataGridViewRow row in dgvDocuments.Rows)
                        {
                            string st = row.Cells["Status"].Value?.ToString();
                            row.Cells["Status"].Style.ForeColor = st == "submitted" ? Color.Green : Color.Red;
                        }
                        lblDocCount.Text = $"{dt.Rows.Count} document record(s)";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // ── OPEN FILE ──────────────────────────────────────────────
        private void btnOpen_Click(object s, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) { MessageBox.Show("Select a document row first."); return; }
            string path = dgvDocuments.SelectedRows[0].Cells["FilePath"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("No file has been uploaded for this document."); return;
            }
            try
            {
                if (path.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                else if (File.Exists(path))
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                else
                    MessageBox.Show($"File not found:\n{path}\n\nThe applicant may have uploaded it from a different computer.",
                        "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show("Cannot open file: " + ex.Message); }
        }

        // ── REJECT DOCUMENT ───────────────────────────────────────
        private void btnRejectDoc_Click(object s, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) { MessageBox.Show("Select a document first."); return; }
            int docId = Convert.ToInt32(dgvDocuments.SelectedRows[0].Cells["DocID"].Value);
            string reason = ShowInputDialog("Rejection reason (optional):", "Reject Document");
            if (MessageBox.Show("Mark this document as rejected/missing?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "UPDATE applicant_documents SET status='missing',remarks=@r WHERE doc_id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@r", reason);
                        cmd.Parameters.AddWithValue("@id", docId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Document marked as rejected."); LoadDocuments();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnRefresh_Click(object s, EventArgs e) => LoadDocuments();
        private void btnClose_Click(object s, EventArgs e) => this.Close();

        // ── Lightweight input prompt (avoids Microsoft.VisualBasic dependency) ──
        private static string ShowInputDialog(string prompt, string title)
        {
            using (var dlg = new Form())
            using (var lbl = new Label())
            using (var txt = new TextBox())
            using (var btnOk = new Button())
            using (var btnCancel = new Button())
            {
                dlg.Text = title;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MinimizeBox = false;
                dlg.MaximizeBox = false;
                dlg.ClientSize = new Size(360, 130);

                lbl.Text = prompt;
                lbl.AutoSize = true;
                lbl.Location = new Point(12, 15);

                txt.Location = new Point(12, 40);
                txt.Size = new Size(336, 26);

                btnOk.Text = "OK";
                btnOk.DialogResult = DialogResult.OK;
                btnOk.Location = new Point(192, 80);
                btnOk.Size = new Size(75, 30);

                btnCancel.Text = "Cancel";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(273, 80);
                btnCancel.Size = new Size(75, 30);

                dlg.Controls.Add(lbl);
                dlg.Controls.Add(txt);
                dlg.Controls.Add(btnOk);
                dlg.Controls.Add(btnCancel);
                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCancel;

                return dlg.ShowDialog() == DialogResult.OK ? txt.Text : "";
            }
        }
    }
}