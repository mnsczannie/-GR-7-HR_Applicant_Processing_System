using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmDepartments : Form
    {
        public frmDepartments()
        {
            InitializeComponent();
            UITheme.Apply(this);
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT department_id AS ID, name AS Name FROM departments ORDER BY name";
                    var adapter = new SqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvDepartments.DataSource = table;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtDepartmentName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter a department name."); return; }
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("INSERT INTO departments (name) VALUES (@name)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Department added!");
                    ClearFields();
                    LoadDepartments();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error adding: " + ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            string name = txtDepartmentName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter a new name."); return; }
            int id = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["ID"].Value);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("UPDATE departments SET name = @name WHERE department_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Updated!");
                    ClearFields();
                    LoadDepartments();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error updating: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            int id = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["ID"].Value);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM positions WHERE department_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int linkedPositions = Convert.ToInt32(cmd.ExecuteScalar());
                        if (linkedPositions > 0)
                        {
                            MessageBox.Show($"Cannot delete department. There are {linkedPositions} position(s) currently linked to it.",
                                "Dependency Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    if (MessageBox.Show("Are you sure you want to delete this department?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var cmd = new SqlCommand("DELETE FROM departments WHERE department_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Department deleted successfully!");
                        ClearFields();
                        LoadDepartments();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error deleting: " + ex.Message); }
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                txtDepartmentName.Text = dgvDepartments.Rows[e.RowIndex].Cells["Name"].Value.ToString();
        }

        private void ClearFields()
        {
            txtDepartmentName.Text = "";
            dgvDepartments.ClearSelection();
        }

        private void btnMyApplication_Click(object sender, EventArgs e)
        {
            new frmMaintenance().Show();
            this.Hide();
        }
    }
}