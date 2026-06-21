using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace HRApplicantSystem.Forms.HR
{
    public partial class frmHRApplicantProfile : Form
    {
        private readonly string _email;
        public frmHRApplicantProfile(string email)
        { InitializeComponent(); _email = email; }


        public frmHRApplicantProfile()
        {
            InitializeComponent();
            _email = string.Empty;

        }


        private void frmHRApplicantProfile_Load(object s, EventArgs e) => LoadProfile();

        private void LoadProfile()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        @"SELECT full_name,email,phone,gender,birthdate,
                             address,city,province,zip_code,
                             school,degree,year_grad,skills,
                             company,position,duration,is_active,created_at
                      FROM applicants WHERE email=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", _email);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (!dr.Read()) { MessageBox.Show("Applicant not found."); this.Close(); return; }
                            this.Text = $"Profile — {dr["full_name"]}";
                            lblFullName.Text = V(dr, "full_name");
                            lblEmail.Text = V(dr, "email");
                            lblPhone.Text = V(dr, "phone");
                            lblGender.Text = V(dr, "gender");
                            lblBirthdate.Text = dr["birthdate"] == DBNull.Value ? "—"
                                : Convert.ToDateTime(dr["birthdate"]).ToString("MMMM dd, yyyy");
                            lblAddress.Text = V(dr, "address");
                            lblCity.Text = V(dr, "city");
                            lblProvince.Text = V(dr, "province");
                            lblZip.Text = V(dr, "zip_code");
                            lblSchool.Text = V(dr, "school");
                            lblDegree.Text = V(dr, "degree");
                            lblYearGrad.Text = V(dr, "year_grad");
                            lblSkills.Text = V(dr, "skills");
                            lblCompany.Text = V(dr, "company");
                            lblPosition.Text = V(dr, "position");
                            lblDuration.Text = V(dr, "duration");
                            bool active = dr["is_active"] != DBNull.Value && Convert.ToBoolean(dr["is_active"]);
                            lblStatus.Text = active ? "Active" : "Inactive";
                            lblStatus.ForeColor = active ? Color.Green : Color.Red;
                            lblCreatedAt.Text = dr["created_at"] == DBNull.Value ? "—"
                                : Convert.ToDateTime(dr["created_at"]).ToString("MM/dd/yyyy");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private static string V(SqlDataReader dr, string col)
            => dr[col] == DBNull.Value || string.IsNullOrWhiteSpace(dr[col].ToString()) ? "—" : dr[col].ToString();

        private void btnViewDocuments_Click(object s, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT applicant_id FROM applicants WHERE email=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", _email);
                        object r = cmd.ExecuteScalar();
                        if (r != null) new frmHRViewDocuments(Convert.ToInt32(r)).ShowDialog();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void btnClose_Click(object s, EventArgs e) => this.Close();

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantList dashboard = new frmApplicantList();
            dashboard.Show();
            this.Close();
        }
    }
}