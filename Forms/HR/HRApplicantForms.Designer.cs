namespace HRApplicantSystem.Forms.HR
{
    partial class HRApplicantForms
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvApplicants = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicants)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Text = "Applicant List";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(12, 50);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(65, 47);
            this.txtSearch.Size = new System.Drawing.Size(250, 20);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // dgvApplicants
            this.dgvApplicants.AllowUserToAddRows = false;
            this.dgvApplicants.AllowUserToDeleteRows = false;
            this.dgvApplicants.ReadOnly = true;
            this.dgvApplicants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplicants.Location = new System.Drawing.Point(12, 78);
            this.dgvApplicants.MultiSelect = false;
            this.dgvApplicants.Name = "dgvApplicants";
            this.dgvApplicants.RowHeadersVisible = false;
            this.dgvApplicants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicants.Size = new System.Drawing.Size(660, 350);
            this.dgvApplicants.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplicants_CellDoubleClick);

            // HRApplicantForms
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 445);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvApplicants);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HRApplicantForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applicant List";
            this.Load += new System.EventHandler(this.HRApplicantForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvApplicants;
    }
}
