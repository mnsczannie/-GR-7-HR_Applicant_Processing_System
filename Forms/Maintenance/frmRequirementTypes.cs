using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmRequirementTypes : Form
    {
        public frmRequirementTypes()
        {
            InitializeComponent();
        }

        private void frmRequirementTypes_Load(object sender, EventArgs e)
        {
            LoadRequirementTypes();
        }

        private void LoadRequirementTypes()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT req_type_id AS ID, label AS Name FROM requirement_types ORDER BY label";
                    var adapter = new SqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvRequirementTypes.DataSource = table;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtRequirementName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter a requirement type."); return; }
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "INSERT INTO requirement_types (label) VALUES (@name)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Requirement type added!");
                    ClearFields();
                    LoadRequirementTypes();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error adding: " + ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRequirementTypes.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            string name = txtRequirementName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter a new name."); return; }
            int id = Convert.ToInt32(dgvRequirementTypes.SelectedRows[0].Cells["ID"].Value);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "UPDATE requirement_types SET label = @name WHERE req_type_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Updated!");
                    ClearFields();
                    LoadRequirementTypes();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error updating: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRequirementTypes.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            int id = Convert.ToInt32(dgvRequirementTypes.SelectedRows[0].Cells["ID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this requirement type?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new SqlCommand(
                            "DELETE FROM requirement_types WHERE req_type_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Deleted!");
                        ClearFields();
                        LoadRequirementTypes();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error deleting: " + ex.Message); }
            }
        }

        private void dgvRequirementTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                txtRequirementName.Text = dgvRequirementTypes.Rows[e.RowIndex].Cells["Name"].Value.ToString();
        }

        private void ClearFields()
        {
            txtRequirementName.Text = "";
            dgvRequirementTypes.ClearSelection();
        }
    }
}