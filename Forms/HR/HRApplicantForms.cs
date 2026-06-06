using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class HRApplicantForms : Form
    {
        public HRApplicantForms()
        {
            InitializeComponent();
        }

        private void HRApplicantForms_Load(object sender, EventArgs e)
        {
            LoadApplicants();
        }

        private void LoadApplicants()
        {
            string query = @"
                SELECT ap.application_id,
                       a.first_name + ' ' + a.last_name  AS name,
                       jv.title                          AS position,
                       ap.status,
                       CONVERT(varchar, ap.submitted_at, 101) AS date_submitted
                FROM   applications ap
                JOIN   applicants    a  ON ap.applicant_id   = a.applicant_id
                JOIN   job_vacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
                ORDER BY ap.submitted_at DESC";

            var dt = new DataTable();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }

            dgvApplicants.DataSource = dt;

            if (dgvApplicants.Columns["application_id"] != null)
                dgvApplicants.Columns["application_id"].Visible = false;

            if (dgvApplicants.Columns["name"] != null)
                dgvApplicants.Columns["name"].HeaderText = "Name";
            if (dgvApplicants.Columns["position"] != null)
                dgvApplicants.Columns["position"].HeaderText = "Position";
            if (dgvApplicants.Columns["status"] != null)
                dgvApplicants.Columns["status"].HeaderText = "Status";
            if (dgvApplicants.Columns["date_submitted"] != null)
                dgvApplicants.Columns["date_submitted"].HeaderText = "Date Submitted";
        }

        private void dgvApplicants_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var reviewForm = new frmApplicantReview();
            reviewForm.Show();
            this.Close();
        }
    }
}