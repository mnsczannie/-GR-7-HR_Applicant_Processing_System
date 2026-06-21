using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmUserManagement : Form
    {
        public frmUserManagement() { InitializeComponent(); }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            if (SessionManager.CurrentRole != "admin")
            {
                MessageBox.Show("Access denied. Admin only.");
                this.Close();
                return;
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Use CASE so Active column is a string, not BIT
                    string sql = @"SELECT user_id AS ID,
                        full_name AS [Name], email AS Email,
                        role AS Role,
                        CASE WHEN is_active = 1 THEN 'Active'
                             ELSE 'Inactive' END AS [Active],
                        created_at AS [Created]
                        FROM users
                        ORDER BY is_active ASC, created_at DESC";
                    var ada = new SqlDataAdapter(sql, conn);
                    var dt = new DataTable();
                    ada.Fill(dt);
                    dgvUsers.DataSource = dt;
                    dgvUsers.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                    dgvUsers.ReadOnly = true;
                    dgvUsers.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        bool active =
                            row.Cells["Active"].Value?.ToString() == "Active";
                        row.Cells["Active"].Style.ForeColor =
                            active ? Color.Green : Color.OrangeRed;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            { MessageBox.Show("Select a user first."); return; }

            int id = Convert.ToInt32(
                dgvUsers.SelectedRows[0].Cells["ID"].Value);

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "UPDATE users SET is_active = 1 WHERE user_id = @id",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account activated.");
                AuditLogger.LogAction(SessionManager.CurrentUserId,
                    "Activated HR account", "users", id);
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            { MessageBox.Show("Select a user first."); return; }

            int id = Convert.ToInt32(
                dgvUsers.SelectedRows[0].Cells["ID"].Value);

            if (id == SessionManager.CurrentUserId)
            {
                MessageBox.Show("You cannot deactivate your own account.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "UPDATE users SET is_active = 0 WHERE user_id = @id",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account deactivated.");
                AuditLogger.LogAction(SessionManager.CurrentUserId,
                    "Deactivated HR account", "users", id);
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e)
            => this.Close();

        private void dgvUsers_CellContentClick(object sender,
            DataGridViewCellEventArgs e)
        { }
    }
}