namespace HRApplicantSystem.Forms.HR
{
    partial class frmInterviewSchedule
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
            this.lblPosCaption = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblInterviewer = new System.Windows.Forms.Label();
            this.cboInterviewer = new System.Windows.Forms.ComboBox();
            this.lblInterviewType = new System.Windows.Forms.Label();
            this.cboInterviewType = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
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
            this.lblApplicantName.Location = new System.Drawing.Point(95, 15);
            this.lblApplicantName.Text = "—";

            // lblPosCaption
            this.lblPosCaption.AutoSize = true;
            this.lblPosCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPosCaption.Location = new System.Drawing.Point(12, 38);
            this.lblPosCaption.Text = "Position:";

            // lblPosition
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(95, 38);
            this.lblPosition.Text = "—";

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(12, 72);
            this.lblDate.Text = "Date:";

            // dtpDate
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(95, 68);
            this.dtpDate.Size = new System.Drawing.Size(140, 20);

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(250, 72);
            this.lblTime.Text = "Time:";

            // dtpTime
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Location = new System.Drawing.Point(295, 68);
            this.dtpTime.Size = new System.Drawing.Size(110, 20);

            // lblInterviewer
            this.lblInterviewer.AutoSize = true;
            this.lblInterviewer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInterviewer.Location = new System.Drawing.Point(12, 104);
            this.lblInterviewer.Text = "Interviewer:";

            // cboInterviewer
            this.cboInterviewer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterviewer.Location = new System.Drawing.Point(95, 101);
            this.cboInterviewer.Size = new System.Drawing.Size(200, 21);

            // lblInterviewType
            this.lblInterviewType.AutoSize = true;
            this.lblInterviewType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInterviewType.Location = new System.Drawing.Point(12, 136);
            this.lblInterviewType.Text = "Interview Type:";

            // cboInterviewType
            this.cboInterviewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterviewType.Location = new System.Drawing.Point(110, 133);
            this.cboInterviewType.Size = new System.Drawing.Size(185, 21);

            // lblLocation
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Location = new System.Drawing.Point(12, 168);
            this.lblLocation.Text = "Location / Link:";

            // txtLocation
            this.txtLocation.Location = new System.Drawing.Point(110, 165);
            this.txtLocation.Size = new System.Drawing.Size(295, 20);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(12, 200);
            this.lblStatus.Text = "Status:";

            // cboStatus
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(95, 197);
            this.cboStatus.Size = new System.Drawing.Size(140, 21);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(330, 235);
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(412, 235);
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // frmInterviewSchedule
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 280);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.lblApplicantName);
            this.Controls.Add(this.lblPosCaption);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.lblInterviewer);
            this.Controls.Add(this.cboInterviewer);
            this.Controls.Add(this.lblInterviewType);
            this.Controls.Add(this.cboInterviewType);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInterviewSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Interview";
            this.Load += new System.EventHandler(this.frmInterviewSchedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.Label lblPosCaption;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblInterviewer;
        private System.Windows.Forms.ComboBox cboInterviewer;
        private System.Windows.Forms.Label lblInterviewType;
        private System.Windows.Forms.ComboBox cboInterviewType;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
