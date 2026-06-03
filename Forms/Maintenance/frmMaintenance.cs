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

            string currentRole = SessionManager.CurrentRole;
            if (currentRole != "admin")
            {
                MessageBox.Show("Access Denied: You do not have administrator permissions to access the Maintenance Hub.",
                                "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }
        }

    }
}
