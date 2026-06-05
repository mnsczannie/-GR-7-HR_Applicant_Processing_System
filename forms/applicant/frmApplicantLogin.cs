using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmApplicantLogin : Form
    {
        public frmApplicantLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login button clicked!");

            frmApplicantDashboard dashboard =
                new frmApplicantDashboard();

            dashboard.Show();

            this.Hide();
        }

        private void btnOpenProfile_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            frmMyProfile profile = new frmMyProfile(email);
            profile.ShowDialog();
        }

        private void btnTestDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    MessageBox.Show(
                        "Database Connected Successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT COUNT(*) FROM applicants";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    int count =
                        Convert.ToInt32(cmd.ExecuteScalar());

                    MessageBox.Show(
                        "Applicants Count: " + count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
