using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmChangePassword : Form
    {
        private string currentUserEmail;

        public frmChangePassword(string userEmail)
        {
            InitializeComponent();
            currentUserEmail = userEmail;
            txtEmail.Text = userEmail;
            txtEmail.ReadOnly = true;
            UITheme.Apply(this);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCurrentPass.Text) ||
                string.IsNullOrWhiteSpace(txtNewPass.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("New Password does not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPass.TextLength < 5)
            {
                MessageBox.Show("The new password should be at least 5 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCurrentPass.Text == txtNewPass.Text)
            {
                MessageBox.Show("Password is the same. Re-enter new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand checkCmd = new SqlCommand(
                        "SELECT password FROM applicants WHERE email = @Email", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", currentUserEmail);
                        object result = checkCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!BCrypt.Net.BCrypt.Verify(txtCurrentPass.Text, result.ToString()))
                        {
                            MessageBox.Show("Current Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    using (SqlCommand updateCmd = new SqlCommand(
                        "UPDATE applicants SET password = @NewPass WHERE email = @Email", conn))
                    {
                        updateCmd.Parameters.AddWithValue("@NewPass", BCrypt.Net.BCrypt.HashPassword(txtNewPass.Text));
                        updateCmd.Parameters.AddWithValue("@Email", currentUserEmail);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Password Changed Successfully!");
                AuditLogger.LogActionByEmail(currentUserEmail, "Changed password", "applicants");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            char ch = chkShowPass.Checked ? '\0' : '•';
            txtCurrentPass.PasswordChar = ch;
            txtNewPass.PasswordChar = ch;
            txtConfirmPass.PasswordChar = ch;
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCurrentPass_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}