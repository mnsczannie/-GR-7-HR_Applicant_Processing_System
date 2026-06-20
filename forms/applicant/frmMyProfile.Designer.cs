namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmMyProfile
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
            this.lblEmailDisplay = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAddress = new System.Windows.Forms.TabPage();
            this.tabContact = new System.Windows.Forms.TabPage();
            this.tabEducation = new System.Windows.Forms.TabPage();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.tabWorkExperience = new System.Windows.Forms.TabPage();
            this.tabPersonal = new System.Windows.Forms.TabPage();
            this.txtFullName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.Label();
            this.txtDegree = new System.Windows.Forms.Label();
            this.txtYearGrad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSkills = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.tabContact.SuspendLayout();
            this.tabEducation.SuspendLayout();
            this.tabSkills.SuspendLayout();
            this.tabWorkExperience.SuspendLayout();
            this.tabPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmailDisplay
            // 
            this.lblEmailDisplay.AutoSize = true;
            this.lblEmailDisplay.Location = new System.Drawing.Point(29, 9);
            this.lblEmailDisplay.Name = "lblEmailDisplay";
            this.lblEmailDisplay.Size = new System.Drawing.Size(78, 20);
            this.lblEmailDisplay.TabIndex = 0;
            this.lblEmailDisplay.Text = "Loading...";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersonal);
            this.tabControl1.Controls.Add(this.tabAddress);
            this.tabControl1.Controls.Add(this.tabContact);
            this.tabControl1.Controls.Add(this.tabEducation);
            this.tabControl1.Controls.Add(this.tabSkills);
            this.tabControl1.Controls.Add(this.tabWorkExperience);
            this.tabControl1.Location = new System.Drawing.Point(12, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 510);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAddress
            // 
            this.tabAddress.Controls.Add(this.txtZipCode);
            this.tabAddress.Controls.Add(this.txtProvince);
            this.tabAddress.Controls.Add(this.txtCity);
            this.tabAddress.Controls.Add(this.txtAddress);
            this.tabAddress.Location = new System.Drawing.Point(4, 29);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddress.Size = new System.Drawing.Size(648, 477);
            this.tabAddress.TabIndex = 3;
            this.tabAddress.Text = "Address";
            this.tabAddress.UseVisualStyleBackColor = true;
            // 
            // tabContact
            // 
            this.tabContact.Controls.Add(this.txtPhone);
            this.tabContact.Controls.Add(this.txtEmail);
            this.tabContact.Location = new System.Drawing.Point(4, 29);
            this.tabContact.Name = "tabContact";
            this.tabContact.Padding = new System.Windows.Forms.Padding(3);
            this.tabContact.Size = new System.Drawing.Size(648, 477);
            this.tabContact.TabIndex = 5;
            this.tabContact.Text = "Contact";
            this.tabContact.UseVisualStyleBackColor = true;
            // 
            // tabEducation
            // 
            this.tabEducation.Controls.Add(this.txtYearGrad);
            this.tabEducation.Controls.Add(this.txtDegree);
            this.tabEducation.Controls.Add(this.txtSchool);
            this.tabEducation.Location = new System.Drawing.Point(4, 29);
            this.tabEducation.Name = "tabEducation";
            this.tabEducation.Padding = new System.Windows.Forms.Padding(3);
            this.tabEducation.Size = new System.Drawing.Size(648, 477);
            this.tabEducation.TabIndex = 6;
            this.tabEducation.Text = "Education";
            this.tabEducation.UseVisualStyleBackColor = true;
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.txtSkills);
            this.tabSkills.Controls.Add(this.label3);
            this.tabSkills.Location = new System.Drawing.Point(4, 29);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkills.Size = new System.Drawing.Size(648, 477);
            this.tabSkills.TabIndex = 8;
            this.tabSkills.Text = "Skills";
            this.tabSkills.UseVisualStyleBackColor = true;
            // 
            // tabWorkExperience
            // 
            this.tabWorkExperience.Controls.Add(this.txtDuration);
            this.tabWorkExperience.Controls.Add(this.label4);
            this.tabWorkExperience.Controls.Add(this.txtPosition);
            this.tabWorkExperience.Controls.Add(this.txtCompany);
            this.tabWorkExperience.Location = new System.Drawing.Point(4, 29);
            this.tabWorkExperience.Name = "tabWorkExperience";
            this.tabWorkExperience.Padding = new System.Windows.Forms.Padding(3);
            this.tabWorkExperience.Size = new System.Drawing.Size(648, 477);
            this.tabWorkExperience.TabIndex = 10;
            this.tabWorkExperience.Text = "Work Experience";
            this.tabWorkExperience.UseVisualStyleBackColor = true;
            // 
            // tabPersonal
            // 
            this.tabPersonal.Controls.Add(this.btnSave);
            this.tabPersonal.Controls.Add(this.dtpBirthdate);
            this.tabPersonal.Controls.Add(this.label2);
            this.tabPersonal.Controls.Add(this.cboGender);
            this.tabPersonal.Controls.Add(this.label1);
            this.tabPersonal.Controls.Add(this.txtFullName);
            this.tabPersonal.Location = new System.Drawing.Point(4, 29);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonal.Size = new System.Drawing.Size(648, 477);
            this.tabPersonal.TabIndex = 2;
            this.tabPersonal.Text = "Personal";
            this.tabPersonal.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.AutoSize = true;
            this.txtFullName.Location = new System.Drawing.Point(28, 20);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(80, 20);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.Text = "Full Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gender";
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Prefer not to say"});
            this.cboGender.Location = new System.Drawing.Point(167, 72);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(121, 28);
            this.cboGender.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birthdate";
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Location = new System.Drawing.Point(167, 128);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 26);
            this.dtpBirthdate.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(167, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Location = new System.Drawing.Point(22, 24);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(116, 20);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "Street Address";
            // 
            // txtCity
            // 
            this.txtCity.AutoSize = true;
            this.txtCity.Location = new System.Drawing.Point(22, 81);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(35, 20);
            this.txtCity.TabIndex = 1;
            this.txtCity.Text = "City";
            // 
            // txtProvince
            // 
            this.txtProvince.AutoSize = true;
            this.txtProvince.Location = new System.Drawing.Point(22, 139);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(69, 20);
            this.txtProvince.TabIndex = 2;
            this.txtProvince.Text = "Province";
            // 
            // txtZipCode
            // 
            this.txtZipCode.AutoSize = true;
            this.txtZipCode.Location = new System.Drawing.Point(22, 198);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(73, 20);
            this.txtZipCode.TabIndex = 3;
            this.txtZipCode.Text = "Zip Code";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(23, 29);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(48, 20);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.AutoSize = true;
            this.txtPhone.Location = new System.Drawing.Point(23, 83);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(115, 20);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.Text = "Phone Number";
            // 
            // txtSchool
            // 
            this.txtSchool.AutoSize = true;
            this.txtSchool.Location = new System.Drawing.Point(29, 20);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(58, 20);
            this.txtSchool.TabIndex = 0;
            this.txtSchool.Text = "School";
            // 
            // txtDegree
            // 
            this.txtDegree.AutoSize = true;
            this.txtDegree.Location = new System.Drawing.Point(29, 71);
            this.txtDegree.Name = "txtDegree";
            this.txtDegree.Size = new System.Drawing.Size(62, 20);
            this.txtDegree.TabIndex = 1;
            this.txtDegree.Text = "Degree";
            // 
            // txtYearGrad
            // 
            this.txtYearGrad.AutoSize = true;
            this.txtYearGrad.Location = new System.Drawing.Point(29, 134);
            this.txtYearGrad.Name = "txtYearGrad";
            this.txtYearGrad.Size = new System.Drawing.Size(124, 20);
            this.txtYearGrad.TabIndex = 2;
            this.txtYearGrad.Text = "Year Graduated";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Skills";
            // 
            // txtSkills
            // 
            this.txtSkills.Location = new System.Drawing.Point(125, 35);
            this.txtSkills.Multiline = true;
            this.txtSkills.Name = "txtSkills";
            this.txtSkills.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSkills.Size = new System.Drawing.Size(100, 26);
            this.txtSkills.TabIndex = 1;
            this.txtSkills.TextChanged += new System.EventHandler(this.txtSkills_TextChanged);
            // 
            // txtCompany
            // 
            this.txtCompany.AutoSize = true;
            this.txtCompany.Location = new System.Drawing.Point(56, 37);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(76, 20);
            this.txtCompany.TabIndex = 0;
            this.txtCompany.Text = "Company";
            // 
            // txtPosition
            // 
            this.txtPosition.AutoSize = true;
            this.txtPosition.Location = new System.Drawing.Point(56, 97);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(65, 20);
            this.txtPosition.TabIndex = 1;
            this.txtPosition.Text = "Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(195, 152);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 26);
            this.txtDuration.TabIndex = 3;
            // 
            // frmMyProfile
            // 
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(680, 554);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblEmailDisplay);
            this.Name = "frmMyProfile";
            this.Load += new System.EventHandler(this.frmMyProfile_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAddress.ResumeLayout(false);
            this.tabAddress.PerformLayout();
            this.tabContact.ResumeLayout(false);
            this.tabContact.PerformLayout();
            this.tabEducation.ResumeLayout(false);
            this.tabEducation.PerformLayout();
            this.tabSkills.ResumeLayout(false);
            this.tabSkills.PerformLayout();
            this.tabWorkExperience.ResumeLayout(false);
            this.tabWorkExperience.PerformLayout();
            this.tabPersonal.ResumeLayout(false);
            this.tabPersonal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmailDisplay;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAddress;
        private System.Windows.Forms.TabPage tabContact;
        private System.Windows.Forms.TabPage tabEducation;
        private System.Windows.Forms.TabPage tabSkills;
        private System.Windows.Forms.TabPage tabWorkExperience;
        private System.Windows.Forms.TabPage tabPersonal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtFullName;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label txtProvince;
        private System.Windows.Forms.Label txtCity;
        private System.Windows.Forms.Label txtAddress;
        private System.Windows.Forms.Label txtZipCode;
        private System.Windows.Forms.Label txtPhone;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.Label txtYearGrad;
        private System.Windows.Forms.Label txtDegree;
        private System.Windows.Forms.Label txtSchool;
        private System.Windows.Forms.TextBox txtSkills;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtPosition;
        private System.Windows.Forms.Label txtCompany;
    }
}