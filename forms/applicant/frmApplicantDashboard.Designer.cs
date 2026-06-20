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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnOpenProfile = new System.Windows.Forms.Button();
            this.btnJobVacancies = new System.Windows.Forms.Button();
            this.btnMyApplication = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblAppStatus = new System.Windows.Forms.Label();
            this.pnlDocs = new System.Windows.Forms.Panel();
            this.lblMissingDocs = new System.Windows.Forms.Label();
            this.pnlInterview = new System.Windows.Forms.Panel();
            this.lblInterview = new System.Windows.Forms.Label();
            this.sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            this.dgvStatusHistory = new System.Windows.Forms.DataGridView();
            this.pnlStatus.SuspendLayout();
            this.pnlDocs.SuspendLayout();
            this.pnlInterview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(216, 21);
            this.lblWelcome.MaximumSize = new System.Drawing.Size(2000000, 100000);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(429, 54);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, {FullName}";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // btnOpenProfile
            // 
            this.btnOpenProfile.Location = new System.Drawing.Point(606, 85);
            this.btnOpenProfile.Name = "btnOpenProfile";
            this.btnOpenProfile.Size = new System.Drawing.Size(181, 51);
            this.btnOpenProfile.TabIndex = 1;
            this.btnOpenProfile.Text = "My Profile";
            this.btnOpenProfile.UseVisualStyleBackColor = true;
            this.btnOpenProfile.Click += new System.EventHandler(this.btnOpenProfile_Click);
            // 
            // btnJobVacancies
            // 
            this.btnJobVacancies.Location = new System.Drawing.Point(606, 160);
            this.btnJobVacancies.Name = "btnJobVacancies";
            this.btnJobVacancies.Size = new System.Drawing.Size(181, 49);
            this.btnJobVacancies.TabIndex = 2;
            this.btnJobVacancies.Text = "Job Vacancies";
            this.btnJobVacancies.UseVisualStyleBackColor = true;
            this.btnJobVacancies.Click += new System.EventHandler(this.btnJobVacancies_Click);
            // 
            // btnMyApplication
            // 
            this.btnMyApplication.Location = new System.Drawing.Point(606, 240);
            this.btnMyApplication.Name = "btnMyApplication";
            this.btnMyApplication.Size = new System.Drawing.Size(181, 50);
            this.btnMyApplication.TabIndex = 3;
            this.btnMyApplication.Text = "My Application";
            this.btnMyApplication.UseVisualStyleBackColor = true;
            this.btnMyApplication.Click += new System.EventHandler(this.btnMyApplication_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(606, 401);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(181, 50);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(606, 321);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(181, 50);
            this.btnChangePassword.TabIndex = 5;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlStatus.Controls.Add(this.lblAppStatus);
            this.pnlStatus.Location = new System.Drawing.Point(46, 85);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(478, 69);
            this.pnlStatus.TabIndex = 6;
            // 
            // lblAppStatus
            // 
            this.lblAppStatus.AutoSize = true;
            this.lblAppStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppStatus.Location = new System.Drawing.Point(152, 29);
            this.lblAppStatus.Name = "lblAppStatus";
            this.lblAppStatus.Size = new System.Drawing.Size(154, 22);
            this.lblAppStatus.TabIndex = 0;
            this.lblAppStatus.Text = "Application Status";
            this.lblAppStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // pnlDocs
            // 
            this.pnlDocs.Controls.Add(this.lblMissingDocs);
            this.pnlDocs.Location = new System.Drawing.Point(46, 160);
            this.pnlDocs.Name = "pnlDocs";
            this.pnlDocs.Size = new System.Drawing.Size(478, 73);
            this.pnlDocs.TabIndex = 7;
            // 
            // lblMissingDocs
            // 
            this.lblMissingDocs.AutoSize = true;
            this.lblMissingDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissingDocs.Location = new System.Drawing.Point(175, 27);
            this.lblMissingDocs.Name = "lblMissingDocs";
            this.lblMissingDocs.Size = new System.Drawing.Size(116, 22);
            this.lblMissingDocs.TabIndex = 0;
            this.lblMissingDocs.Text = "Missing Docs";
            this.lblMissingDocs.Click += new System.EventHandler(this.lblMissingDocs_Click);
            // 
            // pnlInterview
            // 
            this.pnlInterview.Controls.Add(this.lblInterview);
            this.pnlInterview.Location = new System.Drawing.Point(46, 239);
            this.pnlInterview.Name = "pnlInterview";
            this.pnlInterview.Size = new System.Drawing.Size(478, 66);
            this.pnlInterview.TabIndex = 8;
            // 
            // lblInterview
            // 
            this.lblInterview.AutoSize = true;
            this.lblInterview.Location = new System.Drawing.Point(152, 31);
            this.lblInterview.Name = "lblInterview";
            this.lblInterview.Size = new System.Drawing.Size(148, 20);
            this.lblInterview.TabIndex = 0;
            this.lblInterview.Text = "Upcoming Interview";
            // 
            // dgvStatusHistory
            // 
            this.dgvStatusHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatusHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusHistory.GridColor = System.Drawing.SystemColors.Control;
            this.dgvStatusHistory.Location = new System.Drawing.Point(46, 321);
            this.dgvStatusHistory.Name = "dgvStatusHistory";
            this.dgvStatusHistory.ReadOnly = true;
            this.dgvStatusHistory.RowHeadersWidth = 62;
            this.dgvStatusHistory.RowTemplate.Height = 28;
            this.dgvStatusHistory.Size = new System.Drawing.Size(478, 94);
            this.dgvStatusHistory.TabIndex = 9;
            // 
            // frmApplicantDashboard
            // 
            this.ClientSize = new System.Drawing.Size(842, 491);
            this.Controls.Add(this.dgvStatusHistory);
            this.Controls.Add(this.btnMyApplication);
            this.Controls.Add(this.pnlInterview);
            this.Controls.Add(this.pnlDocs);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnJobVacancies);
            this.Controls.Add(this.btnOpenProfile);
            this.Controls.Add(this.lblWelcome);
            this.Name = "frmApplicantDashboard";
            this.Load += new System.EventHandler(this.frmApplicantDashboard_Load);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlDocs.ResumeLayout(false);
            this.pnlDocs.PerformLayout();
            this.pnlInterview.ResumeLayout(false);
            this.pnlInterview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnOpenProfile;
        private System.Windows.Forms.Button btnJobVacancies;
        private System.Windows.Forms.Button btnMyApplication;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblAppStatus;
        private System.Windows.Forms.Panel pnlDocs;
        private System.Windows.Forms.Label lblMissingDocs;
        private System.Windows.Forms.Panel pnlInterview;
        private System.Windows.Forms.Label lblInterview;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Windows.Forms.DataGridView dgvStatusHistory;
    }

}