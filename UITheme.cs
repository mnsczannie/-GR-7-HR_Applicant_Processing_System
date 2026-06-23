using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public static class UITheme
    {
        public static void Apply(Form form)
        {
            form.ClientSize = new Size(1386, 788);
            form.BackColor = Color.Ivory;
        }
    }
}