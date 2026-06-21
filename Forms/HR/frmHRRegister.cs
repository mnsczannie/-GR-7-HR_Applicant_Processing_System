using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRRegister : Form
    {
        public frmHRRegister()
        {
            InitializeComponent();
        }

        private void frmHRRegister_Load(object sender, EventArgs e)
        {
            cboRole.Items.Clear();
            cboRole.Items.Add("hr_staff");
            cboRole.Items.Add("hr_manager");
            cboRole.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;
            string role = cboRole.SelectedItem?.ToString() ?? "hr_staff";

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email)
                || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirm))
            { MessageBox.Show("Please fill in all fields."); return; }

            if (!ValidationHelper.IsEmailValid(email))
            { MessageBox.Show("Please enter a valid email address."); return; }

            if (!ValidationHelper.IsPasswordStrong(pass))
            { MessageBox.Show("Password must be at least 6 characters."); return; }

            if (pass != confirm)
            { MessageBox.Show("Passwords do not match."); return; }

            if (ValidationHelper.IsEmailTaken(email))
            { MessageBox.Show("This email is already registered."); return; }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        @"INSERT INTO users (full_name, email, password, role, is_active, created_at)
                          VALUES (@name, @email, @pass, @role, 0, GETDATE())", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", fullName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", BCrypt.Net.BCrypt.HashPassword(pass));
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Registration submitted! An administrator must activate your account " +
                    "before you can log in. You will not be able to sign in until then.",
                    "Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);

                new frmHRLogin().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new frmHRLogin().Show();
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char c = chkShowPassword.Checked ? '\0' : '\u25CF';
            txtPassword.PasswordChar = c;
            txtConfirmPassword.PasswordChar = c;
        }
    }
}
