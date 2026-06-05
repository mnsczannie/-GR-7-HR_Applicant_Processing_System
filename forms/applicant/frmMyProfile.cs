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
    public partial class frmMyProfile : Form
    {
        private string _email;

        public frmMyProfile(string email)
        {
            InitializeComponent();

            _email = email;

            lblEmailDisplay.Text = _email;
        }

        public frmMyProfile()
        {
            InitializeComponent();
        }
    }

}