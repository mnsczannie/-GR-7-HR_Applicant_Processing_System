using HRApplicantSystem.Forms.Applicant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HRApplicantSystem
{
    public partial class frmApplicantDashboard : Form
    {
        private string _email;

        public frmApplicantDashboard()
        {
            InitializeComponent();
        }

        public frmApplicantDashboard(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void frmApplicantDashboard_Load(object sender, EventArgs e)
        {
            // lblEmailDisplay.Text = _email;
        }

        private void btnOpenProfile_Click(object sender, EventArgs e)
        {
            frmMyProfile profile =
     new frmMyProfile(_email);

            profile.ShowDialog();

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }

}
