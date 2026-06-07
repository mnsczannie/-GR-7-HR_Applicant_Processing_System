using HRApplicantSystem.Forms.Applicant;
using HRApplicantSystem.Helpers;
using System;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseHelper.LoadConfig(
                "Database/db_config.ini");

            // Temporarily open a blank form until
            // frmApplicantLogin is created
            Application.Run(new frmApplicantLogin());
        }
    }
}