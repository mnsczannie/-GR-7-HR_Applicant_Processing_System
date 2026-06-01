using System;
using System.Windows.Forms;
using HRApplicantSystem.Helpers;

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
            Application.Run(new Form());
        }
    }
}