using System;
using System.Windows.Forms;
using HRApplicantSystem.Helpers; // This connects to your team's SessionManager

namespace HRApplicantSystem.Forms.Maintenance
{
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            // 1. Leave this line alone! It builds your UI elements.
            InitializeComponent();

            // 2. Add your Phase 1 security check right here:
            string currentRole = SessionManager.CurrentRole;
            if (currentRole != "admin")
            {
                MessageBox.Show("Access Denied: You do not have administrator permissions to access the Maintenance Hub.",
                                "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }
        }

        // 3. This is where you will add your button click events later!
    }
}