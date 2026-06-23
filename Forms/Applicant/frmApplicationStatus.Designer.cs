namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmApplicationStatus
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
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.lblStep1Text = new System.Windows.Forms.Label();
            this.lblStep2Text = new System.Windows.Forms.Label();
            this.lblStep3Text = new System.Windows.Forms.Label();
            this.lblStep4Text = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewStatus = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnMyApplication = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnJobVacancies = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCurrentStatus.Location = new System.Drawing.Point(346, 84);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(141, 26);
            this.lblCurrentStatus.TabIndex = 1;
            this.lblCurrentStatus.Text = "Current Status: --";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.lblResult.Location = new System.Drawing.Point(6, 24);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(84, 22);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Final Result: ";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblRemarks.Location = new System.Drawing.Point(6, 20);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(79, 22);
            this.lblRemarks.TabIndex = 0;
            this.lblRemarks.Text = "Remarks: --";
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblSchedule.Location = new System.Drawing.Point(4, 28);
            this.lblSchedule.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(167, 22);
            this.lblSchedule.TabIndex = 0;
            this.lblSchedule.Text = "Schedule: Not yet scheduled";
            // 
            // lblStep1
            // 
            this.lblStep1.BackColor = System.Drawing.Color.Gray;
            this.lblStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep1.Location = new System.Drawing.Point(350, 126);
            this.lblStep1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(16, 17);
            this.lblStep1.TabIndex = 2;
            // 
            // lblStep2
            // 
            this.lblStep2.BackColor = System.Drawing.Color.Gray;
            this.lblStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep2.Location = new System.Drawing.Point(350, 158);
            this.lblStep2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(16, 17);
            this.lblStep2.TabIndex = 4;
            // 
            // lblStep3
            // 
            this.lblStep3.BackColor = System.Drawing.Color.Gray;
            this.lblStep3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep3.Location = new System.Drawing.Point(350, 191);
            this.lblStep3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(16, 17);
            this.lblStep3.TabIndex = 6;
            // 
            // lblStep4
            // 
            this.lblStep4.BackColor = System.Drawing.Color.Gray;
            this.lblStep4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep4.Location = new System.Drawing.Point(350, 223);
            this.lblStep4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(16, 17);
            this.lblStep4.TabIndex = 8;
            // 
            // lblStep1Text
            // 
            this.lblStep1Text.AutoSize = true;
            this.lblStep1Text.Font = new System.Drawing.Font("Patrick Hand", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStep1Text.Location = new System.Drawing.Point(370, 126);
            this.lblStep1Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep1Text.Name = "lblStep1Text";
            this.lblStep1Text.Size = new System.Drawing.Size(126, 21);
            this.lblStep1Text.TabIndex = 3;
            this.lblStep1Text.Text = "Application Submitted";
            // 
            // lblStep2Text
            // 
            this.lblStep2Text.AutoSize = true;
            this.lblStep2Text.Font = new System.Drawing.Font("Patrick Hand", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStep2Text.Location = new System.Drawing.Point(370, 158);
            this.lblStep2Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep2Text.Name = "lblStep2Text";
            this.lblStep2Text.Size = new System.Drawing.Size(81, 21);
            this.lblStep2Text.TabIndex = 5;
            this.lblStep2Text.Text = "Under Review";
            // 
            // lblStep3Text
            // 
            this.lblStep3Text.AutoSize = true;
            this.lblStep3Text.Font = new System.Drawing.Font("Patrick Hand", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStep3Text.Location = new System.Drawing.Point(370, 191);
            this.lblStep3Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep3Text.Name = "lblStep3Text";
            this.lblStep3Text.Size = new System.Drawing.Size(60, 21);
            this.lblStep3Text.TabIndex = 7;
            this.lblStep3Text.Text = "Interview";
            // 
            // lblStep4Text
            // 
            this.lblStep4Text.AutoSize = true;
            this.lblStep4Text.Font = new System.Drawing.Font("Patrick Hand", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep4Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStep4Text.Location = new System.Drawing.Point(370, 223);
            this.lblStep4Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep4Text.Name = "lblStep4Text";
            this.lblStep4Text.Size = new System.Drawing.Size(83, 21);
            this.lblStep4Text.TabIndex = 9;
            this.lblStep4Text.Text = "Final Decision";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRemarks);
            this.groupBox1.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(1008, 120);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(290, 196);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HR Remarks";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSchedule);
            this.groupBox2.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox2.Location = new System.Drawing.Point(769, 120);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(203, 326);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interview Schedule";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblResult);
            this.groupBox3.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox3.Location = new System.Drawing.Point(527, 120);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(203, 326);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Final Result";
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.dgvHistory);
            this.grpHistory.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHistory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpHistory.Location = new System.Drawing.Point(527, 461);
            this.grpHistory.Margin = new System.Windows.Forms.Padding(2);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Padding = new System.Windows.Forms.Padding(2);
            this.grpHistory.Size = new System.Drawing.Size(771, 244);
            this.grpHistory.TabIndex = 10;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "Application History";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeight = 29;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(2, 24);
            this.dgvHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.Size = new System.Drawing.Size(767, 218);
            this.dgvHistory.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 742);
            this.panel1.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Location = new System.Drawing.Point(0, 606);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(317, 111);
            this.panel3.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::HRApplicantSystem.Properties.Resources.projectlog;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(146, -4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 60);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.SaddleBrown;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Patrick Hand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(204, 68);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 2;
            this.textBox6.Text = "APPLICANT";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SaddleBrown;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Patrick Hand", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(183, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(106, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::HRApplicantSystem.Properties.Resources.cato1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(-43, -49);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(253, 182);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Goldenrod;
            this.panel2.Controls.Add(this.btnViewStatus);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btnMyApplication);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnJobVacancies);
            this.panel2.Controls.Add(this.btnProfile);
            this.panel2.Location = new System.Drawing.Point(3, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 724);
            this.panel2.TabIndex = 14;
            // 
            // btnViewStatus
            // 
            this.btnViewStatus.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnViewStatus.FlatAppearance.BorderSize = 0;
            this.btnViewStatus.Font = new System.Drawing.Font("Patrick Hand", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStatus.ForeColor = System.Drawing.Color.Black;
            this.btnViewStatus.Location = new System.Drawing.Point(-1, 300);
            this.btnViewStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewStatus.Name = "btnViewStatus";
            this.btnViewStatus.Size = new System.Drawing.Size(315, 52);
            this.btnViewStatus.TabIndex = 1;
            this.btnViewStatus.Text = "     Application Status";
            this.btnViewStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewStatus.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Goldenrod;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-2, 513);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(315, 52);
            this.button2.TabIndex = 14;
            this.button2.Text = "     My Documents";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::HRApplicantSystem.Properties.Resources.cato1;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(-46, 548);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(253, 182);
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Goldenrod;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox5.Location = new System.Drawing.Point(17, 448);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(192, 26);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "PROFILE";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Goldenrod;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(-2, 251);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(316, 52);
            this.button4.TabIndex = 14;
            this.button4.Text = "     Dashboard";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Goldenrod;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox4.Location = new System.Drawing.Point(17, 224);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(192, 26);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "MAIN";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HRApplicantSystem.Properties.Resources.projectlog;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(90, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 61);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // btnMyApplication
            // 
            this.btnMyApplication.BackColor = System.Drawing.Color.Goldenrod;
            this.btnMyApplication.FlatAppearance.BorderSize = 0;
            this.btnMyApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyApplication.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyApplication.ForeColor = System.Drawing.Color.Black;
            this.btnMyApplication.Location = new System.Drawing.Point(-1, 471);
            this.btnMyApplication.Margin = new System.Windows.Forms.Padding(2);
            this.btnMyApplication.Name = "btnMyApplication";
            this.btnMyApplication.Size = new System.Drawing.Size(313, 52);
            this.btnMyApplication.TabIndex = 11;
            this.btnMyApplication.Text = "     My Application";
            this.btnMyApplication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyApplication.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Goldenrod;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Amatic SC", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.textBox3.Location = new System.Drawing.Point(135, 23);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(192, 27);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "C-ARTPROJECT_G7";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Goldenrod;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Amatic SC", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(140, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 41);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "C-ARTPROJECT_G7";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HRApplicantSystem.Properties.Resources.snoop_removebg_preview__2_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 232);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnJobVacancies
            // 
            this.btnJobVacancies.BackColor = System.Drawing.Color.Goldenrod;
            this.btnJobVacancies.FlatAppearance.BorderSize = 0;
            this.btnJobVacancies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobVacancies.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobVacancies.ForeColor = System.Drawing.Color.Black;
            this.btnJobVacancies.Location = new System.Drawing.Point(-5, 345);
            this.btnJobVacancies.Margin = new System.Windows.Forms.Padding(2);
            this.btnJobVacancies.Name = "btnJobVacancies";
            this.btnJobVacancies.Size = new System.Drawing.Size(317, 52);
            this.btnJobVacancies.TabIndex = 10;
            this.btnJobVacancies.Text = "     Job Vacancies";
            this.btnJobVacancies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobVacancies.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Goldenrod;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Patrick Hand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.Black;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(-3, 391);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(315, 52);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "     My Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel4.Controls.Add(this.lblTime);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(336, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1030, 59);
            this.panel4.TabIndex = 15;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Patrick Hand", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblTime.Location = new System.Drawing.Point(927, 11);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(95, 36);
            this.lblTime.TabIndex = 105;
            this.lblTime.Text = "lblTime";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Patrick Hand", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Status";
            // 
            // frmApplicationStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblStep1Text);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblStep2Text);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.lblStep3Text);
            this.Controls.Add(this.lblStep4);
            this.Controls.Add(this.lblStep4Text);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmApplicationStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Status";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmApplicationStatus_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Label lblStep1Text;
        private System.Windows.Forms.Label lblStep2Text;
        private System.Windows.Forms.Label lblStep3Text;
        private System.Windows.Forms.Label lblStep4Text;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnMyApplication;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnJobVacancies;
        private System.Windows.Forms.Button btnViewStatus;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
    }
}