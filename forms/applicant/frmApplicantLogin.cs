using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmApplicantLogin : Form
    {
        public frmApplicantLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            frmApplicantDashboard dashboard = new frmApplicantDashboard(email);
            dashboard.Show();

            this.Close();
        }

        private void btnOpenProfile_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            frmMyProfile profile = new frmMyProfile();
            profile.ShowDialog();
        }
    }
}
