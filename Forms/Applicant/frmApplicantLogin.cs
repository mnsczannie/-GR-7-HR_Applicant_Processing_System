using HRApplicantSystem.Helpers;
using HRApplicantSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmApplicantLogin : Form
    {
        public frmApplicantLogin()
        {
            InitializeComponent();
        }

        private void frmApplicantLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Enter email and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string cleanedEmail = txtEmail.Text.Trim();
                string passwordInput = txtPassword.Text.Trim();

                int applicantId = 0;
                string name = string.Empty;
                string hash = string.Empty;
                bool isActive = false;
                bool userFound = false;

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT applicant_id, full_name, password, is_active FROM applicants WHERE email=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", cleanedEmail);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                userFound = true;
                                applicantId = Convert.ToInt32(dr["applicant_id"]);
                                name = dr["full_name"].ToString();
                                hash = dr["password"].ToString();
                                isActive = dr["is_active"] != DBNull.Value && Convert.ToBoolean(dr["is_active"]);
                            }
                        }
                    }
                }

                if (!userFound) { ShowFail(); return; }
                if (!isActive)
                {
                    MessageBox.Show("This account is inactive.", "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool ok = BCrypt.Net.BCrypt.Verify(passwordInput, hash);
                if (!ok) { ShowFail(); return; }

                SessionManager.LoginApplicant(new HRApplicantSystem.Models.Applicant
                {
                    ApplicantId = applicantId,
                    FullName = name,
                    Email = cleanedEmail
                });

                AuditLogger.LogAction(applicantId, "Logged in", "applicants");

                frmApplicantDashboard dashboard = new frmApplicantDashboard(cleanedEmail);
                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowFail()
        {
            MessageBox.Show("Invalid email or password.", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = CheckbxShowPas.Checked ? '\0' : '●';
        }

        private void lblCreateAcc_Click(object sender, EventArgs e)
        {
            new frmApplicantRegister().Show();
            this.Hide();
        }

        private void linklblFgtPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword cp = new frmChangePassword(txtEmail.Text);
            cp.Show();
            this.Hide();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}