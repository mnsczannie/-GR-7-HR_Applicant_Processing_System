using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmJobVacancies : Form
    {
        public frmJobVacancies()
        {
            InitializeComponent();
        }

        private void LoadVacancies()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT vacancy_id, position_id, department_id, slots, status
            FROM job_vacancies
            WHERE status = 'open'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvVacancies.DataSource = dt;
            }
        }

        private void frmJobVacancies_Load(object sender, EventArgs e)
        {
            LoadVacancies();
        }

        private void dgvVacancies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVacancies.Rows[e.RowIndex];

                string vacancyId = row.Cells[0].Value?.ToString();
                string positionId = row.Cells[1].Value?.ToString();
                string departmentId = row.Cells[2].Value?.ToString();
                string slots = row.Cells[3].Value?.ToString();
                string status = row.Cells[4].Value?.ToString();

                MessageBox.Show(
                    "Vacancy ID: " + vacancyId +
                    "\nPosition ID: " + positionId +
                    "\nDepartment ID: " + departmentId +
                    "\nSlots: " + slots +
                    "\nStatus: " + status
                );
            }
        }
    }
}
