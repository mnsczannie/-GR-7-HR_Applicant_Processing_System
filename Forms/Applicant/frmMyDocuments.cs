using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmMyDocuments : Form
    {
        private string userEmail;

        public frmMyDocuments(string email)
        {
            InitializeComponent();
            userEmail = email;
            UITheme.Apply(this);
        }

        private void frmMyDocuments_Load_1(object sender, EventArgs e)
            => LoadDocumentStatus();

        private void LoadDocumentStatus()
        {
            flpDocuments.Controls.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    int applicantId = GetApplicantId(conn);
                    if (applicantId == -1)
                    { MessageBox.Show("Applicant not found."); return; }

                    // Load every document row seeded for this applicant
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT ad.doc_id, rt.req_type_id, rt.label,
                         ad.file_path, ad.status
                  FROM applicant_documents ad
                  INNER JOIN requirement_types rt
                      ON ad.req_type_id = rt.req_type_id
                  WHERE ad.applicant_id = @ApplicantId
                  ORDER BY rt.label", conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicantId", applicantId);

                        int totalDocs = 0;
                        int submittedDocs = 0;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                totalDocs++;
                                string label = dr["label"].ToString();
                                int reqTypeId = Convert.ToInt32(dr["req_type_id"]);
                                string status = dr["status"].ToString();
                                bool submitted = status == "submitted"
                                                   && !string.IsNullOrEmpty(dr["file_path"].ToString());

                                if (submitted) submittedDocs++;

                                // Build one row panel per document
                                flpDocuments.Controls.Add(
                                    BuildDocumentRow(label, reqTypeId, submitted));
                            }
                        }

                        // Overall status
                        if (totalDocs == 0)
                        {
                            lblOverallStatus.Text = "Overall Status: No documents required yet.";
                            lblOverallStatus.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            bool allComplete = submittedDocs == totalDocs;
                            lblOverallStatus.Text =
                                $"Overall Status: {submittedDocs}/{totalDocs} submitted — "
                                + (allComplete ? "Complete" : "Incomplete");
                            lblOverallStatus.ForeColor =
                                allComplete ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                        }
                    }

                    // HR Remarks
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT TOP 1 sr.remarks
                  FROM screening_results sr
                  INNER JOIN applications a
                      ON sr.application_id = a.application_id
                  WHERE a.applicant_id = @ApplicantId
                  ORDER BY sr.reviewed_at DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                        object result = cmd.ExecuteScalar();
                        txtRemarks.Text = (result != null && result != DBNull.Value)
                            ? result.ToString() : "(No remarks from HR yet.)";
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error: " + ex.Message); }
        }

        // Builds one row panel: [Label | Status | Upload btn | Remove btn]
        private System.Windows.Forms.Panel BuildDocumentRow(
            string label, int reqTypeId, bool submitted)
        {
            var row = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(660, 44),
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            // Document name label
            var lblName = new System.Windows.Forms.Label
            {
                Text = label + ":",
                Location = new System.Drawing.Point(10, 12),
                Size = new System.Drawing.Size(200, 20),
                ForeColor = System.Drawing.Color.FromArgb(85, 85, 85),
                Font = new System.Drawing.Font("Verdana", 9F)
            };

            // Status label
            var lblStatus = new System.Windows.Forms.Label
            {
                Text = submitted ? "Submitted" : "Missing",
                Location = new System.Drawing.Point(215, 12),
                Size = new System.Drawing.Size(120, 20),
                ForeColor = submitted
                            ? System.Drawing.Color.Green
                            : System.Drawing.Color.Red,
                Font = new System.Drawing.Font("Verdana", 9F,
                                System.Drawing.FontStyle.Bold)
            };

            // Upload button
            var btnUpload = new System.Windows.Forms.Button
            {
                Text = "Upload",
                Location = new System.Drawing.Point(345, 7),
                Size = new System.Drawing.Size(130, 30),
                Enabled = !submitted,
                BackColor = System.Drawing.Color.FromArgb(31, 92, 153),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Verdana", 9F,
                                       System.Drawing.FontStyle.Bold)
            };

            // Remove button
            var btnRemove = new System.Windows.Forms.Button
            {
                Text = "Remove",
                Location = new System.Drawing.Point(485, 7),
                Size = new System.Drawing.Size(130, 30),
                Enabled = submitted,
                BackColor = System.Drawing.Color.FromArgb(192, 57, 43),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Verdana", 9F,
                                       System.Drawing.FontStyle.Bold)
            };

            // Wire up events — capture reqTypeId and label in closures
            btnUpload.Click += (s, e) =>
            {
                UploadDocument(reqTypeId, label);
            };

            btnRemove.Click += (s, e) =>
            {
                RemoveDocument(reqTypeId, label);
            };

            row.Controls.Add(lblName);
            row.Controls.Add(lblStatus);
            row.Controls.Add(btnUpload);
            row.Controls.Add(btnRemove);
            return row;
        }
        private void SetStatus(Label lbl, bool submitted)
        {
            lbl.Text = submitted ? "Submitted" : "Missing";
            lbl.ForeColor = submitted ? Color.Green : Color.Red;
        }

        // Once a document is Submitted, "Upload" is disabled and "Remove"
        // becomes available — the applicant must remove the old file before
        // a new one can be uploaded (prevents silent re-submission /
        // overwriting a file HR may already be reviewing).
        private void SetDocControls(bool submitted, Button uploadBtn, Button removeBtn)
        {
            uploadBtn.Enabled = !submitted;
            removeBtn.Enabled = submitted;
        }

        private int GetApplicantId(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT applicant_id FROM applicants WHERE email = @Email",
                conn))
            {
                cmd.Parameters.AddWithValue("@Email", userEmail);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }



        // Now takes reqTypeId directly — no more string keyword matching
        private void UploadDocument(int reqTypeId, string displayName)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            string filePath = openFileDialog1.FileName;
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    int applicantId = GetApplicantId(conn);
                    if (applicantId == -1) return;

                    bool exists;
                    using (var check = new SqlCommand(
                        "SELECT COUNT(1) FROM applicant_documents" +
                        " WHERE applicant_id=@aid AND req_type_id=@rtid", conn))
                    {
                        check.Parameters.AddWithValue("@aid", applicantId);
                        check.Parameters.AddWithValue("@rtid", reqTypeId);
                        exists = Convert.ToInt32(check.ExecuteScalar()) > 0;
                    }

                    if (exists)
                    {
                        using (var cmd = new SqlCommand(
                            @"UPDATE applicant_documents
                      SET file_path=@fp, status='submitted', uploaded_at=GETDATE()
                      WHERE applicant_id=@aid AND req_type_id=@rtid", conn))
                        {
                            cmd.Parameters.AddWithValue("@fp", filePath);
                            cmd.Parameters.AddWithValue("@aid", applicantId);
                            cmd.Parameters.AddWithValue("@rtid", reqTypeId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO applicant_documents
                      (applicant_id, req_type_id, file_path, status, uploaded_at)
                      VALUES (@aid, @rtid, @fp, 'submitted', GETDATE())", conn))
                        {
                            cmd.Parameters.AddWithValue("@aid", applicantId);
                            cmd.Parameters.AddWithValue("@rtid", reqTypeId);
                            cmd.Parameters.AddWithValue("@fp", filePath);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show($"{displayName} uploaded successfully!");

                // Log to audit trail
                try
                {
                    using (var logConn = DatabaseHelper.GetConnection())
                    {
                        logConn.Open();
                        int applicantId = GetApplicantId(logConn);
                        if (applicantId != -1)
                            AuditLogger.LogAction(
                                applicantId,
                                $"Uploaded document: {displayName}",
                                "applicant_documents",
                                reqTypeId);
                    }
                }
                catch { }

                LoadDocumentStatus();
            }
            catch (Exception ex)
            { MessageBox.Show("Upload error: " + ex.Message); }
        }

        // Resets a submitted document back to "Missing" (clears the file
        // path) so the applicant can upload a corrected file afterward.
        // Now takes reqTypeId directly — no more string keyword matching
        private void RemoveDocument(int reqTypeId, string displayName)
        {
            if (MessageBox.Show(
                $"Remove your submitted {displayName}?\nYou will need to upload it again.",
                "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes)
                return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    int applicantId = GetApplicantId(conn);
                    if (applicantId == -1) return;

                    using (var cmd = new SqlCommand(
                        @"UPDATE applicant_documents
                  SET file_path = NULL, status = 'missing'
                  WHERE applicant_id=@aid AND req_type_id=@rtid", conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", applicantId);
                        cmd.Parameters.AddWithValue("@rtid", reqTypeId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"{displayName} removed. You can now upload a new file.");

                // Log to audit trail
                try
                {
                    using (var logConn = DatabaseHelper.GetConnection())
                    {
                        logConn.Open();
                        int applicantId = GetApplicantId(logConn);
                        if (applicantId != -1)
                            AuditLogger.LogAction(
                                applicantId,
                                $"Removed document: {displayName}",
                                "applicant_documents",
                                reqTypeId);
                    }
                }
                catch { }

                LoadDocumentStatus();
            }
            catch (Exception ex)
            { MessageBox.Show("Error: " + ex.Message); }
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}