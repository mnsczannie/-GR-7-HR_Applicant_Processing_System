using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmEmploymentTypes : Form
    {
        private int selectedTypeId = -1;

        public frmEmploymentTypes()
        {
            InitializeComponent();
        }

        private void frmEmploymentTypes_Load(object sender, EventArgs e)
        {
            LoadEmploymentTypes();
        }

        private void LoadEmploymentTypes()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT id, name FROM employment_types";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvEmploymentTypes.DataSource = dt;
                    }
                }
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show("Please enter a type name.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "INSERT INTO employment_types (name) VALUES (@Name)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtTypeName.Text.Trim());
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Employment type registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmploymentTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedTypeId == -1)
            {
                MessageBox.Show("Please select a target row record to update.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE employment_types SET name = @Name WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtTypeName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", selectedTypeId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmploymentTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTypeId == -1)
            {
                MessageBox.Show("Please select a record entry row to remove.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this structural type configuration reference?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        string query = "DELETE FROM employment_types WHERE id = @Id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", selectedTypeId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Configuration removed cleanly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmploymentTypes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error executing database deletions: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvEmploymentTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmploymentTypes.Rows[e.RowIndex];
                selectedTypeId = Convert.ToInt32(row.Cells["id"].Value);
                txtTypeName.Text = row.Cells["name"].Value.ToString();
            }
        }

        private void ClearInput()
        {
            selectedTypeId = -1;
            txtTypeName.Clear();
        }
    }
}