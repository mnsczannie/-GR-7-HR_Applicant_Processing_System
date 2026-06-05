namespace HRApplicantSystem.Forms.HR
{
    partial class frmHiringDecision
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
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.lblEvalCaption = new System.Windows.Forms.Label();
            this.lblEvalSummary = new System.Windows.Forms.Label();
            this.rdoAccepted = new System.Windows.Forms.RadioButton();
            this.rdoRejected = new System.Windows.Forms.RadioButton();
            this.lblFinalRemarks = new System.Windows.Forms.Label();
            this.txtFinalRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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

            // lblEvalCaption
            this.lblEvalCaption.AutoSize = true;
            this.lblEvalCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEvalCaption.Location = new System.Drawing.Point(12, 45);
            this.lblEvalCaption.Text = "Evaluation Summary:";

            // lblEvalSummary
            this.lblEvalSummary.AutoSize = false;
            this.lblEvalSummary.Location = new System.Drawing.Point(15, 65);
            this.lblEvalSummary.Size = new System.Drawing.Size(450, 40);
            this.lblEvalSummary.Text = "—";
            this.lblEvalSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEvalSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // rdoAccepted
            this.rdoAccepted.AutoSize = true;
            this.rdoAccepted.Location = new System.Drawing.Point(15, 118);
            this.rdoAccepted.Text = "Accepted";

            // rdoRejected
            this.rdoRejected.AutoSize = true;
            this.rdoRejected.Location = new System.Drawing.Point(110, 118);
            this.rdoRejected.Text = "Rejected";

            // lblFinalRemarks
            this.lblFinalRemarks.AutoSize = true;
            this.lblFinalRemarks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinalRemarks.Location = new System.Drawing.Point(12, 148);
            this.lblFinalRemarks.Text = "Final Remarks:";

            // txtFinalRemarks
            this.txtFinalRemarks.Location = new System.Drawing.Point(15, 166);
            this.txtFinalRemarks.Multiline = true;
            this.txtFinalRemarks.Size = new System.Drawing.Size(450, 70);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(310, 252);
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(392, 252);
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // frmHiringDecision
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 298);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.lblApplicantName);
            this.Controls.Add(this.lblEvalCaption);
            this.Controls.Add(this.lblEvalSummary);
            this.Controls.Add(this.rdoAccepted);
            this.Controls.Add(this.rdoRejected);
            this.Controls.Add(this.lblFinalRemarks);
            this.Controls.Add(this.txtFinalRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHiringDecision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiring Decision";
            this.Load += new System.EventHandler(this.frmHiringDecision_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblEvalCaption;
        private System.Windows.Forms.Label lblEvalSummary;
        private System.Windows.Forms.RadioButton rdoAccepted;
        private System.Windows.Forms.RadioButton rdoRejected;
        private System.Windows.Forms.Label lblFinalRemarks;
        private System.Windows.Forms.TextBox txtFinalRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
