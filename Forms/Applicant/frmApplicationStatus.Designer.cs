namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmApplicationStatus
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.lblStep1Text = new System.Windows.Forms.Label();
            this.lblStep2Text = new System.Windows.Forms.Label();
            this.lblStep3Text = new System.Windows.Forms.Label();
            this.lblStep4Text = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(137, 67);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(258, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Application Status";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.lblCurrentStatus.Location = new System.Drawing.Point(137, 99);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(154, 18);
            this.lblCurrentStatus.TabIndex = 1;
            this.lblCurrentStatus.Text = "Current Status: --";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.lblResult.Location = new System.Drawing.Point(6, 24);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(114, 18);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Final Result: ";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblRemarks.Location = new System.Drawing.Point(6, 20);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(80, 14);
            this.lblRemarks.TabIndex = 0;
            this.lblRemarks.Text = "Remarks: --";
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblSchedule.Location = new System.Drawing.Point(4, 28);
            this.lblSchedule.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(187, 14);
            this.lblSchedule.TabIndex = 0;
            this.lblSchedule.Text = "Schedule: Not yet scheduled";
            // 
            // lblStep1
            // 
            this.lblStep1.BackColor = System.Drawing.Color.Gray;
            this.lblStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep1.Location = new System.Drawing.Point(141, 141);
            this.lblStep1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(16, 17);
            this.lblStep1.TabIndex = 2;
            // 
            // lblStep2
            // 
            this.lblStep2.BackColor = System.Drawing.Color.Gray;
            this.lblStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep2.Location = new System.Drawing.Point(141, 173);
            this.lblStep2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(16, 17);
            this.lblStep2.TabIndex = 4;
            // 
            // lblStep3
            // 
            this.lblStep3.BackColor = System.Drawing.Color.Gray;
            this.lblStep3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep3.Location = new System.Drawing.Point(141, 206);
            this.lblStep3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(16, 17);
            this.lblStep3.TabIndex = 6;
            // 
            // lblStep4
            // 
            this.lblStep4.BackColor = System.Drawing.Color.Gray;
            this.lblStep4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep4.Location = new System.Drawing.Point(141, 238);
            this.lblStep4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(16, 17);
            this.lblStep4.TabIndex = 8;
            // 
            // lblStep1Text
            // 
            this.lblStep1Text.AutoSize = true;
            this.lblStep1Text.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblStep1Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStep1Text.Location = new System.Drawing.Point(162, 143);
            this.lblStep1Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep1Text.Name = "lblStep1Text";
            this.lblStep1Text.Size = new System.Drawing.Size(143, 14);
            this.lblStep1Text.TabIndex = 3;
            this.lblStep1Text.Text = "Application Submitted";
            // 
            // lblStep2Text
            // 
            this.lblStep2Text.AutoSize = true;
            this.lblStep2Text.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblStep2Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStep2Text.Location = new System.Drawing.Point(162, 175);
            this.lblStep2Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep2Text.Name = "lblStep2Text";
            this.lblStep2Text.Size = new System.Drawing.Size(94, 14);
            this.lblStep2Text.TabIndex = 5;
            this.lblStep2Text.Text = "Under Review";
            // 
            // lblStep3Text
            // 
            this.lblStep3Text.AutoSize = true;
            this.lblStep3Text.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblStep3Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStep3Text.Location = new System.Drawing.Point(162, 208);
            this.lblStep3Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep3Text.Name = "lblStep3Text";
            this.lblStep3Text.Size = new System.Drawing.Size(67, 14);
            this.lblStep3Text.TabIndex = 7;
            this.lblStep3Text.Text = "Interview";
            // 
            // lblStep4Text
            // 
            this.lblStep4Text.AutoSize = true;
            this.lblStep4Text.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblStep4Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblStep4Text.Location = new System.Drawing.Point(162, 240);
            this.lblStep4Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep4Text.Name = "lblStep4Text";
            this.lblStep4Text.Size = new System.Drawing.Size(92, 14);
            this.lblStep4Text.TabIndex = 9;
            this.lblStep4Text.Text = "Final Decision";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRemarks);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox1.Location = new System.Drawing.Point(555, 407);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(290, 76);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HR Remarks";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSchedule);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox2.Location = new System.Drawing.Point(311, 321);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(203, 161);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interview Schedule";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblResult);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox3.Location = new System.Drawing.Point(311, 135);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(203, 161);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Final Result";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 10F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.button1.Location = new System.Drawing.Point(990, 78);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Back to Dashboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.dgvHistory);
            this.grpHistory.Font = new System.Drawing.Font("Verdana", 10F);
            this.grpHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.grpHistory.Location = new System.Drawing.Point(552, 116);
            this.grpHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpHistory.Size = new System.Drawing.Size(600, 244);
            this.grpHistory.TabIndex = 10;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "Application History";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeight = 29;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(2, 19);
            this.dgvHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.Size = new System.Drawing.Size(596, 223);
            this.dgvHistory.TabIndex = 0;
            // 
            // frmApplicationStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblStep1Text);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblStep2Text);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.lblStep3Text);
            this.Controls.Add(this.lblStep4);
            this.Controls.Add(this.lblStep4Text);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Name = "frmApplicationStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Status";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmApplicationStatus_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Label lblStep1Text;
        private System.Windows.Forms.Label lblStep2Text;
        private System.Windows.Forms.Label lblStep3Text;
        private System.Windows.Forms.Label lblStep4Text;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
    }
}