namespace HRApplicantSystem.Forms.HR
{
    partial class frmApplicantReview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.btnViewDocuments = new System.Windows.Forms.Button();
            this.btnLockForReview = new System.Windows.Forms.Button();
            this.btnOpenScreening = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(12, 15);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(65, 12);
            this.txtSearch.Size = new System.Drawing.Size(180, 20);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(258, 15);
            this.lblStatus.Text = "Status:";

            // cboStatus — updated to match PDF required status flow
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(305, 12);
            this.cboStatus.Size = new System.Drawing.Size(150, 21);
            this.cboStatus.Items.AddRange(new object[] {
                "submitted",
                "under_review",
                "shortlisted",
                "for_interview",
                "for_assessment",
                "for_final_review",
                "accepted",
                "rejected",
                "withdrawn"
            });
            this.cboStatus.SelectedIndex = 0;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);

            // lblDepartment
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.Location = new System.Drawing.Point(465, 15);
            this.lblDepartment.Text = "Department:";

            // cboDepartment
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Location = new System.Drawing.Point(543, 12);
            this.cboDepartment.Size = new System.Drawing.Size(145, 21);
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);

            // dgvApplications
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplications.Location = new System.Drawing.Point(12, 45);
            this.dgvApplications.MultiSelect = false;
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.RowHeadersVisible = false;
            this.dgvApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplications.Size = new System.Drawing.Size(676, 320);

            // btnViewProfile
            this.btnViewProfile.Location = new System.Drawing.Point(12, 378);
            this.btnViewProfile.Size = new System.Drawing.Size(100, 30);
            this.btnViewProfile.Text = "View Profile";
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);

            // btnViewDocuments
            this.btnViewDocuments.Location = new System.Drawing.Point(120, 378);
            this.btnViewDocuments.Size = new System.Drawing.Size(110, 30);
            this.btnViewDocuments.Text = "View Documents";
            this.btnViewDocuments.Click += new System.EventHandler(this.btnViewDocuments_Click);

            // btnLockForReview
            this.btnLockForReview.Location = new System.Drawing.Point(238, 378);
            this.btnLockForReview.Size = new System.Drawing.Size(110, 30);
            this.btnLockForReview.Text = "Lock for Review";
            this.btnLockForReview.Click += new System.EventHandler(this.btnLockForReview_Click);

            // btnOpenScreening
            this.btnOpenScreening.Location = new System.Drawing.Point(356, 378);
            this.btnOpenScreening.Size = new System.Drawing.Size(110, 30);
            this.btnOpenScreening.Text = "Open Screening";
            this.btnOpenScreening.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenScreening.ForeColor = System.Drawing.Color.White;
            this.btnOpenScreening.Click += new System.EventHandler(this.btnOpenScreening_Click);

            // frmApplicantReview
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 425);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.dgvApplications);
            this.Controls.Add(this.btnViewProfile);
            this.Controls.Add(this.btnViewDocuments);
            this.Controls.Add(this.btnLockForReview);
            this.Controls.Add(this.btnOpenScreening);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmApplicantReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applicant Review";
            this.Load += new System.EventHandler(this.frmApplicantReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnViewDocuments;
        private System.Windows.Forms.Button btnLockForReview;
        private System.Windows.Forms.Button btnOpenScreening;
    }
}
