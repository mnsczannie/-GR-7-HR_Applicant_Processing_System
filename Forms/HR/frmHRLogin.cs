using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRLogin : Form
    {
        public frmHRLogin()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────
        private void frmHRLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        // ─────────────────────────────────────────────
        // LOGIN BUTTON
        // ─────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Basic validation
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

            // Query users table
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
                            // Load user into SessionManager
                            SessionManager.CurrentUser = new Models.SystemModels.User
                            {
                                UserId = Convert.ToInt32(reader["user_id"]),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                Email = reader["email"].ToString(),
                                Role = reader["role"].ToString()
                            };

                            // Open dashboard
                            var dashboard = new frmHRDashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password. Please try again.",
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

        // ─────────────────────────────────────────────
        // ALLOW PRESSING ENTER TO LOGIN
        // ─────────────────────────────────────────────
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }
    }
}
