using HRApplicantSystem.Forms.Applicant;
using HRApplicantSystem.Helpers;
using HRApplicantSystem.Forms.HR;
using System;
using System.Windows.Forms;
using BCrypt.Net;


namespace HRApplicantSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseHelper.LoadConfig("Database/db_config.ini");
            Application.Run(new frmApplicantLogin());
        }
    }
}
