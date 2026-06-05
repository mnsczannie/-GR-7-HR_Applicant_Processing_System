using HRApplicantSystem.Helpers;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmMyProfile : Form
    {
        public frmMyProfile()
        {
            InitializeComponent();
        }

        private void frmMyProfile_Load(object sender, EventArgs e)
        {
            if (SessionManager.CurrentApplicant != null)
            {
                lblEmailDisplay.Text =
                    "Email: " + SessionManager.CurrentApplicant.Email;
                txtFullName.Text =
    SessionManager.CurrentApplicant.FullName;

                txtEmail.Text =
                    SessionManager.CurrentApplicant.Email;
            }
            else
            {
                lblEmailDisplay.Text = "No user logged in";
            }
            LoadProfile();

        }
        private void LoadProfile()
        {
            int applicantId =
                SessionManager.CurrentApplicant.ApplicantId;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT *
        FROM applicants
        WHERE applicant_id = @id";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id",
                    applicantId);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text =
                        reader["full_name"].ToString();

                    txtEmail.Text =
                        reader["email"].ToString();

                    txtPhone.Text =
                        reader["phone"].ToString();

                    txtAddress.Text =
                        reader["address"].ToString();

                    txtCity.Text =
                        reader["city"].ToString();

                    txtProvince.Text =
                        reader["province"].ToString();

                    txtZipCode.Text =
                        reader["zip_code"].ToString();

                    txtSchool.Text =
                        reader["school"].ToString();

                    txtDegree.Text =
                        reader["degree"].ToString();

                    txtYearGrad.Text =
                        reader["year_grad"].ToString();

                    txtSkills.Text =
                        reader["skills"].ToString();

                    txtCompany.Text =
                        reader["company"].ToString();

                    txtPosition.Text =
                        reader["position"].ToString();

                    txtDuration.Text =
                        reader["duration"].ToString();

                    cboGender.Text =
                        reader["gender"].ToString();

                    if (reader["birthdate"] != DBNull.Value)
                    {
                        dtpBirthdate.Value =
                            Convert.ToDateTime(
                                reader["birthdate"]);
                    }
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtSkills_TextChanged(object sender, EventArgs e)
        {

        }
    }
}