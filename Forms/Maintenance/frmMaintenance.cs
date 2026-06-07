using HRApplicantSystem.Helpers;
using System;
using System.Windows.Forms;
<<<<<<< HEAD
using HRApplicantSystem.Helpers;
=======
>>>>>>> 72d02a8 (finished phase 1 to 3)

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
            string currentRole = SessionManager.CurrentRole;
            if (currentRole != "admin")
=======
        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null || SessionManager.CurrentUser.Role != "admin")
>>>>>>> 72d02a8 (finished phase 1 to 3)
            {
                MessageBox.Show("Access Denied: This module requires administrative privileges.",
                                "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
                return;
            }
        }

<<<<<<< HEAD
=======

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            frmDepartments deptsForm = new frmDepartments();
            deptsForm.ShowDialog();
        }

        private void btnPositions_Click(object sender, EventArgs e)
        {
            frmPositions positionsForm = new frmPositions();
            positionsForm.ShowDialog();
        }

        private void btnEmploymentTypes_Click(object sender, EventArgs e)
        {
            frmEmploymentTypes empTypesForm = new frmEmploymentTypes();
            empTypesForm.ShowDialog();
        }

        private void btnRequirementTypes_Click(object sender, EventArgs e)
        {
            frmRequirementTypes reqTypesForm = new frmRequirementTypes();
            reqTypesForm.ShowDialog();
        }

        private void btnInterviewTypes_Click(object sender, EventArgs e)
        {
            frmInterviewTypes interviewForm = new frmInterviewTypes();
            interviewForm.ShowDialog();
        }

        private void btnAssessmentTypes_Click(object sender, EventArgs e)
        {
            frmAssessmentTypes assessmentForm = new frmAssessmentTypes();
            assessmentForm.ShowDialog();
        }
>>>>>>> 72d02a8 (finished phase 1 to 3)
    }
}
