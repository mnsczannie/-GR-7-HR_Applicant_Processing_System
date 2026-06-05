namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmMyProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEmailDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmailDisplay
            // 
            this.lblEmailDisplay.AutoSize = true;
            this.lblEmailDisplay.Location = new System.Drawing.Point(61, 13);
            this.lblEmailDisplay.Name = "lblEmailDisplay";
            this.lblEmailDisplay.Size = new System.Drawing.Size(87, 20);
            this.lblEmailDisplay.TabIndex = 0;
            this.lblEmailDisplay.Text = "Email Here";
            // 
            // frmMyProfile
            // 
            this.ClientSize = new System.Drawing.Size(608, 455);
            this.Controls.Add(this.lblEmailDisplay);
            this.Name = "frmMyProfile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

     
        private System.Windows.Forms.Label lblEmailDisplay;
    }
}