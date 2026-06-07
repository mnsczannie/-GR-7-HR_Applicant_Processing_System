namespace HRApplicantSystem.Forms.Maintenance
{
    partial class frmMaintenance
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnPositions = new System.Windows.Forms.Button();
            this.btnEmploymentTypes = new System.Windows.Forms.Button();
            this.btnRequirementTypes = new System.Windows.Forms.Button();
            this.btnInterviewTypes = new System.Windows.Forms.Button();
            this.btnAssessmentTypes = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(34, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(343, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "System Maintenance Hub";

            this.btnDepartments.Location = new System.Drawing.Point(40, 75);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(274, 37);
            this.btnDepartments.TabIndex = 1;
            this.btnDepartments.Text = "Departments Configuration";
            this.btnDepartments.UseVisualStyleBackColor = true;
            this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);

            this.btnPositions.Location = new System.Drawing.Point(40, 123);
            this.btnPositions.Name = "btnPositions";
            this.btnPositions.Size = new System.Drawing.Size(274, 37);
            this.btnPositions.TabIndex = 2;
            this.btnPositions.Text = "Positions Configuration";
            this.btnPositions.UseVisualStyleBackColor = true;
            this.btnPositions.Click += new System.EventHandler(this.btnPositions_Click);

            this.btnEmploymentTypes.Location = new System.Drawing.Point(40, 171);
            this.btnEmploymentTypes.Name = "btnEmploymentTypes";
            this.btnEmploymentTypes.Size = new System.Drawing.Size(274, 37);
            this.btnEmploymentTypes.TabIndex = 3;
            this.btnEmploymentTypes.Text = "Employment Types";
            this.btnEmploymentTypes.UseVisualStyleBackColor = true;
            this.btnEmploymentTypes.Click += new System.EventHandler(this.btnEmploymentTypes_Click);

            this.btnRequirementTypes.Location = new System.Drawing.Point(40, 219);
            this.btnRequirementTypes.Name = "btnRequirementTypes";
            this.btnRequirementTypes.Size = new System.Drawing.Size(274, 37);
            this.btnRequirementTypes.TabIndex = 4;
            this.btnRequirementTypes.Text = "Requirement Types";
            this.btnRequirementTypes.UseVisualStyleBackColor = true;
            this.btnRequirementTypes.Click += new System.EventHandler(this.btnRequirementTypes_Click);

            this.btnInterviewTypes.Location = new System.Drawing.Point(40, 267);
            this.btnInterviewTypes.Name = "btnInterviewTypes";
            this.btnInterviewTypes.Size = new System.Drawing.Size(274, 37);
            this.btnInterviewTypes.TabIndex = 5;
            this.btnInterviewTypes.Text = "Interview Types";
            this.btnInterviewTypes.UseVisualStyleBackColor = true;
            this.btnInterviewTypes.Click += new System.EventHandler(this.btnInterviewTypes_Click);

            this.btnAssessmentTypes.Location = new System.Drawing.Point(40, 315);
            this.btnAssessmentTypes.Name = "btnAssessmentTypes";
            this.btnAssessmentTypes.Size = new System.Drawing.Size(274, 37);
            this.btnAssessmentTypes.TabIndex = 6;
            this.btnAssessmentTypes.Text = "Assessment Types";
            this.btnAssessmentTypes.UseVisualStyleBackColor = true;
            this.btnAssessmentTypes.Click += new System.EventHandler(this.btnAssessmentTypes_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 383);
            this.Controls.Add(this.btnAssessmentTypes);
            this.Controls.Add(this.btnInterviewTypes);
            this.Controls.Add(this.btnRequirementTypes);
            this.Controls.Add(this.btnEmploymentTypes);
            this.Controls.Add(this.btnPositions);
            this.Controls.Add(this.btnDepartments);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance Settings Hub";
            this.Load += new System.EventHandler(this.frmMaintenance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button btnPositions;
        private System.Windows.Forms.Button btnEmploymentTypes;
        private System.Windows.Forms.Button btnRequirementTypes;
        private System.Windows.Forms.Button btnInterviewTypes;
        private System.Windows.Forms.Button btnAssessmentTypes;
    }
}