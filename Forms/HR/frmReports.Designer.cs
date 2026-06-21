namespace HRApplicantSystem.Forms.HR
{
    partial class frmReports
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnApplicants;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnApplicants = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.lblTotalApplicants = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblInterviewed = new System.Windows.Forms.Label();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.lblRejected = new System.Windows.Forms.Label();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnInterviews = new System.Windows.Forms.Button();
            this.btnAccepted = new System.Windows.Forms.Button();
            this.btnRejected = new System.Windows.Forms.Button();
            this.btnMissing = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblReportTitle.Location = new System.Drawing.Point(20, 10);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(100, 23);
            this.lblReportTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(121, 44);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HR Reports";
            // 
            // btnApplicants
            // 
            this.btnApplicants.Location = new System.Drawing.Point(295, 105);
            this.btnApplicants.Name = "btnApplicants";
            this.btnApplicants.Size = new System.Drawing.Size(130, 30);
            this.btnApplicants.TabIndex = 1;
            this.btnApplicants.Text = "Applicants";
            this.btnApplicants.Click += new System.EventHandler(this.btnApplicants_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1760, 23);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(505, 82);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.RowTemplate.Height = 24;
            this.dgvReports.Size = new System.Drawing.Size(811, 462);
            this.dgvReports.TabIndex = 4;
            // 
            // lblTotalApplicants
            // 
            this.lblTotalApplicants.AutoSize = true;
            this.lblTotalApplicants.Location = new System.Drawing.Point(169, 123);
            this.lblTotalApplicants.Name = "lblTotalApplicants";
            this.lblTotalApplicants.Size = new System.Drawing.Size(83, 13);
            this.lblTotalApplicants.TabIndex = 5;
            this.lblTotalApplicants.Text = "Total Applicants";
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Location = new System.Drawing.Point(169, 180);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(46, 13);
            this.lblPending.TabIndex = 6;
            this.lblPending.Text = "Pending";
            // 
            // lblInterviewed
            // 
            this.lblInterviewed.AutoSize = true;
            this.lblInterviewed.Location = new System.Drawing.Point(164, 239);
            this.lblInterviewed.Name = "lblInterviewed";
            this.lblInterviewed.Size = new System.Drawing.Size(62, 13);
            this.lblInterviewed.TabIndex = 7;
            this.lblInterviewed.Text = "Interviewed";
            // 
            // lblAccepted
            // 
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Location = new System.Drawing.Point(164, 292);
            this.lblAccepted.Name = "lblAccepted";
            this.lblAccepted.Size = new System.Drawing.Size(53, 13);
            this.lblAccepted.TabIndex = 8;
            this.lblAccepted.Text = "Accepted";
            // 
            // lblRejected
            // 
            this.lblRejected.AutoSize = true;
            this.lblRejected.Location = new System.Drawing.Point(167, 354);
            this.lblRejected.Name = "lblRejected";
            this.lblRejected.Size = new System.Drawing.Size(50, 13);
            this.lblRejected.TabIndex = 9;
            this.lblRejected.Text = "Rejected";
            // 
            // btnPending
            // 
            this.btnPending.Location = new System.Drawing.Point(295, 161);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(130, 30);
            this.btnPending.TabIndex = 10;
            this.btnPending.Text = "Pending";
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnInterviews
            // 
            this.btnInterviews.Location = new System.Drawing.Point(295, 217);
            this.btnInterviews.Name = "btnInterviews";
            this.btnInterviews.Size = new System.Drawing.Size(130, 30);
            this.btnInterviews.TabIndex = 11;
            this.btnInterviews.Text = "Interviewed";
            this.btnInterviews.Click += new System.EventHandler(this.btnInterviews_Click);
            // 
            // btnAccepted
            // 
            this.btnAccepted.Location = new System.Drawing.Point(295, 273);
            this.btnAccepted.Name = "btnAccepted";
            this.btnAccepted.Size = new System.Drawing.Size(130, 30);
            this.btnAccepted.TabIndex = 12;
            this.btnAccepted.Text = "Accepted";
            this.btnAccepted.Click += new System.EventHandler(this.btnAccepted_Click);
            // 
            // btnRejected
            // 
            this.btnRejected.Location = new System.Drawing.Point(295, 324);
            this.btnRejected.Name = "btnRejected";
            this.btnRejected.Size = new System.Drawing.Size(130, 30);
            this.btnRejected.TabIndex = 14;
            this.btnRejected.Text = "Rejected";
            this.btnRejected.Click += new System.EventHandler(this.btnRejected_Click);
            // 
            // btnMissing
            // 
            this.btnMissing.Location = new System.Drawing.Point(258, 383);
            this.btnMissing.Name = "btnMissing";
            this.btnMissing.Size = new System.Drawing.Size(167, 30);
            this.btnMissing.TabIndex = 16;
            this.btnMissing.Text = "Missing Requirements";
            this.btnMissing.Click += new System.EventHandler(this.btnMissing_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(601, 566);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(160, 36);
            this.btnExport.TabIndex = 22;
            this.btnExport.Text = "Generate Report";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Applicants";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.Text = "Pending";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(57, 233);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(84, 20);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "Interviewed";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(61, 289);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(84, 20);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "Accepted";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(61, 348);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(84, 20);
            this.textBox5.TabIndex = 21;
            this.textBox5.Text = "Rejected";
            // 
            // frmReports
            // 
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnMissing);
            this.Controls.Add(this.btnRejected);
            this.Controls.Add(this.btnAccepted);
            this.Controls.Add(this.btnInterviews);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.lblRejected);
            this.Controls.Add(this.lblAccepted);
            this.Controls.Add(this.lblInterviewed);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblTotalApplicants);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnApplicants);
            this.Controls.Add(this.btnBack);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Label lblTotalApplicants;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblInterviewed;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.Label lblRejected;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnInterviews;
        private System.Windows.Forms.Button btnAccepted;
        private System.Windows.Forms.Button btnRejected;
        private System.Windows.Forms.Button btnMissing;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Button btnExport;
    }
}