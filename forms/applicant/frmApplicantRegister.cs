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
    public partial class frmApplicantRegister : Form
    {
        public frmApplicantRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Check duplicate email
                    string checkQuery =
                        "SELECT COUNT(*) FROM applicants WHERE email = @email";

                    SqlCommand checkCmd =
                        new SqlCommand(checkQuery, conn);

                    checkCmd.Parameters.AddWithValue("@email", email);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Email already exists.");
                        return;
                    }

                    // Insert applicant
                    string insertQuery = @"
                INSERT INTO applicants
                (full_name, email, password)
                VALUES
                (@fullName, @email, @password)";

                    SqlCommand insertCmd =
                        new SqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue("@fullName", fullName);
                    insertCmd.Parameters.AddWithValue("@email", email);
                    insertCmd.Parameters.AddWithValue("@password", password);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Registration successful.");

                    frmApplicantLogin login =
                        new frmApplicantLogin();

                    login.Show();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
