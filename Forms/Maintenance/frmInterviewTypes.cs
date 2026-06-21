using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmInterviewTypes : Form
    {
        public frmInterviewTypes()
        {
            InitializeComponent();
        }

        private void frmInterviewTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT interview_type_id AS ID, label AS Name FROM interview_types ORDER BY label";
                    var adapter = new SqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvData.DataSource = table;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtLabel.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter an interview type."); return; }
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("INSERT INTO interview_types (label) VALUES (@name)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Added!");
                    ClearFields();
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error adding: " + ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            string name = txtLabel.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter a new label."); return; }
            int id = Convert.ToInt32(dgvData.SelectedRows[0].Cells["ID"].Value);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("UPDATE interview_types SET label = @name WHERE interview_type_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Updated!");
                    ClearFields();
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error updating: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            int id = Convert.ToInt32(dgvData.SelectedRows[0].Cells["ID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this interview type?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new SqlCommand("DELETE FROM interview_types WHERE interview_type_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Deleted!");
                        ClearFields();
                        LoadData();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error deleting: " + ex.Message); }
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                txtLabel.Text = dgvData.Rows[e.RowIndex].Cells["Name"].Value.ToString();
        }

        private void ClearFields()
        {
            txtLabel.Text = "";
            dgvData.ClearSelection();
        }
    }
}