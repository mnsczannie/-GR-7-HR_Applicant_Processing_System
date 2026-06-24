using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmEmploymentTypes : Form
    {
        public frmEmploymentTypes()
        {
            InitializeComponent();
            UITheme.Apply(this);
        }

        private void frmEmploymentTypes_Load(object sender, EventArgs e)
        {
            LoadEmploymentTypes();
        }

        private void LoadEmploymentTypes()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT type_id AS ID, label AS Name FROM employment_types ORDER BY label";
                    var adapter = new SqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvEmploymentTypes.DataSource = table;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtTypeName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)) { MessageBox.Show("Please enter an employment type."); return; }
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("INSERT INTO employment_types (label) VALUES (@name)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Employment type added!");
                    ClearFields();
                    LoadEmploymentTypes();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error adding: " + ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmploymentTypes.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            string name = txtTypeName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)) { MessageBox.Show("Please enter a new name."); return; }
            int id = Convert.ToInt32(dgvEmploymentTypes.SelectedRows[0].Cells["ID"].Value);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("UPDATE employment_types SET label = @name WHERE type_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Updated!");
                    ClearFields();
                    LoadEmploymentTypes();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error updating: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmploymentTypes.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            int id = Convert.ToInt32(dgvEmploymentTypes.SelectedRows[0].Cells["ID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this employment type?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new SqlCommand("DELETE FROM employment_types WHERE type_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Deleted!");
                        ClearFields();
                        LoadEmploymentTypes();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error deleting: " + ex.Message); }
            }
        }

        private void dgvEmploymentTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                txtTypeName.Text = dgvEmploymentTypes.Rows[e.RowIndex].Cells["Name"].Value.ToString();
        }

        private void ClearFields()
        {
            txtTypeName.Text = "";
            dgvEmploymentTypes.ClearSelection();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMyApplication_Click(object sender, EventArgs e)
        {
            new frmMaintenance().Show();
            this.Hide();
        }
    }
}