using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmMyProfile : Form
    {
        private string userEmail;
        private string originalSnapshot;

        public frmMyProfile(string email)
        {
            InitializeComponent();
            userEmail = email;
            UITheme.Apply(this);
        }

        private void frmMyProfile_Load_1(object sender, EventArgs e)
        {
            dtpBirthday.MaxDate = DateTime.Today;
            LoadProfileData();
            SetReadOnly(true);
            btnSave.Enabled = false;
            originalSnapshot = BuildSnapshot();
        }

        private void LoadProfileData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT full_name, birthdate, address, city, province, zip_code,
                           phone, email, gender,
                           school, degree, year_grad, skills,
                           company, position, duration
                          FROM applicants WHERE email = @Email", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", userEmail);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string fullName = dr["full_name"] == DBNull.Value ? "" : dr["full_name"].ToString();
                                string[] nameParts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                if (nameParts.Length == 1)
                                {
                                    txtFN.Text = nameParts[0];
                                    txtMI.Text = "";
                                    txtLN.Text = "";
                                }
                                else if (nameParts.Length == 2)
                                {
                                    txtFN.Text = nameParts[0];
                                    txtMI.Text = "";
                                    txtLN.Text = nameParts[1];
                                }
                                else if (nameParts.Length >= 3)
                                {
                                    txtFN.Text = nameParts[0];
                                    txtMI.Text = nameParts[1];
                                    txtLN.Text = string.Join(" ", nameParts, 2, nameParts.Length - 2);
                                }

                                if (dr["birthdate"] != DBNull.Value)
                                    dtpBirthday.Value = Convert.ToDateTime(dr["birthdate"]);

                                txtAddress.Text = dr["address"] == DBNull.Value ? "" : dr["address"].ToString();
                                txtCity.Text = dr["city"] == DBNull.Value ? "" : dr["city"].ToString();
                                txtProvince.Text = dr["province"] == DBNull.Value ? "" : dr["province"].ToString();
                                txtZip.Text = dr["zip_code"] == DBNull.Value ? "" : dr["zip_code"].ToString();

                                txtPhone.Text = dr["phone"] == DBNull.Value ? "" : dr["phone"].ToString();
                                txtEmail.Text = dr["email"] == DBNull.Value ? "" : dr["email"].ToString();

                                txtEducation.Text = dr["school"] == DBNull.Value ? "" : dr["school"].ToString();
                                txtDegree.Text = dr["degree"] == DBNull.Value ? "" : dr["degree"].ToString();
                                txtYearGrad.Text = dr["year_grad"] == DBNull.Value ? "" : dr["year_grad"].ToString();

                                txtSkills.Text = dr["skills"] == DBNull.Value ? "" : dr["skills"].ToString();

                                txtWorkExp.Text = dr["company"] == DBNull.Value ? "" : dr["company"].ToString();
                                txtPosition.Text = dr["position"] == DBNull.Value ? "" : dr["position"].ToString();
                                txtDuration.Text = dr["duration"] == DBNull.Value ? "" : dr["duration"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private string BuildSnapshot()
        {
            return string.Join("|", new[]
            {
                txtFN.Text.Trim(),
                txtMI.Text.Trim(),
                txtLN.Text.Trim(),
                dtpBirthday.Value.Date.ToString("yyyy-MM-dd"),
                txtAddress.Text.Trim(),
                txtCity.Text.Trim(),
                txtProvince.Text.Trim(),
                txtZip.Text.Trim(),
                txtPhone.Text.Trim(),
                txtEducation.Text.Trim(),
                txtDegree.Text.Trim(),
                txtYearGrad.Text.Trim(),
                txtSkills.Text.Trim(),
                txtWorkExp.Text.Trim(),
                txtPosition.Text.Trim(),
                txtDuration.Text.Trim()
            });
        }

        private void SetReadOnly(bool isReadOnly)
        {
            txtFN.ReadOnly = isReadOnly;
            txtMI.ReadOnly = isReadOnly;
            txtLN.ReadOnly = isReadOnly;
            dtpBirthday.Enabled = !isReadOnly;

            txtAddress.ReadOnly = isReadOnly;
            txtCity.ReadOnly = isReadOnly;
            txtProvince.ReadOnly = isReadOnly;
            txtZip.ReadOnly = isReadOnly;

            txtPhone.ReadOnly = isReadOnly;

            txtEducation.ReadOnly = isReadOnly;
            txtDegree.ReadOnly = isReadOnly;
            txtYearGrad.ReadOnly = isReadOnly;

            txtSkills.ReadOnly = isReadOnly;

            txtWorkExp.ReadOnly = isReadOnly;
            txtPosition.ReadOnly = isReadOnly;
            txtDuration.ReadOnly = isReadOnly;

            Color c = isReadOnly ? Color.LightGray : Color.White;
            txtFN.BackColor = c;
            txtMI.BackColor = c;
            txtLN.BackColor = c;
            txtAddress.BackColor = c;
            txtCity.BackColor = c;
            txtProvince.BackColor = c;
            txtZip.BackColor = c;
            txtPhone.BackColor = c;
            txtEducation.BackColor = c;
            txtDegree.BackColor = c;
            txtYearGrad.BackColor = c;
            txtSkills.BackColor = c;
            txtWorkExp.BackColor = c;
            txtPosition.BackColor = c;
            txtDuration.BackColor = c;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
            btnSave.Enabled = true;
            MessageBox.Show("You can now edit your profile. Click Save when done.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFN.Text) || string.IsNullOrWhiteSpace(txtLN.Text))
            {
                MessageBox.Show("First Name and Last Name are required.");
                return;
            }

            if (BuildSnapshot() == originalSnapshot)
            {
                MessageBox.Show("No changes committed!", "Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetReadOnly(true);
                btnSave.Enabled = false;
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"UPDATE applicants SET
                            full_name = @FullName,
                            birthdate = @Bday,
                            address   = @Address,
                            city      = @City,
                            province  = @Province,
                            zip_code  = @Zip,
                            phone     = @Phone,
                            school    = @School,
                            degree    = @Degree,
                            year_grad = @YearGrad,
                            skills    = @Skills,
                            company   = @Company,
                            position  = @Position,
                            duration  = @Duration
                          WHERE email = @OriginalEmail", conn))
                    {
                        string mi = txtMI.Text.Trim();
                        string fullName = string.IsNullOrEmpty(mi)
                            ? $"{txtFN.Text.Trim()} {txtLN.Text.Trim()}"
                            : $"{txtFN.Text.Trim()} {mi} {txtLN.Text.Trim()}";

                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Bday", dtpBirthday.Value.Date);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                        cmd.Parameters.AddWithValue("@Province", txtProvince.Text.Trim());
                        cmd.Parameters.AddWithValue("@Zip", txtZip.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@School", txtEducation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Degree", txtDegree.Text.Trim());
                        cmd.Parameters.AddWithValue("@YearGrad", txtYearGrad.Text.Trim());
                        cmd.Parameters.AddWithValue("@Skills", txtSkills.Text.Trim());
                        cmd.Parameters.AddWithValue("@Company", txtWorkExp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Position", txtPosition.Text.Trim());
                        cmd.Parameters.AddWithValue("@Duration", txtDuration.Text.Trim());
                        cmd.Parameters.AddWithValue("@OriginalEmail", userEmail);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Profile Updated Successfully!");
                SetReadOnly(true);
                btnSave.Enabled = false;

                try { AuditLogger.LogActionByEmail(userEmail, "Updated profile", "applicants"); }
                catch { /* audit failure should not block the user */ }

                originalSnapshot = BuildSnapshot();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard = new frmApplicantDashboard(userEmail);
            dashboard.Show();
            this.Close();
        }

        private void btnDocs_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMyDocuments(userEmail))
            {
                frm.ShowDialog();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void lblFN_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMyDocuments(userEmail))
            {
                frm.ShowDialog();
            }
        }
    }
}