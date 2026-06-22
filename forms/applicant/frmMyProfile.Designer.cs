namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmMyProfile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDocs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFN = new System.Windows.Forms.Label();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.lblMI = new System.Windows.Forms.Label();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.lblLN = new System.Windows.Forms.Label();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.lblBday = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblEducation = new System.Windows.Forms.Label();
            this.txtEducation = new System.Windows.Forms.TextBox();
            this.lblDegree = new System.Windows.Forms.Label();
            this.txtDegree = new System.Windows.Forms.TextBox();
            this.lblYearGrad = new System.Windows.Forms.Label();
            this.txtYearGrad = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblSkills = new System.Windows.Forms.Label();
            this.txtSkills = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblWorkExp = new System.Windows.Forms.Label();
            this.txtWorkExp = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(170, 56);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Profile";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lblSubtitle.Location = new System.Drawing.Point(172, 91);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(295, 16);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "View and update your personal information";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnEdit.Location = new System.Drawing.Point(982, 579);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 28);
            this.btnEdit.TabIndex = 100;
            this.btnEdit.Text = "Edit Profile";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1090, 579);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 28);
            this.btnSave.TabIndex = 101;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnBack.Location = new System.Drawing.Point(1250, 29);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 28);
            this.btnBack.TabIndex = 102;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDocs
            // 
            this.btnDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocs.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnDocs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnDocs.Location = new System.Drawing.Point(817, 579);
            this.btnDocs.Margin = new System.Windows.Forms.Padding(2);
            this.btnDocs.Name = "btnDocs";
            this.btnDocs.Size = new System.Drawing.Size(148, 28);
            this.btnDocs.TabIndex = 103;
            this.btnDocs.Text = "My Documents";
            this.btnDocs.UseVisualStyleBackColor = true;
            this.btnDocs.Click += new System.EventHandler(this.btnDocs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFN);
            this.groupBox1.Controls.Add(this.txtFN);
            this.groupBox1.Controls.Add(this.lblMI);
            this.groupBox1.Controls.Add(this.txtMI);
            this.groupBox1.Controls.Add(this.lblLN);
            this.groupBox1.Controls.Add(this.txtLN);
            this.groupBox1.Controls.Add(this.lblBday);
            this.groupBox1.Controls.Add(this.dtpBirthday);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox1.Location = new System.Drawing.Point(204, 140);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(470, 121);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information";
            // 
            // lblFN
            // 
            this.lblFN.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblFN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblFN.Location = new System.Drawing.Point(6, 20);
            this.lblFN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(72, 16);
            this.lblFN.TabIndex = 0;
            this.lblFN.Text = "First Name:";
            this.lblFN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFN
            // 
            this.txtFN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFN.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtFN.Location = new System.Drawing.Point(82, 18);
            this.txtFN.Margin = new System.Windows.Forms.Padding(2);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(120, 24);
            this.txtFN.TabIndex = 1;
            // 
            // lblMI
            // 
            this.lblMI.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblMI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblMI.Location = new System.Drawing.Point(208, 20);
            this.lblMI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMI.Name = "lblMI";
            this.lblMI.Size = new System.Drawing.Size(32, 16);
            this.lblMI.TabIndex = 2;
            this.lblMI.Text = "M.I.:";
            this.lblMI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMI
            // 
            this.txtMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMI.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtMI.Location = new System.Drawing.Point(244, 18);
            this.txtMI.Margin = new System.Windows.Forms.Padding(2);
            this.txtMI.MaxLength = 5;
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(38, 24);
            this.txtMI.TabIndex = 2;
            // 
            // lblLN
            // 
            this.lblLN.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblLN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblLN.Location = new System.Drawing.Point(6, 47);
            this.lblLN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLN.Name = "lblLN";
            this.lblLN.Size = new System.Drawing.Size(72, 16);
            this.lblLN.TabIndex = 3;
            this.lblLN.Text = "Last Name:";
            this.lblLN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLN
            // 
            this.txtLN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLN.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtLN.Location = new System.Drawing.Point(82, 45);
            this.txtLN.Margin = new System.Windows.Forms.Padding(2);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(120, 24);
            this.txtLN.TabIndex = 3;
            // 
            // lblBday
            // 
            this.lblBday.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblBday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblBday.Location = new System.Drawing.Point(202, 47);
            this.lblBday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBday.Name = "lblBday";
            this.lblBday.Size = new System.Drawing.Size(57, 16);
            this.lblBday.TabIndex = 4;
            this.lblBday.Text = "Birthday:";
            this.lblBday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CustomFormat = "MMMM dd, yyyy";
            this.dtpBirthday.Font = new System.Drawing.Font("Verdana", 9F);
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(262, 46);
            this.dtpBirthday.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(136, 22);
            this.dtpBirthday.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAddress);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.lblCity);
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.lblProvince);
            this.groupBox2.Controls.Add(this.txtProvince);
            this.groupBox2.Controls.Add(this.lblZip);
            this.groupBox2.Controls.Add(this.txtZip);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox2.Location = new System.Drawing.Point(204, 276);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(470, 124);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblAddress.Location = new System.Drawing.Point(6, 20);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 16);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Street:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtAddress.Location = new System.Drawing.Point(60, 18);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(398, 24);
            this.txtAddress.TabIndex = 6;
            // 
            // lblCity
            // 
            this.lblCity.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblCity.Location = new System.Drawing.Point(6, 47);
            this.lblCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(48, 16);
            this.lblCity.TabIndex = 7;
            this.lblCity.Text = "City:";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtCity.Location = new System.Drawing.Point(60, 45);
            this.txtCity.Margin = new System.Windows.Forms.Padding(2);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(150, 24);
            this.txtCity.TabIndex = 7;
            // 
            // lblProvince
            // 
            this.lblProvince.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblProvince.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblProvince.Location = new System.Drawing.Point(232, 47);
            this.lblProvince.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(60, 16);
            this.lblProvince.TabIndex = 8;
            this.lblProvince.Text = "Province:";
            this.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvince
            // 
            this.txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProvince.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtProvince.Location = new System.Drawing.Point(297, 45);
            this.txtProvince.Margin = new System.Windows.Forms.Padding(2);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(161, 24);
            this.txtProvince.TabIndex = 9;
            // 
            // lblZip
            // 
            this.lblZip.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblZip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblZip.Location = new System.Drawing.Point(6, 74);
            this.lblZip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(48, 16);
            this.lblZip.TabIndex = 10;
            this.lblZip.Text = "Zip:";
            this.lblZip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtZip
            // 
            this.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZip.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtZip.Location = new System.Drawing.Point(60, 72);
            this.txtZip.Margin = new System.Windows.Forms.Padding(2);
            this.txtZip.MaxLength = 10;
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(90, 24);
            this.txtZip.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPhone);
            this.groupBox3.Controls.Add(this.txtPhone);
            this.groupBox3.Controls.Add(this.lblEmail);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox3.Location = new System.Drawing.Point(204, 422);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(470, 135);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contact Details";
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblPhone.Location = new System.Drawing.Point(6, 20);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(48, 16);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "Phone:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPhone.Location = new System.Drawing.Point(60, 18);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(150, 24);
            this.txtPhone.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblEmail.Location = new System.Drawing.Point(6, 47);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 16);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtEmail.Location = new System.Drawing.Point(60, 45);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(226, 24);
            this.txtEmail.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblEducation);
            this.groupBox4.Controls.Add(this.txtEducation);
            this.groupBox4.Controls.Add(this.lblDegree);
            this.groupBox4.Controls.Add(this.txtDegree);
            this.groupBox4.Controls.Add(this.lblYearGrad);
            this.groupBox4.Controls.Add(this.txtYearGrad);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox4.Location = new System.Drawing.Point(689, 148);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(499, 131);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Education";
            // 
            // lblEducation
            // 
            this.lblEducation.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblEducation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblEducation.Location = new System.Drawing.Point(6, 23);
            this.lblEducation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(60, 16);
            this.lblEducation.TabIndex = 0;
            this.lblEducation.Text = "School:";
            this.lblEducation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEducation
            // 
            this.txtEducation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEducation.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtEducation.Location = new System.Drawing.Point(71, 20);
            this.txtEducation.Margin = new System.Windows.Forms.Padding(2);
            this.txtEducation.Name = "txtEducation";
            this.txtEducation.Size = new System.Drawing.Size(413, 24);
            this.txtEducation.TabIndex = 12;
            // 
            // lblDegree
            // 
            this.lblDegree.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblDegree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblDegree.Location = new System.Drawing.Point(6, 52);
            this.lblDegree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(60, 16);
            this.lblDegree.TabIndex = 13;
            this.lblDegree.Text = "Degree:";
            this.lblDegree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDegree
            // 
            this.txtDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDegree.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtDegree.Location = new System.Drawing.Point(71, 50);
            this.txtDegree.Margin = new System.Windows.Forms.Padding(2);
            this.txtDegree.Name = "txtDegree";
            this.txtDegree.Size = new System.Drawing.Size(413, 24);
            this.txtDegree.TabIndex = 14;
            // 
            // lblYearGrad
            // 
            this.lblYearGrad.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblYearGrad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblYearGrad.Location = new System.Drawing.Point(6, 81);
            this.lblYearGrad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYearGrad.Name = "lblYearGrad";
            this.lblYearGrad.Size = new System.Drawing.Size(105, 16);
            this.lblYearGrad.TabIndex = 15;
            this.lblYearGrad.Text = "Year Graduated:";
            this.lblYearGrad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYearGrad
            // 
            this.txtYearGrad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYearGrad.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtYearGrad.Location = new System.Drawing.Point(116, 79);
            this.txtYearGrad.Margin = new System.Windows.Forms.Padding(2);
            this.txtYearGrad.MaxLength = 4;
            this.txtYearGrad.Name = "txtYearGrad";
            this.txtYearGrad.Size = new System.Drawing.Size(76, 24);
            this.txtYearGrad.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblSkills);
            this.groupBox5.Controls.Add(this.txtSkills);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox5.Location = new System.Drawing.Point(689, 284);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(499, 124);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Skills";
            // 
            // lblSkills
            // 
            this.lblSkills.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblSkills.Location = new System.Drawing.Point(6, 20);
            this.lblSkills.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(60, 16);
            this.lblSkills.TabIndex = 0;
            this.lblSkills.Text = "Skills:";
            this.lblSkills.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSkills
            // 
            this.txtSkills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSkills.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtSkills.Location = new System.Drawing.Point(71, 18);
            this.txtSkills.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkills.Multiline = true;
            this.txtSkills.Name = "txtSkills";
            this.txtSkills.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSkills.Size = new System.Drawing.Size(413, 90);
            this.txtSkills.TabIndex = 14;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblWorkExp);
            this.groupBox6.Controls.Add(this.txtWorkExp);
            this.groupBox6.Controls.Add(this.lblPosition);
            this.groupBox6.Controls.Add(this.txtPosition);
            this.groupBox6.Controls.Add(this.lblDuration);
            this.groupBox6.Controls.Add(this.txtDuration);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.groupBox6.Location = new System.Drawing.Point(689, 430);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(499, 135);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Work Experience";
            // 
            // lblWorkExp
            // 
            this.lblWorkExp.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblWorkExp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblWorkExp.Location = new System.Drawing.Point(6, 23);
            this.lblWorkExp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkExp.Name = "lblWorkExp";
            this.lblWorkExp.Size = new System.Drawing.Size(82, 16);
            this.lblWorkExp.TabIndex = 0;
            this.lblWorkExp.Text = "Company:";
            this.lblWorkExp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkExp
            // 
            this.txtWorkExp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkExp.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtWorkExp.Location = new System.Drawing.Point(94, 20);
            this.txtWorkExp.Margin = new System.Windows.Forms.Padding(2);
            this.txtWorkExp.Name = "txtWorkExp";
            this.txtWorkExp.Size = new System.Drawing.Size(398, 24);
            this.txtWorkExp.TabIndex = 16;
            // 
            // lblPosition
            // 
            this.lblPosition.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblPosition.Location = new System.Drawing.Point(6, 52);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(82, 16);
            this.lblPosition.TabIndex = 17;
            this.lblPosition.Text = "Position:";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPosition
            // 
            this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosition.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPosition.Location = new System.Drawing.Point(94, 50);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(2);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(398, 24);
            this.txtPosition.TabIndex = 18;
            // 
            // lblDuration
            // 
            this.lblDuration.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblDuration.Location = new System.Drawing.Point(6, 81);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(82, 16);
            this.lblDuration.TabIndex = 19;
            this.lblDuration.Text = "Duration:";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuration
            // 
            this.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuration.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtDuration.Location = new System.Drawing.Point(94, 79);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(398, 24);
            this.txtDuration.TabIndex = 20;
            // 
            // frmMyProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.btnDocs);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Name = "frmMyProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMyProfile_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDocs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;

        private System.Windows.Forms.Label lblFN;
        private System.Windows.Forms.Label lblMI;
        private System.Windows.Forms.Label lblLN;
        private System.Windows.Forms.Label lblBday;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.DateTimePicker dtpBirthday;

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.TextBox txtZip;

        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.Label lblYearGrad;
        private System.Windows.Forms.TextBox txtEducation;
        private System.Windows.Forms.TextBox txtDegree;
        private System.Windows.Forms.TextBox txtYearGrad;

        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.TextBox txtSkills;

        private System.Windows.Forms.Label lblWorkExp;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtWorkExp;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtDuration;
    }
}