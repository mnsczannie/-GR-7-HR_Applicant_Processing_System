using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmApplicantRegister : Form
    {
        public frmApplicantRegister()
        {
            InitializeComponent();
            UITheme.Apply(this);
        }

        private void frmApplicantRegister_Load_1(object sender, EventArgs e)
        {
            dtpBirthday.MaxDate = DateTime.Today;

            cboCountry.Items.Add("Philippines (+63)");
            cboCountry.Items.Add("United States (+1)");
            cboCountry.Items.Add("Australia (+61)");
            cboCountry.Items.Add("Japan (+81)");
            cboCountry.Items.Add("Singapore (+65)");
            cboCountry.Items.Add("Canada (+1)");
            cboCountry.Items.Add("United Kingdom (+44)");
            cboCountry.SelectedIndex = 0;

            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");
            cboGender.Items.Add("Other");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!chkAgree.Checked)
            {
                MessageBox.Show("Please check the box if you understand the terms.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFN.Text))
            {
                MessageBox.Show("Please enter your first name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLN.Text))
            {
                MessageBox.Show("Please enter your last name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            if (!ValidationHelper.IsEmailValid(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return;
            }

            if (cboGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your gender.");
                return;
            }

            if (dtpBirthday.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Please enter a valid birthdate.");
                return;
            }

            string mi = txtMI.Text.Trim();
            string fullName = string.IsNullOrEmpty(mi)
                ? $"{txtFN.Text.Trim()} {txtLN.Text.Trim()}"
                : $"{txtFN.Text.Trim()} {mi} {txtLN.Text.Trim()}";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM applicants WHERE email = @Email", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Email is already registered!");
                            return;
                        }
                    }

                    using (SqlCommand insertCmd = new SqlCommand(
                        @"INSERT INTO applicants 
                          (full_name, email, password, phone, birthdate, gender) 
                          VALUES 
                          (@FullName, @Email, @Password, @Phone, @Bday, @Gender)",
                        conn))
                    {
                        insertCmd.Parameters.AddWithValue("@FullName", fullName);
                        insertCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text.Trim()));
                        insertCmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@Bday", dtpBirthday.Value.Date);
                        insertCmd.Parameters.AddWithValue("@Gender", cboGender.Text.Trim());
                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration Successful! Please complete your profile.");
                frmApplicantDashboard dashboard = new frmApplicantDashboard(txtEmail.Text.Trim());
                dashboard.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}