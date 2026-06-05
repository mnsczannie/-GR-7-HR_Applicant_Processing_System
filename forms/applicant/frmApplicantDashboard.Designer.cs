namespace HRApplicantSystem
{
    partial class frmApplicantDashboard
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
            this.btnOpenProfile = new System.Windows.Forms.Button();
            this.lblEmailDisplay = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenProfile
            // 
            this.btnOpenProfile.Location = new System.Drawing.Point(27, 60);
            this.btnOpenProfile.Name = "btnOpenProfile";
            this.btnOpenProfile.Size = new System.Drawing.Size(125, 30);
            this.btnOpenProfile.TabIndex = 1;
            this.btnOpenProfile.Text = "Open Profile";
            this.btnOpenProfile.UseVisualStyleBackColor = true;
            this.btnOpenProfile.Click += new System.EventHandler(this.btnOpenProfile_Click);
            // 
            // lblEmailDisplay
            // 
            this.lblEmailDisplay.AutoSize = true;
            this.lblEmailDisplay.Location = new System.Drawing.Point(37, 23);
            this.lblEmailDisplay.Name = "lblEmailDisplay";
            this.lblEmailDisplay.Size = new System.Drawing.Size(87, 20);
            this.lblEmailDisplay.TabIndex = 2;
            this.lblEmailDisplay.Text = "Email Here";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(235, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(158, 20);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Applicant Dashboard";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // frmApplicantDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmailDisplay);
            this.Controls.Add(this.btnOpenProfile);
            this.Name = "frmApplicantDashboard";
            this.Text = "frmApplicantDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenProfile;
        private System.Windows.Forms.Label lblEmailDisplay;
        private System.Windows.Forms.Label lblTitle;
    }
}