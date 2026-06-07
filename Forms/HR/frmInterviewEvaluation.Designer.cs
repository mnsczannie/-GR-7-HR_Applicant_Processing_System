namespace HRApplicantSystem.Forms.HR
{
    partial class frmInterviewEvaluation
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
            this.lblSchedCaption = new System.Windows.Forms.Label();
            this.lblScheduleInfo = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.nudScore = new System.Windows.Forms.NumericUpDown();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.rdoPass = new System.Windows.Forms.RadioButton();
            this.rdoFail = new System.Windows.Forms.RadioButton();
            this.lblRecommendation = new System.Windows.Forms.Label();
            this.txtRecommendation = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnHiringDecision = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudScore)).BeginInit();
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

            // lblSchedCaption
            this.lblSchedCaption.AutoSize = true;
            this.lblSchedCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSchedCaption.Location = new System.Drawing.Point(12, 38);
            this.lblSchedCaption.Text = "Schedule:";

            // lblScheduleInfo
            this.lblScheduleInfo.AutoSize = true;
            this.lblScheduleInfo.Location = new System.Drawing.Point(90, 38);
            this.lblScheduleInfo.Text = "—";

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(12, 72);
            this.lblScore.Text = "Score (0–100):";

            // nudScore
            this.nudScore.Location = new System.Drawing.Point(110, 69);
            this.nudScore.Maximum = 100;
            this.nudScore.Minimum = 0;
            this.nudScore.Size = new System.Drawing.Size(60, 20);

            // lblRemarks
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.Location = new System.Drawing.Point(12, 104);
            this.lblRemarks.Text = "Remarks:";

            // txtRemarks
            this.txtRemarks.Location = new System.Drawing.Point(15, 122);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Size = new System.Drawing.Size(460, 55);

            // rdoPass
            this.rdoPass.AutoSize = true;
            this.rdoPass.Location = new System.Drawing.Point(15, 188);
            this.rdoPass.Text = "Pass";

            // rdoFail
            this.rdoFail.AutoSize = true;
            this.rdoFail.Location = new System.Drawing.Point(80, 188);
            this.rdoFail.Text = "Fail";

            // lblRecommendation
            this.lblRecommendation.AutoSize = true;
            this.lblRecommendation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecommendation.Location = new System.Drawing.Point(12, 218);
            this.lblRecommendation.Text = "Recommendation:";

            // txtRecommendation
            this.txtRecommendation.Location = new System.Drawing.Point(15, 236);
            this.txtRecommendation.Multiline = true;
            this.txtRecommendation.Size = new System.Drawing.Size(460, 55);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(315, 308);
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnHiringDecision
            this.btnHiringDecision.Location = new System.Drawing.Point(397, 308);
            this.btnHiringDecision.Size = new System.Drawing.Size(78, 28);
            this.btnHiringDecision.Text = "Hiring Decision";
            this.btnHiringDecision.Visible = false;
            this.btnHiringDecision.Click += new System.EventHandler(this.btnHiringDecision_Click);

            // frmInterviewEvaluation
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 355);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.lblApplicantName);
            this.Controls.Add(this.lblSchedCaption);
            this.Controls.Add(this.lblScheduleInfo);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.nudScore);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.rdoPass);
            this.Controls.Add(this.rdoFail);
            this.Controls.Add(this.lblRecommendation);
            this.Controls.Add(this.txtRecommendation);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnHiringDecision);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInterviewEvaluation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interview Evaluation";
            this.Load += new System.EventHandler(this.frmInterviewEvaluation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblSchedCaption;
        private System.Windows.Forms.Label lblScheduleInfo;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.NumericUpDown nudScore;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.RadioButton rdoPass;
        private System.Windows.Forms.RadioButton rdoFail;
        private System.Windows.Forms.Label lblRecommendation;
        private System.Windows.Forms.TextBox txtRecommendation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnHiringDecision;
    }
}
