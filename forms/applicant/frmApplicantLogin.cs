using HRApplicantSystem.Helpers;
using HRApplicantSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


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
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT applicant_id, full_name, email
                FROM applicants
                WHERE email = @email
                AND password = @password
                AND is_active = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Models.Applicant applicant = new Models.Applicant
                        {
                            ApplicantId = Convert.ToInt32(reader["applicant_id"]),
                            FullName = reader["full_name"].ToString(),
                            Email = reader["email"].ToString()
                        };

                        SessionManager.LoginApplicant(applicant);

                        frmApplicantDashboard dashboard =
                            new frmApplicantDashboard();

                        dashboard.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnOpenProfile_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            frmMyProfile profile = new frmMyProfile();
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

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
            INSERT INTO applicants
            (full_name, email, password)
            VALUES
            (@name, @email, @password)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    string email =
                        "test" + DateTime.Now.Ticks + "@email.com";

                    cmd.Parameters.AddWithValue("@name",
                        "Mascarinas Test");

                    cmd.Parameters.AddWithValue("@email",
                        email);

                    cmd.Parameters.AddWithValue("@password",
                        "123456");

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Saved!\nEmail: " + email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmApplicantRegister register =
        new frmApplicantRegister();

            register.Show();

            this.Hide();
        }
    }

}
