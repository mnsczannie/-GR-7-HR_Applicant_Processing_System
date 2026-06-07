using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmRequirementTypes : Form
    {
        private int selectedId = -1;

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
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT id, name FROM requirement_types";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvRequirementTypes.DataSource = dt;
                    }
                }
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading database profiles: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRequirementName.Text))
            {
                MessageBox.Show("Please define a profile type category schema title description text value entry.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "INSERT INTO requirement_types (name) VALUES (@Name)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtRequirementName.Text.Trim());
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("New application tracking requirement classification template defined safely.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequirementTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Insertion failed tracking database pipelines safely: {ex.Message}", "Processing Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please choose a profile layout baseline record grid entry path.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE requirement_types SET name = @Name WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtRequirementName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", selectedId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Target schema field structural naming convention synchronized successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequirementTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Modification updates terminated unexpectedly: {ex.Message}", "Processing Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select an active schema element data configuration profile grid row definition path pointer.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Remove chosen baseline rule schema from production lists? Warning: Linked validation tracks may cascade layout assignments structural drops.", "Confirm Cascade Drop Safety Checklist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        string query = "DELETE FROM requirement_types WHERE id = @Id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", selectedId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Requirement layout item configuration dropped cleanly without data memory allocation fragmentations.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRequirementTypes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Deletion operation rejected on primary validation level constraints profiles: {ex.Message}", "Database Integrity Breach Block", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRequirementTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRequirementTypes.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["id"].Value);
                txtRequirementName.Text = row.Cells["name"].Value.ToString();
            }
        }

        private void ClearInput()
        {
            selectedId = -1;
            txtRequirementName.Clear();
        }
    }
}