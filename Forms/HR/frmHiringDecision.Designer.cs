namespace HRApplicantSystem.Forms.HR
{
    partial class frmHiringDecision
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblAccessNotice;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblJobTitleCaption;
        private System.Windows.Forms.Label lblJobApplied;
        private System.Windows.Forms.Label lblScoreCaption;
        private System.Windows.Forms.Label lblInterviewScore;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDecision;
        private System.Windows.Forms.Button btnHire;
        private System.Windows.Forms.Button btnReject;

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblRemarksCaption;
        private System.Windows.Forms.TextBox txtFinalRemarks;

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
            this.lblAccessNotice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.lblJobTitleCaption = new System.Windows.Forms.Label();
            this.lblJobApplied = new System.Windows.Forms.Label();
            this.lblScoreCaption = new System.Windows.Forms.Label();
            this.lblInterviewScore = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDecision = new System.Windows.Forms.Label();
            this.btnHire = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRemarksCaption = new System.Windows.Forms.Label();
            this.txtFinalRemarks = new System.Windows.Forms.TextBox();
            this.dgvPassed = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassed)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(46, 32);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Final Hiring Decision";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lblSubtitle.Location = new System.Drawing.Point(49, 63);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(240, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Confirm the final outcome of this application";
            // 
            // lblAccessNotice
            // 
            this.lblAccessNotice.AutoSize = true;
            this.lblAccessNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblAccessNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.lblAccessNotice.Location = new System.Drawing.Point(48, 79);
            this.lblAccessNotice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccessNotice.Name = "lblAccessNotice";
            this.lblAccessNotice.Size = new System.Drawing.Size(201, 15);
            this.lblAccessNotice.TabIndex = 2;
            this.lblAccessNotice.Text = "Access: Admin and HR Manager only";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNameCaption);
            this.groupBox1.Controls.Add(this.lblApplicantName);
            this.groupBox1.Controls.Add(this.lblJobTitleCaption);
            this.groupBox1.Controls.Add(this.lblJobApplied);
            this.groupBox1.Controls.Add(this.lblScoreCaption);
            this.groupBox1.Controls.Add(this.lblInterviewScore);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox1.Location = new System.Drawing.Point(46, 109);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(225, 171);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applicant Summary";
            // 
            // lblNameCaption
            // 
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNameCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblNameCaption.Location = new System.Drawing.Point(15, 28);
            this.lblNameCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameCaption.Name = "lblNameCaption";
            this.lblNameCaption.Size = new System.Drawing.Size(48, 19);
            this.lblNameCaption.TabIndex = 0;
            this.lblNameCaption.Text = "Name:";
            // 
            // lblApplicantName
            // 
            this.lblApplicantName.AutoSize = true;
            this.lblApplicantName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblApplicantName.Location = new System.Drawing.Point(15, 47);
            this.lblApplicantName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicantName.Name = "lblApplicantName";
            this.lblApplicantName.Size = new System.Drawing.Size(85, 19);
            this.lblApplicantName.TabIndex = 1;
            this.lblApplicantName.Text = "(Loading...)";
            // 
            // lblJobTitleCaption
            // 
            this.lblJobTitleCaption.AutoSize = true;
            this.lblJobTitleCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblJobTitleCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblJobTitleCaption.Location = new System.Drawing.Point(15, 69);
            this.lblJobTitleCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJobTitleCaption.Name = "lblJobTitleCaption";
            this.lblJobTitleCaption.Size = new System.Drawing.Size(83, 19);
            this.lblJobTitleCaption.TabIndex = 2;
            this.lblJobTitleCaption.Text = "Job Applied:";
            // 
            // lblJobApplied
            // 
            this.lblJobApplied.AutoSize = true;
            this.lblJobApplied.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblJobApplied.Location = new System.Drawing.Point(15, 88);
            this.lblJobApplied.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJobApplied.Name = "lblJobApplied";
            this.lblJobApplied.Size = new System.Drawing.Size(85, 19);
            this.lblJobApplied.TabIndex = 3;
            this.lblJobApplied.Text = "(Loading...)";
            // 
            // lblScoreCaption
            // 
            this.lblScoreCaption.AutoSize = true;
            this.lblScoreCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblScoreCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblScoreCaption.Location = new System.Drawing.Point(15, 110);
            this.lblScoreCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScoreCaption.Name = "lblScoreCaption";
            this.lblScoreCaption.Size = new System.Drawing.Size(105, 19);
            this.lblScoreCaption.TabIndex = 4;
            this.lblScoreCaption.Text = "Interview Score:";
            // 
            // lblInterviewScore
            // 
            this.lblInterviewScore.AutoSize = true;
            this.lblInterviewScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInterviewScore.Location = new System.Drawing.Point(15, 128);
            this.lblInterviewScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInterviewScore.Name = "lblInterviewScore";
            this.lblInterviewScore.Size = new System.Drawing.Size(85, 19);
            this.lblInterviewScore.TabIndex = 5;
            this.lblInterviewScore.Text = "(Loading...)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.lblDecision);
            this.groupBox2.Controls.Add(this.btnHire);
            this.groupBox2.Controls.Add(this.btnReject);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox2.Location = new System.Drawing.Point(288, 109);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(225, 171);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decision";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.lblStatus.Location = new System.Drawing.Point(15, 45);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(112, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status: Pending";
            // 
            // lblDecision
            // 
            this.lblDecision.AutoSize = true;
            this.lblDecision.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDecision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblDecision.Location = new System.Drawing.Point(15, 24);
            this.lblDecision.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDecision.Name = "lblDecision";
            this.lblDecision.Size = new System.Drawing.Size(163, 19);
            this.lblDecision.TabIndex = 0;
            this.lblDecision.Text = "Final Decision: Pending";
            // 
            // btnHire
            // 
            this.btnHire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(122)))), ((int)(((byte)(60)))));
            this.btnHire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHire.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHire.ForeColor = System.Drawing.Color.White;
            this.btnHire.Location = new System.Drawing.Point(15, 73);
            this.btnHire.Margin = new System.Windows.Forms.Padding(2);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(195, 28);
            this.btnHire.TabIndex = 2;
            this.btnHire.Text = "Accept Applicant";
            this.btnHire.UseVisualStyleBackColor = false;
            this.btnHire.Click += new System.EventHandler(this.btnHire_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(15, 107);
            this.btnReject.Margin = new System.Windows.Forms.Padding(2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(195, 28);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "Reject Applicant";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRemarksCaption);
            this.groupBox3.Controls.Add(this.txtFinalRemarks);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox3.Location = new System.Drawing.Point(288, 303);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(225, 146);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Final Remarks";
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
            // txtFinalRemarks
            // 
            this.txtFinalRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFinalRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFinalRemarks.Location = new System.Drawing.Point(15, 45);
            this.txtFinalRemarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtFinalRemarks.Multiline = true;
            this.txtFinalRemarks.Name = "txtFinalRemarks";
            this.txtFinalRemarks.Size = new System.Drawing.Size(196, 90);
            this.txtFinalRemarks.TabIndex = 1;
            this.txtFinalRemarks.TextChanged += new System.EventHandler(this.txtFinalRemarks_TextChanged);
            // 
            // dgvPassed
            // 
            this.dgvPassed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassed.Location = new System.Drawing.Point(552, 92);
            this.dgvPassed.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPassed.Name = "dgvPassed";
            this.dgvPassed.RowHeadersWidth = 51;
            this.dgvPassed.RowTemplate.Height = 24;
            this.dgvPassed.Size = new System.Drawing.Size(692, 418);
            this.dgvPassed.TabIndex = 7;
            this.dgvPassed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassed_CellContentClick);
            this.dgvPassed.SelectionChanged += new System.EventHandler(this.dgvPassed_SelectionChanged);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1191, 41);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(159, 32);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmHiringDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvPassed);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblAccessNotice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHiringDecision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final Hiring Decision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHiringDecision_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dgvPassed;
        private System.Windows.Forms.Button btnBack;
    }
}