namespace HRApplicantSystem.Forms.HR
{
    partial class frmScreening
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.GroupBox groupBox1; // Applicant Details
        private System.Windows.Forms.Label lblApplicantNameCaption;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblJobAppliedCaption;
        private System.Windows.Forms.Label lblJobApplied;

        private System.Windows.Forms.GroupBox groupBox2; // Screening Result
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnQualified;
        private System.Windows.Forms.Button btnNotQualified;

        private System.Windows.Forms.GroupBox groupBox3; // Remarks
        private System.Windows.Forms.Label lblRemarksCaption;
        private System.Windows.Forms.TextBox txtRemarks;

        private System.Windows.Forms.Button btnNext;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblApplicantNameCaption = new System.Windows.Forms.Label();
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.lblJobAppliedCaption = new System.Windows.Forms.Label();
            this.lblJobApplied = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnQualified = new System.Windows.Forms.Button();
            this.btnNotQualified = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRemarksCaption = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.ViewDocuments = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSelectedApplicant = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 31);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Application Screening";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lblSubtitle.Location = new System.Drawing.Point(31, 59);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(258, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Review applicant details and mark qualification";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblApplicantNameCaption);
            this.groupBox1.Controls.Add(this.lblApplicantName);
            this.groupBox1.Controls.Add(this.lblJobAppliedCaption);
            this.groupBox1.Controls.Add(this.lblJobApplied);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 88);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(315, 136);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applicant Details";
            // 
            // lblApplicantNameCaption
            // 
            this.lblApplicantNameCaption.AutoSize = true;
            this.lblApplicantNameCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApplicantNameCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblApplicantNameCaption.Location = new System.Drawing.Point(15, 28);
            this.lblApplicantNameCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicantNameCaption.Name = "lblApplicantNameCaption";
            this.lblApplicantNameCaption.Size = new System.Drawing.Size(48, 19);
            this.lblApplicantNameCaption.TabIndex = 0;
            this.lblApplicantNameCaption.Text = "Name:";
            // 
            // lblApplicantName
            // 
            this.lblApplicantName.AutoSize = true;
            this.lblApplicantName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblApplicantName.Location = new System.Drawing.Point(73, 28);
            this.lblApplicantName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicantName.Name = "lblApplicantName";
            this.lblApplicantName.Size = new System.Drawing.Size(85, 19);
            this.lblApplicantName.TabIndex = 1;
            this.lblApplicantName.Text = "(Loading...)";
            // 
            // lblJobAppliedCaption
            // 
            this.lblJobAppliedCaption.AutoSize = true;
            this.lblJobAppliedCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblJobAppliedCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblJobAppliedCaption.Location = new System.Drawing.Point(15, 61);
            this.lblJobAppliedCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJobAppliedCaption.Name = "lblJobAppliedCaption";
            this.lblJobAppliedCaption.Size = new System.Drawing.Size(104, 19);
            this.lblJobAppliedCaption.TabIndex = 2;
            this.lblJobAppliedCaption.Text = "Job Applied for:";
            // 
            // lblJobApplied
            // 
            this.lblJobApplied.AutoSize = true;
            this.lblJobApplied.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblJobApplied.Location = new System.Drawing.Point(15, 95);
            this.lblJobApplied.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJobApplied.Name = "lblJobApplied";
            this.lblJobApplied.Size = new System.Drawing.Size(85, 19);
            this.lblJobApplied.TabIndex = 3;
            this.lblJobApplied.Text = "(Loading...)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.btnQualified);
            this.groupBox2.Controls.Add(this.btnNotQualified);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox2.Location = new System.Drawing.Point(360, 88);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(315, 136);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Screening Result";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStatus.Location = new System.Drawing.Point(15, 28);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(112, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status: Pending";
            // 
            // btnQualified
            // 
            this.btnQualified.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(122)))), ((int)(((byte)(60)))));
            this.btnQualified.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQualified.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQualified.ForeColor = System.Drawing.Color.White;
            this.btnQualified.Location = new System.Drawing.Point(15, 61);
            this.btnQualified.Margin = new System.Windows.Forms.Padding(2);
            this.btnQualified.Name = "btnQualified";
            this.btnQualified.Size = new System.Drawing.Size(112, 32);
            this.btnQualified.TabIndex = 1;
            this.btnQualified.Text = "Qualified";
            this.btnQualified.UseVisualStyleBackColor = false;
            this.btnQualified.Click += new System.EventHandler(this.btnQualified_Click);
            // 
            // btnNotQualified
            // 
            this.btnNotQualified.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnNotQualified.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotQualified.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNotQualified.ForeColor = System.Drawing.Color.White;
            this.btnNotQualified.Location = new System.Drawing.Point(146, 61);
            this.btnNotQualified.Margin = new System.Windows.Forms.Padding(2);
            this.btnNotQualified.Name = "btnNotQualified";
            this.btnNotQualified.Size = new System.Drawing.Size(112, 32);
            this.btnNotQualified.TabIndex = 2;
            this.btnNotQualified.Text = "Not Qualified";
            this.btnNotQualified.UseVisualStyleBackColor = false;
            this.btnNotQualified.Click += new System.EventHandler(this.btnNotQualified_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRemarksCaption);
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox3.Location = new System.Drawing.Point(35, 229);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(645, 130);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remarks";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lblRemarksCaption
            // 
            this.lblRemarksCaption.AutoSize = true;
            this.lblRemarksCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRemarksCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblRemarksCaption.Location = new System.Drawing.Point(15, 24);
            this.lblRemarksCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemarksCaption.Name = "lblRemarksCaption";
            this.lblRemarksCaption.Size = new System.Drawing.Size(64, 19);
            this.lblRemarksCaption.TabIndex = 0;
            this.lblRemarksCaption.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRemarks.Location = new System.Drawing.Point(15, 49);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(616, 69);
            this.txtRemarks.TabIndex = 1;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(1055, 547);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(207, 37);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Proceed to Schedule Interview";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dgvApplications
            // 
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Location = new System.Drawing.Point(686, 88);
            this.dgvApplications.Margin = new System.Windows.Forms.Padding(2);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.RowHeadersWidth = 51;
            this.dgvApplications.RowTemplate.Height = 24;
            this.dgvApplications.Size = new System.Drawing.Size(653, 425);
            this.dgvApplications.TabIndex = 6;
            this.dgvApplications.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplications_CellContentClick);
            // 
            // ViewDocuments
            // 
            this.ViewDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(122)))), ((int)(((byte)(60)))));
            this.ViewDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewDocuments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ViewDocuments.ForeColor = System.Drawing.Color.White;
            this.ViewDocuments.Location = new System.Drawing.Point(929, 551);
            this.ViewDocuments.Margin = new System.Windows.Forms.Padding(2);
            this.ViewDocuments.Name = "ViewDocuments";
            this.ViewDocuments.Size = new System.Drawing.Size(112, 32);
            this.ViewDocuments.TabIndex = 3;
            this.ViewDocuments.Text = "View Documents";
            this.ViewDocuments.UseVisualStyleBackColor = false;
            this.ViewDocuments.Click += new System.EventHandler(this.btnViewDocuments_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1204, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSelectedApplicant
            // 
            this.lblSelectedApplicant.AutoSize = true;
            this.lblSelectedApplicant.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelectedApplicant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblSelectedApplicant.Location = new System.Drawing.Point(32, 368);
            this.lblSelectedApplicant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedApplicant.Name = "lblSelectedApplicant";
            this.lblSelectedApplicant.Size = new System.Drawing.Size(120, 15);
            this.lblSelectedApplicant.TabIndex = 10;
            this.lblSelectedApplicant.Text = "No applicant selected";
            // 
            // frmScreening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ViewDocuments);
            this.Controls.Add(this.dgvApplications);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblSelectedApplicant);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmScreening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Screening";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmScreening_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.Button ViewDocuments;
        private System.Windows.Forms.Button button1;
        // FIX: Added missing label referenced in frmScreening.cs Dgv_SelectionChanged
        private System.Windows.Forms.Label lblSelectedApplicant;
    }
}