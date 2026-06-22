namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmMyDocuments
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblOverallStatus = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBoxChecklist = new System.Windows.Forms.GroupBox();
            this.flpDocuments = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxRemarks = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxChecklist.SuspendLayout();
            this.groupBoxRemarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(227, 65);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Documents";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lblSubtitle.Location = new System.Drawing.Point(229, 99);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(412, 16);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Upload the requirements needed to process your application";
            // 
            // lblOverallStatus
            // 
            this.lblOverallStatus.AutoSize = true;
            this.lblOverallStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOverallStatus.Location = new System.Drawing.Point(229, 138);
            this.lblOverallStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverallStatus.Name = "lblOverallStatus";
            this.lblOverallStatus.Size = new System.Drawing.Size(136, 21);
            this.lblOverallStatus.TabIndex = 2;
            this.lblOverallStatus.Text = "Overall Status: --";
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnBack.Location = new System.Drawing.Point(1196, 24);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 29);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "← Back to Profile";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBoxChecklist
            // 
            this.groupBoxChecklist.Controls.Add(this.flpDocuments);
            this.groupBoxChecklist.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBoxChecklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBoxChecklist.Location = new System.Drawing.Point(227, 174);
            this.groupBoxChecklist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxChecklist.Name = "groupBoxChecklist";
            this.groupBoxChecklist.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxChecklist.Size = new System.Drawing.Size(525, 488);
            this.groupBoxChecklist.TabIndex = 4;
            this.groupBoxChecklist.TabStop = false;
            this.groupBoxChecklist.Text = "Requirements Checklist";
            // 
            // flpDocuments
            // 
            this.flpDocuments.AutoScroll = true;
            this.flpDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDocuments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDocuments.Location = new System.Drawing.Point(2, 19);
            this.flpDocuments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpDocuments.Name = "flpDocuments";
            this.flpDocuments.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.flpDocuments.Size = new System.Drawing.Size(521, 467);
            this.flpDocuments.TabIndex = 0;
            this.flpDocuments.WrapContents = false;
            // 
            // groupBoxRemarks
            // 
            this.groupBoxRemarks.Controls.Add(this.txtRemarks);
            this.groupBoxRemarks.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBoxRemarks.Location = new System.Drawing.Point(796, 183);
            this.groupBoxRemarks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxRemarks.Name = "groupBoxRemarks";
            this.groupBoxRemarks.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxRemarks.Size = new System.Drawing.Size(323, 191);
            this.groupBoxRemarks.TabIndex = 5;
            this.groupBoxRemarks.TabStop = false;
            this.groupBoxRemarks.Text = "HR Remarks / Screening Feedback";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtRemarks.Location = new System.Drawing.Point(14, 30);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(294, 138);
            this.txtRemarks.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All Files (*.*)|*.*|PDF Files (*.pdf)|*.pdf|Word Documents (*.doc;*.docx)|*.doc;*" +
    ".docx|Images (*.jpg;*.png)|*.jpg;*.png";
            this.openFileDialog1.Title = "Select Document to Upload";
            // 
            // frmMyDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblOverallStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBoxChecklist);
            this.Controls.Add(this.groupBoxRemarks);
            this.Name = "frmMyDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Documents";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMyDocuments_Load_1);
            this.groupBoxChecklist.ResumeLayout(false);
            this.groupBoxRemarks.ResumeLayout(false);
            this.groupBoxRemarks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblOverallStatus;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.GroupBox groupBoxChecklist;




        private System.Windows.Forms.FlowLayoutPanel flpDocuments;



        private System.Windows.Forms.GroupBox groupBoxRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}