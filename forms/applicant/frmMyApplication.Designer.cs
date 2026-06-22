// =============================================================
//  frmMyApplication.Designer.cs
//
//  CHANGES FROM ORIGINAL
//  ─────────────────────
//  1. btnDelete.Click wired to btnDelete_Click (was missing).
//  2. btnEdit   text changed to "Edit Position".
//  3. Added btnWithdraw (new button, replaces "Edit/Withdraw"
//     dual purpose — each action now has its own button).
//  4. Added cboVacancy (ComboBox) and lblPickJob (Label) for
//     the Edit-position feature; hidden by default.
// =============================================================

namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmMyApplication
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
            this.listViewApps = new System.Windows.Forms.ListView();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUploadDocs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPickJob = new System.Windows.Forms.Label();
            this.cboVacancy = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listViewApps
            // 
            this.listViewApps.HideSelection = false;
            this.listViewApps.Location = new System.Drawing.Point(20, 89);
            this.listViewApps.Name = "listViewApps";
            this.listViewApps.Size = new System.Drawing.Size(961, 417);
            this.listViewApps.TabIndex = 0;
            this.listViewApps.UseCompatibleStateImageBehavior = false;
            this.listViewApps.SelectedIndexChanged += new System.EventHandler(this.listViewApps_SelectedIndexChanged);
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.btnSaveDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDraft.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveDraft.ForeColor = System.Drawing.Color.White;
            this.btnSaveDraft.Location = new System.Drawing.Point(1088, 89);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(214, 36);
            this.btnSaveDraft.TabIndex = 1;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = false;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(1088, 135);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(214, 36);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(1088, 180);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(214, 36);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit Position";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdraw.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnWithdraw.ForeColor = System.Drawing.Color.White;
            this.btnWithdraw.Location = new System.Drawing.Point(1088, 226);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(214, 36);
            this.btnWithdraw.TabIndex = 4;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = false;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1088, 271);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(214, 36);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnBack.Location = new System.Drawing.Point(1088, 414);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(214, 36);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUploadDocs
            // 
            this.btnUploadDocs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnUploadDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadDocs.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnUploadDocs.ForeColor = System.Drawing.Color.White;
            this.btnUploadDocs.Location = new System.Drawing.Point(1088, 317);
            this.btnUploadDocs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUploadDocs.Name = "btnUploadDocs";
            this.btnUploadDocs.Size = new System.Drawing.Size(214, 36);
            this.btnUploadDocs.TabIndex = 7;
            this.btnUploadDocs.Text = "Upload Documents";
            this.btnUploadDocs.UseVisualStyleBackColor = false;
            this.btnUploadDocs.Click += new System.EventHandler(this.btnUploadDocs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.label2.Location = new System.Drawing.Point(20, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(694, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select an application to manage it. Drafts are created when you apply on the Job " +
    "Vacancies page.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(211, 29);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "My Application";
            // 
            // lblPickJob
            // 
            this.lblPickJob.AutoSize = true;
            this.lblPickJob.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
            this.lblPickJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            this.lblPickJob.Location = new System.Drawing.Point(20, 524);
            this.lblPickJob.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPickJob.Name = "lblPickJob";
            this.lblPickJob.Size = new System.Drawing.Size(279, 14);
            this.lblPickJob.TabIndex = 20;
            this.lblPickJob.Text = "Choose a new position, then click Save Draft:";
            this.lblPickJob.Visible = false;
            // 
            // cboVacancy
            // 
            this.cboVacancy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVacancy.Font = new System.Drawing.Font("Verdana", 10F);
            this.cboVacancy.Location = new System.Drawing.Point(20, 545);
            this.cboVacancy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboVacancy.Name = "cboVacancy";
            this.cboVacancy.Size = new System.Drawing.Size(646, 24);
            this.cboVacancy.TabIndex = 21;
            this.cboVacancy.Visible = false;
            this.cboVacancy.SelectedIndexChanged += new System.EventHandler(this.cboVacancy_SelectedIndexChanged);
            // 
            // frmMyApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 741);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewApps);
            this.Controls.Add(this.lblPickJob);
            this.Controls.Add(this.cboVacancy);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUploadDocs);
            this.Controls.Add(this.btnBack);
            this.MinimumSize = new System.Drawing.Size(859, 511);
            this.Name = "frmMyApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMyApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewApps;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPickJob;
        private System.Windows.Forms.ComboBox cboVacancy;
        private System.Windows.Forms.Button btnUploadDocs;
    }
}