using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmApplicantList : Form
    {
        public frmApplicantList() { InitializeComponent(); }

        private void frmApplicantList_Load(object sender, EventArgs e)
            => LoadApplicants();

        private void LoadApplicants(string q = "")
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Use CASE in SQL to return a string instead of BIT
                    string sql = @"SELECT applicant_id AS [ID],
                        full_name AS [Name], email AS [Email],
                        phone AS [Phone], gender AS [Gender],
                        city AS [City], school AS [School],
                        degree AS [Degree],
                        CASE WHEN is_active = 1 THEN 'Yes' ELSE 'No' END AS [Active]
                        FROM applicants";
                    if (!string.IsNullOrEmpty(q))
                        sql += " WHERE full_name LIKE @q OR email LIKE @q";
                    sql += " ORDER BY full_name";

                    var ada = new SqlDataAdapter(sql, conn);
                    if (!string.IsNullOrEmpty(q))
                        ada.SelectCommand.Parameters.AddWithValue("@q", "%" + q + "%");
                    var dt = new DataTable();
                    ada.Fill(dt);
                    dgvApplicants.DataSource = dt;

                    if (dgvApplicants.Columns["ID"] != null)
                        dgvApplicants.Columns["ID"].Visible = false;

                    // Colour the Active column — no type conversion needed
                    // because SQL already returns a string
                    foreach (DataGridViewRow row in dgvApplicants.Rows)
                    {
                        bool active = row.Cells["Active"].Value?.ToString() == "Yes";
                        row.Cells["Active"].Style.ForeColor =
                            active ? Color.Green : Color.Red;
                    }
                    lblCount.Text = $"Total: {dt.Rows.Count} applicant(s)";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private int SelId()
        {
            if (dgvApplicants.SelectedRows.Count == 0) return -1;
            return Convert.ToInt32(dgvApplicants.SelectedRows[0].Cells["ID"].Value);
        }
        private string SelEmail()
        {
            if (dgvApplicants.SelectedRows.Count == 0) return null;
            return dgvApplicants.SelectedRows[0].Cells["Email"].Value?.ToString();
        }

        private void btnSearch_Click(object s, EventArgs e)
            => LoadApplicants(txtSearch.Text.Trim());
        private void btnClear_Click(object s, EventArgs e)
        { txtSearch.Clear(); LoadApplicants(); }


        private void btnDeactivateApplicant_Click(object s, EventArgs e)
        {
            int id = SelId(); if (id == -1) { MessageBox.Show("Select first."); return; }
            if (MessageBox.Show("Deactivate this applicant account?", "Confirm",
            MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                "UPDATE applicants SET is_active=0 WHERE applicant_id=@id", conn))
                { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); }
            }
            MessageBox.Show("Applicant deactivated."); LoadApplicants();
        }

        private void btnViewProfile_Click(object s, EventArgs e)
        {
            string email = SelEmail();
            if (email == null) { MessageBox.Show("Select an applicant first."); return; }
            new frmHRApplicantProfile(email).ShowDialog();
        }

        private void btnViewDocuments_Click(object s, EventArgs e)
        {
            int id = SelId();
            if (id == -1) { MessageBox.Show("Select an applicant first."); return; }
            new frmHRViewDocuments(id).ShowDialog();
        }

        private void btnBack_Click(object s, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmHRDashboard)
                {
                    f.Show();
                    f.BringToFront();
                    break;
                }
            }

            this.Close();
        }

        private void dgvApplicants_CellDoubleClick(object s, DataGridViewCellEventArgs e)
        { if (e.RowIndex >= 0) btnViewProfile_Click(s, e); }

        private void dgvApplicants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
