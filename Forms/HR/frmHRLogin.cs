using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Helpers;
using HRApplicantSystem.Models;
using HRApplicantSystem.Forms.Applicant;

namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRLogin : Form
    {
        public frmHRLogin()
        {
            InitializeComponent();
            UITheme.Apply(this);
        }

        private void frmHRLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT user_id, full_name, email, password, role FROM users WHERE email = @Email AND is_active = 1",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string storedHash = dr["password"].ToString();
                                if (BCrypt.Net.BCrypt.Verify(txtPassword.Text.Trim(), storedHash))
                                {
                                    SessionManager.Login(new User
                                    {
                                        UserId = Convert.ToInt32(dr["user_id"]),
                                        FullName = dr["full_name"] == DBNull.Value ? "" : dr["full_name"].ToString(),
                                        Email = dr["email"].ToString(),
                                        Role = dr["role"].ToString(),
                                        IsActive = true
                                    });

                                    new frmHRDashboard().Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid email or password.", "Login Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtPassword.Clear();
                                    txtPassword.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid email or password.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '●';
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            new frmHRRegister().Show();
            this.Hide();
        }


        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }

        private void lblEmail_Click(object sender, EventArgs e) { }
        private void lblPassword_Click(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmApplicantLogin().Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }
    }
}