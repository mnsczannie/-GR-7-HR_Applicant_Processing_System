using System;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
            UITheme.Apply(this);
        }

        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            string role = SessionManager.CurrentRole;
            if (role != "admin")
            {
                MessageBox.Show("Access denied.");
                this.Close();
                return;
            }
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            new frmDepartments().ShowDialog();
        }

        private void btnPositions_Click(object sender, EventArgs e)
        {
            new frmPositions().ShowDialog();
        }

        private void btnEmploymentTypes_Click(object sender, EventArgs e)
        {
            new frmEmploymentTypes().ShowDialog();
        }

        private void btnRequirementTypes_Click(object sender, EventArgs e)
        {
            new frmRequirementTypes().ShowDialog();
        }

        private void btnInterviewTypes_Click(object sender, EventArgs e)
        {
            new frmInterviewTypes().ShowDialog();
        }

        private void btnAssessmentTypes_Click(object sender, EventArgs e)
        {
            new frmAssessmentTypes().ShowDialog();
        }

     

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUserManagement_Click_1(object sender, EventArgs e)
        {
            new frmUserManagement().ShowDialog();
        }
    }
}