using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void txtNewPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            if (newPass != confirm)
            {
                MessageBox.Show("New passwords do not match.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string checkQuery = @"
                SELECT password
                FROM applicants
                WHERE applicant_id = @id";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id",
                        SessionManager.CurrentApplicant.ApplicantId);

                    object dbPassword = checkCmd.ExecuteScalar();

                    if (dbPassword == null || dbPassword.ToString() != current)
                    {
                        MessageBox.Show("Current password is incorrect.");
                        return;
                    }

                    string updateQuery = @"
                UPDATE applicants
                SET password = @new
                WHERE applicant_id = @id";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@new", newPass);
                    updateCmd.Parameters.AddWithValue("@id",
                        SessionManager.CurrentApplicant.ApplicantId);

                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Password updated successfully.");

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
