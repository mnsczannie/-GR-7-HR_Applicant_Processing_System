namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmApplicantLogin
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
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.linklblFgtPass = new System.Windows.Forms.LinkLabel();
            this.CheckbxShowPas = new System.Windows.Forms.CheckBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCreateAcc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(525, 175);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(273, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HR Applicant Portal";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lblSubtitle.Location = new System.Drawing.Point(555, 207);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(217, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Sign in to your applicant account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(525, 256);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.Location = new System.Drawing.Point(525, 275);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(233, 27);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label3.Location = new System.Drawing.Point(525, 309);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(525, 327);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(233, 27);
            this.txtPassword.TabIndex = 5;
            // 
            // linklblFgtPass
            // 
            this.linklblFgtPass.AutoSize = true;
            this.linklblFgtPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linklblFgtPass.Location = new System.Drawing.Point(525, 358);
            this.linklblFgtPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linklblFgtPass.Name = "linklblFgtPass";
            this.linklblFgtPass.Size = new System.Drawing.Size(100, 15);
            this.linklblFgtPass.TabIndex = 6;
            this.linklblFgtPass.TabStop = true;
            this.linklblFgtPass.Text = "Forgot Password?";
            this.linklblFgtPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblFgtPass_LinkClicked);
            // 
            // CheckbxShowPas
            // 
            this.CheckbxShowPas.AutoSize = true;
            this.CheckbxShowPas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckbxShowPas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CheckbxShowPas.Location = new System.Drawing.Point(630, 358);
            this.CheckbxShowPas.Margin = new System.Windows.Forms.Padding(2);
            this.CheckbxShowPas.Name = "CheckbxShowPas";
            this.CheckbxShowPas.Size = new System.Drawing.Size(108, 19);
            this.CheckbxShowPas.TabIndex = 7;
            this.CheckbxShowPas.Text = "Show Password";
            this.CheckbxShowPas.CheckedChanged += new System.EventHandler(this.CheckbxShowPas_CheckedChanged);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(525, 386);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(232, 34);
            this.btnLogIn.TabIndex = 8;
            this.btnLogIn.Text = "LOGIN";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnClear.Location = new System.Drawing.Point(525, 428);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(232, 31);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.label5.Location = new System.Drawing.Point(525, 504);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Don\'t Have an Account?";
            // 
            // lblCreateAcc
            // 
            this.lblCreateAcc.AutoSize = true;
            this.lblCreateAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCreateAcc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCreateAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.lblCreateAcc.Location = new System.Drawing.Point(525, 522);
            this.lblCreateAcc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreateAcc.Name = "lblCreateAcc";
            this.lblCreateAcc.Size = new System.Drawing.Size(111, 19);
            this.lblCreateAcc.TabIndex = 12;
            this.lblCreateAcc.Text = "Create Account";
            this.lblCreateAcc.Click += new System.EventHandler(this.lblCreateAcc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 0);
            this.label1.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 0);
            this.label4.TabIndex = 99;
            // 
            // frmApplicantLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.linklblFgtPass);
            this.Controls.Add(this.CheckbxShowPas);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCreateAcc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmApplicantLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applicant Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmApplicantLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel linklblFgtPass;
        private System.Windows.Forms.CheckBox CheckbxShowPas;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCreateAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}