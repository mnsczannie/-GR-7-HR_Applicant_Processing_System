namespace HRApplicantSystem.Forms.HR
{
    partial class frmHRViewDocuments
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
            this.dgvDocuments = new System.Windows.Forms.DataGridView();
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.lblDocCount = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRejectDoc = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocuments
            // 
            this.dgvDocuments.AllowUserToAddRows = false;
            this.dgvDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocuments.Location = new System.Drawing.Point(336, 115);
            this.dgvDocuments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.ReadOnly = true;
            this.dgvDocuments.RowHeadersVisible = false;
            this.dgvDocuments.RowHeadersWidth = 51;
            this.dgvDocuments.RowTemplate.Height = 24;
            this.dgvDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocuments.Size = new System.Drawing.Size(525, 507);
            this.dgvDocuments.TabIndex = 0;
            // 
            // lblApplicantName
            // 
            this.lblApplicantName.AutoSize = true;
            this.lblApplicantName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblApplicantName.Location = new System.Drawing.Point(275, 72);
            this.lblApplicantName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicantName.Name = "lblApplicantName";
            this.lblApplicantName.Size = new System.Drawing.Size(0, 21);
            this.lblApplicantName.TabIndex = 1;
            // 
            // lblDocCount
            // 
            this.lblDocCount.AutoSize = true;
            this.lblDocCount.Location = new System.Drawing.Point(761, 95);
            this.lblDocCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocCount.Name = "lblDocCount";
            this.lblDocCount.Size = new System.Drawing.Size(107, 13);
            this.lblDocCount.TabIndex = 2;
            this.lblDocCount.Text = "0 document record(s)";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(889, 176);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(138, 28);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRejectDoc
            // 
            this.btnRejectDoc.Location = new System.Drawing.Point(889, 221);
            this.btnRejectDoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRejectDoc.Name = "btnRejectDoc";
            this.btnRejectDoc.Size = new System.Drawing.Size(138, 28);
            this.btnRejectDoc.TabIndex = 4;
            this.btnRejectDoc.Text = "Reject Document";
            this.btnRejectDoc.UseVisualStyleBackColor = true;
            this.btnRejectDoc.Click += new System.EventHandler(this.btnRejectDoc_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(889, 263);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(138, 28);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(889, 309);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmHRViewDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRejectDoc);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblDocCount);
            this.Controls.Add(this.lblApplicantName);
            this.Controls.Add(this.dgvDocuments);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmHRViewDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applicant Documents";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHRViewDocuments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocuments;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblDocCount;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRejectDoc;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}