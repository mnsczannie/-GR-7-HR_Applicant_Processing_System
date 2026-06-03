using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmPositions : Form
    {
        private int selectedPositionId = -1;

        public frmPositions()
        {
            InitializeComponent();
        }

        private void frmPositions_Load(object sender, EventArgs e)
        {
            LoadDepartmentsDropdown();
            LoadPositions();
        }

        private void LoadDepartmentsDropdown()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT id, name FROM departments";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbDepartment.DataSource = dt;
                        cmbDepartment.DisplayMember = "name";
                        cmbDepartment.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPositions()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT p.id, p.title, d.name AS department_name, p.department_id " +
                                   "FROM positions p JOIN departments d ON p.department_id = d.id";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPositions.DataSource = dt;

                        if (dgvPositions.Columns["department_id"] != null)
                            dgvPositions.Columns["department_id"].Visible = false;
                    }
                }
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading positions: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPositionTitle.Text) || cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Please complete all input elements.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "INSERT INTO positions (title, department_id) VALUES (@Title, @DeptId)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtPositionTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@DeptId", cmbDepartment.SelectedValue);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Position registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving position: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedPositionId == -1 || cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Please select a target position context record to modify.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE positions SET title = @Title, department_id = @DeptId WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtPositionTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@DeptId", cmbDepartment.SelectedValue);
                        cmd.Parameters.AddWithValue("@Id", selectedPositionId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Position record updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating position: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPositionId == -1)
            {
                MessageBox.Show("Please select a valid record entity row.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this position?", "Confirm Delete Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        string query = "DELETE FROM positions WHERE id = @Id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", selectedPositionId);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Position removed cleanly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPositions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error executing deletion operations: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPositions.Rows[e.RowIndex];
                selectedPositionId = Convert.ToInt32(row.Cells["id"].Value);
                txtPositionTitle.Text = row.Cells["title"].Value.ToString();
                cmbDepartment.SelectedValue = row.Cells["department_id"].Value;
            }
        }

        private void ClearInput()
        {
            selectedPositionId = -1;
            txtPositionTitle.Clear();
        }
    }
}