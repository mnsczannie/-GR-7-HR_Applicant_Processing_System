using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRLogin : Form
    {
        private int _failedAttempts = 0;
        private const int MaxAttempts = 3;

        public frmHRLogin()
        {
            InitializeComponent();
        }

        // Set initial focus to email field when form loads
        private void frmHRLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        // Handle login button click event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your email and password.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT user_id, first_name, last_name, email, role
                FROM   users
                WHERE  email    = @Email
                  AND  password = @Password
                  AND  is_active = 1";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _failedAttempts = 0;

                            SessionManager.CurrentUser = new Models.SystemModels.User
                            {
                                UserId = Convert.ToInt32(reader["user_id"]),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                Email = reader["email"].ToString(),
                                Role = reader["role"].ToString()
                            };

                            var dashboard = new frmHRDashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            _failedAttempts++;
                            int remaining = MaxAttempts - _failedAttempts;

                            if (_failedAttempts >= MaxAttempts)
                            {
                                MessageBox.Show("Too many failed login attempts. Please contact your administrator.",
                                                "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                btnLogin.Enabled = false;
                                return;
                            }

                            MessageBox.Show($"Invalid email or password. You have {remaining} attempt(s) remaining.",
                                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to connect to the database:\n" + ex.Message,
                                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Allow pressing Enter key to trigger login
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        // Allow pressing Enter key in email field to move focus to password field
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }
    }
}
