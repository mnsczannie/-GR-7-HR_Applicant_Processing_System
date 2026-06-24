// =============================================================
//  frmMyApplication.cs
//
//  PURPOSE
//  ───────
//  This page manages applications the applicant has ALREADY
//  created via the Job Vacancies page.
//
//  HOW DRAFTS WORK
//  ───────────────
//  When the applicant clicks "Apply" on Job Vacancies, the
//  application is saved as status = 'draft' (not submitted yet).
//  They come here to review it, optionally change the position,
//  and then click Submit when they are ready to send it to HR.
//
//  BUTTON REFERENCE
//  ────────────────
//  Save Draft   – saves the currently-selected draft's position
//                 choice back to the database (used after Edit).
//  Submit       – promotes 'draft' → 'submitted' and logs the
//                 status change in status_history.
//  Edit         – for DRAFT only: opens a dropdown so the
//                 applicant can change to a different open vacancy.
//  Delete       – hard-deletes a DRAFT (cleans up history rows
//                 first to avoid FK violation, then removes the
//                 application row).
//  Withdraw     – for SUBMITTED only: removes the application
//                 before HR starts reviewing it (also cleans up
//                 history rows first).
//  Back         – closes this dialog; the dashboard (which
//                 opened it via ShowDialog) regains focus.
// =============================================================

using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmMyApplication : Form
    {
        private string userEmail;

        // Holds the vacancy the applicant chose while editing a draft.
        // Key = vacancy_id, Value = display text shown in the combo.
        private Dictionary<int, string> _openVacancies
            = new Dictionary<int, string>();

        // The vacancy_id the applicant has chosen during an edit session.
        // -1 means no pending change.
        private int _pendingVacancyId = -1;

        // ── Constructor ──────────────────────────────────────
        public frmMyApplication(string email)
        {
            InitializeComponent();
            userEmail = email;

            listViewApps.View = System.Windows.Forms.View.Details;
            listViewApps.FullRowSelect = true;
            listViewApps.GridLines = true;
            listViewApps.Columns.Clear();
            listViewApps.Columns.Add("App ID", 70);
            listViewApps.Columns.Add("Position", 200);
            listViewApps.Columns.Add("Department", 160);
            listViewApps.Columns.Add("Status", 130);
            listViewApps.Columns.Add("Submitted", 110);

            // cboVacancy is hidden until the applicant clicks Edit.
            cboVacancy.Visible = false;
            lblPickJob.Visible = false;
            UITheme.Apply(this);
        }

        // Opens frmMyDocuments as a dialog so the applicant can upload
        // required documents without leaving this form.
        // After they close it, we re-check doc completeness and
        // enable/disable Submit accordingly.
        private void btnUploadDocs_Click(object sender, EventArgs e)
        {
            if (!TryGetSelection(out int appId, out string status)) return;

            using (var docsForm = new frmMyDocuments(userEmail))
            {
                docsForm.ShowDialog(this);
            }

            // Re-evaluate submit eligibility after they return
            RefreshSubmitButton();
        }

        // Checks whether all required documents for the selected draft
        // have been submitted. Enables/disables btnSubmit accordingly.
        private void RefreshSubmitButton()
        {
            if (listViewApps.SelectedItems.Count == 0 ||
                listViewApps.SelectedItems[0].Text == "—")
            {
                btnSubmit.Enabled = false;
                return;
            }

            if (!int.TryParse(listViewApps.SelectedItems[0].Text, out int appId))
            {
                btnSubmit.Enabled = false;
                return;
            }

            string status = listViewApps.SelectedItems[0].SubItems[3].Text;
            if (status != "draft")
            {
                // Non-draft rows: Submit doesn't apply, leave it as-is
                btnSubmit.Enabled = false;
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    int applicantId = GetApplicantId(conn);
                    if (applicantId == -1) { btnSubmit.Enabled = false; return; }

                    // Count how many required docs exist vs how many are submitted
                    using (var cmd = new SqlCommand(
                        @"SELECT
                    COUNT(*)                                        AS total,
                    SUM(CASE WHEN ad.status = 'submitted'
                                  AND ad.file_path IS NOT NULL
                             THEN 1 ELSE 0 END)                    AS done
                  FROM applications a
                  INNER JOIN job_requirements jr
                      ON jr.job_id = a.vacancy_id
                  LEFT JOIN applicant_documents ad
                      ON ad.req_type_id  = jr.req_type_id
                     AND ad.applicant_id = @aid
                  WHERE a.application_id = @appId", conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", applicantId);
                        cmd.Parameters.AddWithValue("@appId", appId);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int total = Convert.ToInt32(dr["total"]);
                                int done = Convert.ToInt32(dr["done"]);

                                // Allow submit only when every required doc is uploaded
                                btnSubmit.Enabled = total > 0 && done == total;

                                // Give the applicant a clear hint
                                btnSubmit.Text = btnSubmit.Enabled
                                    ? "Submit"
                                    : $"Submit ({done}/{total} docs)";
                            }
                        }
                    }
                }
            }
            catch
            {
                btnSubmit.Enabled = false;
            }
        }

        // ── Form Load ────────────────────────────────────────
        private void frmMyApplication_Load(object sender, EventArgs e)
        {
            LoadMyApplications();
        }

        // ── Load / Refresh the list ──────────────────────────
        private void LoadMyApplications()
        {
            listViewApps.Items.Clear();
            HideEditPanel();   // reset any in-progress edit

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT
                            a.application_id,
                            p.title       AS position_title,
                            d.name        AS department_name,
                            a.status,
                            a.submitted_at
                          FROM applications a
                          INNER JOIN applicants   ap ON a.applicant_id = ap.applicant_id
                          INNER JOIN job_vacancies v  ON a.vacancy_id   = v.vacancy_id
                          INNER JOIN positions    p   ON v.position_id  = p.position_id
                          INNER JOIN departments  d   ON v.department_id = d.department_id
                          WHERE ap.email = @Email
                          ORDER BY a.last_updated DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", userEmail);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListViewItem item = new ListViewItem(
                                    dr["application_id"].ToString());

                                item.SubItems.Add(dr["position_title"].ToString());
                                item.SubItems.Add(dr["department_name"].ToString());
                                item.SubItems.Add(dr["status"].ToString());
                                item.SubItems.Add(
                                    dr["submitted_at"] == DBNull.Value
                                    ? "Not submitted"
                                    : Convert.ToDateTime(dr["submitted_at"])
                                              .ToString("MM/dd/yyyy"));

                                switch (dr["status"].ToString())
                                {
                                    case "draft":
                                        item.ForeColor = Color.Gray; break;
                                    case "submitted":
                                    case "under_review":
                                        item.ForeColor = Color.DarkOrange; break;
                                    case "screened":
                                    case "interview_scheduled":
                                    case "interviewed":
                                        item.ForeColor = Color.Blue; break;
                                    case "accepted":
                                        item.ForeColor = Color.Green; break;
                                    case "rejected":
                                        item.ForeColor = Color.Red; break;
                                }

                                listViewApps.Items.Add(item);
                            }
                        }
                    }
                }

                if (listViewApps.Items.Count == 0)
                {
                    ListViewItem empty = new ListViewItem("—");
                    empty.SubItems.Add(
                        "No applications yet. Go to Job Vacancies to apply.");
                    empty.SubItems.Add(""); empty.SubItems.Add(""); empty.SubItems.Add("");
                    empty.ForeColor = Color.Gray;
                    listViewApps.Items.Add(empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applications: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshSubmitButton();
        }

        // ── Helper: get applicant_id for the logged-in user ──
        private int GetApplicantId(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT applicant_id FROM applicants WHERE email = @Email", conn))
            {
                cmd.Parameters.AddWithValue("@Email", userEmail);
                object r = cmd.ExecuteScalar();
                return r == null ? -1 : Convert.ToInt32(r);
            }
        }

        // ── Helper: validate and read the selected list row ──
        private bool TryGetSelection(out int appId, out string status)
        {
            appId = -1;
            status = string.Empty;

            if (listViewApps.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an application first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (listViewApps.SelectedItems[0].Text == "—")
            {
                MessageBox.Show("No valid application is selected.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(listViewApps.SelectedItems[0].Text, out appId))
            {
                MessageBox.Show("Invalid application ID.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            status = listViewApps.SelectedItems[0].SubItems[3].Text;
            return true;
        }

        // ── Helper: log to audit_logs, then delete history, then delete application ──
        //
        // ORDER MATTERS:
        //   1. Write to audit_logs FIRST (while application_id still exists).
        //      audit_logs.target_id stores the application ID as a plain integer —
        //      it has NO foreign key to applications, so it survives the deletion
        //      and permanently records that this action happened.
        //   2. Delete status_history rows (they DO have an FK to applications,
        //      so they must go before the application row).
        //   3. Delete the application row itself.
        //
        // Everything runs inside one transaction so either all three steps
        // succeed or none of them do.
        //
        // Parameters:
        //   action — human-readable description, e.g. "Deleted draft application"
        //            or "Withdrew submitted application"
        private void DeleteApplicationWithHistory(
            SqlConnection conn, int appId, int applicantId, string action)
        {
            using (SqlTransaction tx = conn.BeginTransaction())
            {
                try
                {
                    // STEP 1 — Permanently record this action in audit_logs.
                    //          audit_logs has NO FK to applications, so this row
                    //          stays in the database even after the application
                    //          is gone. It is the permanent evidence that the
                    //          applicant performed this action.
                    using (SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO audit_logs
                            (user_id, action, target, target_id, performed_at)
                          VALUES
                            (@UserId, @Action, 'applications', @TargetId, GETDATE())",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@UserId", applicantId);
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@TargetId", appId);
                        cmd.ExecuteNonQuery();
                    }

                    // STEP 2 — Remove status_history rows.
                    //          These DO have an FK pointing to applications,
                    //          so they must be deleted before the application row.
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM status_history WHERE application_id = @AppId",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@AppId", appId);
                        cmd.ExecuteNonQuery();
                    }

                    // STEP 3 — Now safe to delete the application row itself.
                    using (SqlCommand cmd = new SqlCommand(
                        @"DELETE FROM applications
                          WHERE application_id = @AppId
                            AND applicant_id   = @ApplicantId",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@AppId", appId);
                        cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                            throw new InvalidOperationException(
                                "Application not found or you are not " +
                                "authorised to remove it.");
                    }

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        // ════════════════════════════════════════════════════
        //  BUTTON HANDLERS
        // ════════════════════════════════════════════════════

        // ── Save Draft ───────────────────────────────────────
        // Saves the vacancy the applicant picked in the Edit
        // combo box back to the database without submitting.
        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            if (_pendingVacancyId == -1)
            {
                MessageBox.Show(
                    "Select a draft application and click Edit first,\n" +
                    "then choose a different position before saving.",
                    "Nothing to Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!TryGetSelection(out int appId, out string status)) return;

            if (status != "draft")
            {
                MessageBox.Show("Only draft applications can be saved.",
                    "Invalid Action", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"UPDATE applications
                          SET vacancy_id   = @VacancyId,
                              last_updated = GETDATE()
                          WHERE application_id = @AppId", conn))
                    {
                        cmd.Parameters.AddWithValue("@VacancyId", _pendingVacancyId);
                        cmd.Parameters.AddWithValue("@AppId", appId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Draft saved successfully.",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMyApplications();   // refreshes the list and hides the combo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving draft: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Submit ───────────────────────────────────────────
        // Promotes 'draft' → 'submitted' and logs the change.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!TryGetSelection(out int appId, out string status)) return;

            if (status != "draft")
            {
                MessageBox.Show(
                    "Only draft applications can be submitted.\n" +
                    $"Current status: {status}",
                    "Invalid Action", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Submit this application to HR?\n\n" +
                    "You will not be able to edit the position " +
                    "once it is submitted.",
                    "Confirm Submit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                int applicantId;
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    applicantId = GetApplicantId(conn);
                }

                if (applicantId == -1)
                {
                    MessageBox.Show("Applicant account not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                using (var conn2 = DatabaseHelper.GetConnection())
                {
                    conn2.Open();
                    using (var cmd = new SqlCommand(
                        @"UPDATE applications
          SET submitted_at = GETDATE()
          WHERE application_id = @appId", conn2))
                    {
                        cmd.Parameters.AddWithValue("@appId", appId);
                        cmd.ExecuteNonQuery();
                    }
                }


                StatusHistoryLogger.LogStatusChange(
    appId,
    previousStatus: "draft",
    newStatus: "submitted",
    changedByUserId: applicantId,
    remarks: "Applicant submitted application.");

                // Deduct vacancy slot on submission
                using (var slotConn = DatabaseHelper.GetConnection())
                {
                    slotConn.Open();
                    using (var slotCmd = new SqlCommand(
                        @"UPDATE job_vacancies
          SET slots = slots - 1,
              status = CASE WHEN slots - 1 <= 0 THEN 'closed' ELSE status END
          WHERE vacancy_id = (
              SELECT vacancy_id FROM applications WHERE application_id = @appId
          )
          AND slots > 0", slotConn))
                    {
                        slotCmd.Parameters.AddWithValue("@appId", appId);
                        slotCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Application submitted successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMyApplications();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting application: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetSelection(out int appId, out string status)) return;

            if (status != "draft")
            {
                MessageBox.Show(
                    "Only draft applications can be edited.\n" +
                    $"Current status: {status}\n\n" +
                    "If you want to withdraw a submitted application, " +
                    "use the Withdraw button.",
                    "Cannot Edit", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Load all open vacancies into the combo box.
            _openVacancies.Clear();
            cboVacancy.Items.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT v.vacancy_id,
                                 p.title      AS position,
                                 d.name       AS department,
                                 et.label     AS emp_type
                          FROM   job_vacancies v
                          INNER JOIN positions       p  ON v.position_id        = p.position_id
                          INNER JOIN departments     d  ON v.department_id      = d.department_id
                          INNER JOIN employment_types et ON v.employment_type_id = et.type_id
                          WHERE  v.status = 'open'
                          ORDER BY d.name, p.title", conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int vid = Convert.ToInt32(dr["vacancy_id"]);
                                string display = $"{dr["position"]} " +
                                                 $"— {dr["department"]} " +
                                                 $"({dr["emp_type"]})";
                                _openVacancies[vid] = display;
                                cboVacancy.Items.Add(display);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading vacancies: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboVacancy.Items.Count == 0)
            {
                MessageBox.Show("There are no open vacancies to switch to.",
                    "No Vacancies", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Show the combo so the applicant can pick a new position.
            lblPickJob.Text = "Choose a new position, then click Save Draft:";
            lblPickJob.Visible = true;
            cboVacancy.Visible = true;
            cboVacancy.SelectedIndex = -1;
            _pendingVacancyId = -1;
        }

        // Fires when the applicant picks a job in the combo box.
        private void cboVacancy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVacancy.SelectedIndex < 0) return;

            string chosen = cboVacancy.SelectedItem.ToString();
            foreach (var kv in _openVacancies)
            {
                if (kv.Value == chosen)
                {
                    _pendingVacancyId = kv.Key;
                    break;
                }
            }
        }

        // ── Delete ───────────────────────────────────────────
        // Hard-deletes a DRAFT. Cleans up status_history first
        // to avoid the FK constraint error.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetSelection(out int appId, out string status)) return;

            if (status != "draft")
            {
                MessageBox.Show(
                    "Only draft applications can be deleted.\n" +
                    $"Current status: {status}\n\n" +
                    "To cancel a submitted application use Withdraw.",
                    "Cannot Delete", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string position = listViewApps.SelectedItems[0].SubItems[1].Text;

            if (MessageBox.Show(
                    $"Permanently delete your draft application for:\n  {position}\n\n" +
                    "This cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                int applicantId;
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    applicantId = GetApplicantId(conn);
                }

                if (applicantId == -1)
                {
                    MessageBox.Show("Applicant account not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    DeleteApplicationWithHistory(conn, appId, applicantId,
                        $"Deleted draft application #{appId} for '{position}'.");
                }

                MessageBox.Show("Draft application deleted.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMyApplications();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting application: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Withdraw ─────────────────────────────────────────
        // Removes a SUBMITTED application before HR reviews it.
        // Cleans up status_history first to avoid the FK error.
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (!TryGetSelection(out int appId, out string status)) return;

            if (status != "submitted")
            {
                MessageBox.Show(
                    "Only submitted applications can be withdrawn.\n" +
                    $"Current status: {status}\n\n" +
                    "• To remove a draft, use Delete.\n" +
                    "• Applications already under review cannot be withdrawn.",
                    "Cannot Withdraw", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string position = listViewApps.SelectedItems[0].SubItems[1].Text;
            string department = listViewApps.SelectedItems[0].SubItems[2].Text;

            if (MessageBox.Show(
                    $"Withdraw your application for:\n\n" +
                    $"  Position   : {position}\n" +
                    $"  Department : {department}\n\n" +
                    "You can re-apply from the Job Vacancies page afterwards.",
                    "Confirm Withdraw",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                int applicantId;
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    applicantId = GetApplicantId(conn);
                }

                if (applicantId == -1)
                {
                    MessageBox.Show("Applicant account not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    DeleteApplicationWithHistory(conn, appId, applicantId,
                        $"Withdrew submitted application #{appId} for '{position}' ({department}).");
                }

                MessageBox.Show(
                    "Application withdrawn. You may re-apply from Job Vacancies.",
                    "Withdrawn", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMyApplications();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error withdrawing application: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Back ─────────────────────────────────────────────
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── Helpers ──────────────────────────────────────────
        private void HideEditPanel()
        {
            cboVacancy.Visible = false;
            lblPickJob.Visible = false;
            _pendingVacancyId = -1;
        }

        private void listViewApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideEditPanel();
            RefreshSubmitButton(); // re-check docs every time they click a row
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}