namespace HRApplicantSystem.Forms.HR
{
    partial class frmScreening
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
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.lblPositionCaption = new System.Windows.Forms.Label();
            this.dgvDocuments = new System.Windows.Forms.DataGridView();
            this.lblDocuments = new System.Windows.Forms.Label();
            this.rdoQualified = new System.Windows.Forms.RadioButton();
            this.rdoNotQualified = new System.Windows.Forms.RadioButton();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            this.SuspendLayout();

            // lblNameCaption
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNameCaption.Location = new System.Drawing.Point(12, 15);
            this.lblNameCaption.Text = "Applicant:";

            // lblApplicantName
            this.lblApplicantName.AutoSize = true;
            this.lblApplicantName.Location = new System.Drawing.Point(90, 15);
            this.lblApplicantName.Text = "—";

            // lblPositionCaption
            this.lblPositionCaption.AutoSize = true;
            this.lblPositionCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPositionCaption.Location = new System.Drawing.Point(12, 38);
            this.lblPositionCaption.Text = "Position:";

            // lblPosition
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(90, 38);
            this.lblPosition.Text = "—";

            // lblDocuments
            this.lblDocuments.AutoSize = true;
            this.lblDocuments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDocuments.Location = new System.Drawing.Point(12, 65);
            this.lblDocuments.Text = "Documents Checklist:";

            // dgvDocuments
            this.dgvDocuments.AllowUserToAddRows = false;
            this.dgvDocuments.AllowUserToDeleteRows = false;
            this.dgvDocuments.ReadOnly = true;
            this.dgvDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocuments.Location = new System.Drawing.Point(12, 85);
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.RowHeadersVisible = false;
            this.dgvDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocuments.Size = new System.Drawing.Size(560, 160);

            // rdoQualified
            this.rdoQualified.AutoSize = true;
            this.rdoQualified.Location = new System.Drawing.Point(15, 260);
            this.rdoQualified.Text = "Qualified";
            this.rdoQualified.CheckedChanged += new System.EventHandler(this.rdoQualified_CheckedChanged);

            // rdoNotQualified
            this.rdoNotQualified.AutoSize = true;
            this.rdoNotQualified.Location = new System.Drawing.Point(110, 260);
            this.rdoNotQualified.Text = "Not Qualified";

            // lblRemarks
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.Location = new System.Drawing.Point(12, 290);
            this.lblRemarks.Text = "Remarks:";

            // txtRemarks
            this.txtRemarks.Location = new System.Drawing.Point(15, 308);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Size = new System.Drawing.Size(557, 70);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(415, 395);
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnProceed
            this.btnProceed.Enabled = false;
            this.btnProceed.Location = new System.Drawing.Point(497, 395);
            this.btnProceed.Size = new System.Drawing.Size(75, 28);
            this.btnProceed.Text = "Proceed →";
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);

            // frmScreening
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 440);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.lblApplicantName);
            this.Controls.Add(this.lblPositionCaption);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblDocuments);
            this.Controls.Add(this.dgvDocuments);
            this.Controls.Add(this.rdoQualified);
            this.Controls.Add(this.rdoNotQualified);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnProceed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmScreening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screening — Applicant Review";
            this.Load += new System.EventHandler(this.frmScreening_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblPositionCaption;
        private System.Windows.Forms.DataGridView dgvDocuments;
        private System.Windows.Forms.Label lblDocuments;
        private System.Windows.Forms.RadioButton rdoQualified;
        private System.Windows.Forms.RadioButton rdoNotQualified;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnProceed;
    }
}
