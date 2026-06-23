using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmPositions : Form
    {
        public frmPositions()
        {
            InitializeComponent();
            UITheme.Apply(this);
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
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT department_id, name FROM departments ORDER BY name", conn);
                    var dr = cmd.ExecuteReader();
                    cmbDepartment.Items.Clear();
                    cmbDepartment.Items.Add(new DeptItem { Text = "-- Select Department --", Value = 0 });
                    while (dr.Read())
                        cmbDepartment.Items.Add(new DeptItem
                        {
                            Text = dr["name"].ToString(),
                            Value = (int)dr["department_id"]
                        });
                    cmbDepartment.DisplayMember = "Text";
                    cmbDepartment.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading departments: " + ex.Message); }
        }

        private void LoadPositions()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT p.position_id AS ID,
                        p.title AS Name,
                        ISNULL(d.name, 'No Department') AS Department
                        FROM positions p
                        LEFT JOIN departments d ON p.department_id = d.department_id
                        ORDER BY p.title";
                    var adapter = new SqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvPositions.DataSource = table;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private int GetSelectedDeptId()
        {
            if (cmbDepartment.SelectedIndex <= 0) return 0;
            return ((DeptItem)cmbDepartment.SelectedItem).Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtPositionTitle.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter a position title."); return; }
            int deptId = GetSelectedDeptId();
            if (deptId == 0) { MessageBox.Show("Please select a department."); return; }
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "INSERT INTO positions (title, department_id) VALUES (@name, @deptId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@deptId", deptId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Position added!");
                    ClearFields();
                    LoadPositions();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error adding: " + ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            string name = txtPositionTitle.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Please enter a new title."); return; }
            int id = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["ID"].Value);
            int deptId = GetSelectedDeptId();
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = deptId > 0
                        ? "UPDATE positions SET title = @name, department_id = @d WHERE position_id = @id"
                        : "UPDATE positions SET title = @name WHERE position_id = @id";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        if (deptId > 0) cmd.Parameters.AddWithValue("@d", deptId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Updated!");
                    ClearFields();
                    LoadPositions();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error updating: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
            int id = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["ID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this position?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new SqlCommand(
                            "DELETE FROM positions WHERE position_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Position deleted!");
                        ClearFields();
                        LoadPositions();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error deleting: " + ex.Message); }
            }
        }

        private void dgvPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPositions.Rows[e.RowIndex];
                txtPositionTitle.Text = row.Cells["Name"].Value.ToString();
                cmbDepartment.SelectedIndex = 0;
            }
        }

        private void ClearFields()
        {
            txtPositionTitle.Text = "";
            cmbDepartment.SelectedIndex = 0;
            dgvPositions.ClearSelection();
        }

        private class DeptItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}