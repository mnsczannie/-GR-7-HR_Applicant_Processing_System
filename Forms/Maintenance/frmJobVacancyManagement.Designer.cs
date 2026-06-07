namespace HRApplicantSystem.Forms.Maintenance
{
    partial class frmJobVacancyManagement
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
            this.dgvVacancies = new System.Windows.Forms.DataGridView();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblRequirements = new System.Windows.Forms.Label();
            this.clbRequirements = new System.Windows.Forms.CheckedListBox();
            this.numSlots = new System.Windows.Forms.NumericUpDown();
            this.lblSlots = new System.Windows.Forms.Label();
            this.txtQualifications = new System.Windows.Forms.TextBox();
            this.lblQualifications = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbEmpType = new System.Windows.Forms.ComboBox();
            this.lblEmpType = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCloseVacancy = new System.Windows.Forms.Button();
            this.btnReopenVacancy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacancies)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSlots)).BeginInit();
            this.SuspendLayout();

            this.dgvVacancies.AllowUserToAddRows = false;
            this.dgvVacancies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVacancies.Location = new System.Drawing.Point(12, 45);
            this.dgvVacancies.Name = "dgvVacancies";
            this.dgvVacancies.ReadOnly = true;
            this.dgvVacancies.RowHeadersWidth = 51;
            this.dgvVacancies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVacancies.Size = new System.Drawing.Size(560, 480);
            this.dgvVacancies.TabIndex = 2;
            this.dgvVacancies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVacancies_CellClick);
 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] { "All", "Open", "Closed" });
            this.cmbStatusFilter.Location = new System.Drawing.Point(90, 12);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 23);
            this.cmbStatusFilter.TabIndex = 1;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);

            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(12, 15);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(72, 15);
            this.lblStatusFilter.TabIndex = 0;
            this.lblStatusFilter.Text = "Filter Status:";

            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.lblRequirements);
            this.pnlForm.Controls.Add(this.clbRequirements);
            this.pnlForm.Controls.Add(this.numSlots);
            this.pnlForm.Controls.Add(this.lblSlots);
            this.pnlForm.Controls.Add(this.txtQualifications);
            this.pnlForm.Controls.Add(this.lblQualifications);
            this.pnlForm.Controls.Add(this.txtDescription);
            this.pnlForm.Controls.Add(this.lblDescription);
            this.pnlForm.Controls.Add(this.cmbEmpType);
            this.pnlForm.Controls.Add(this.lblEmpType);
            this.pnlForm.Controls.Add(this.cmbDepartment);
            this.pnlForm.Controls.Add(this.lblDepartment);
            this.pnlForm.Controls.Add(this.cmbPosition);
            this.pnlForm.Controls.Add(this.lblPosition);
            this.pnlForm.Location = new System.Drawing.Point(585, 45);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(387, 430);
            this.pnlForm.TabIndex = 3;

            this.lblRequirements.AutoSize = true;
            this.lblRequirements.Location = new System.Drawing.Point(13, 315);
            this.lblRequirements.Name = "lblRequirements";
            this.lblRequirements.Size = new System.Drawing.Size(82, 15);
            this.lblRequirements.TabIndex = 12;
            this.lblRequirements.Text = "Requirements:";

            this.clbRequirements.FormattingEnabled = true;
            this.clbRequirements.Location = new System.Drawing.Point(120, 315);
            this.clbRequirements.Name = "clbRequirements";
            this.clbRequirements.Size = new System.Drawing.Size(250, 94);
            this.clbRequirements.TabIndex = 13;

            this.numSlots.Location = new System.Drawing.Point(120, 275);
            this.numSlots.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numSlots.Name = "numSlots";
            this.numSlots.Size = new System.Drawing.Size(120, 23);
            this.numSlots.TabIndex = 11;

            this.lblSlots.AutoSize = true;
            this.lblSlots.Location = new System.Drawing.Point(13, 277);
            this.lblSlots.Name = "lblSlots";
            this.lblSlots.Size = new System.Drawing.Size(83, 15);
            this.lblSlots.TabIndex = 10;
            this.lblSlots.Text = "Available Slots:";

            this.txtQualifications.Location = new System.Drawing.Point(120, 195);
            this.txtQualifications.Multiline = true;
            this.txtQualifications.Name = "txtQualifications";
            this.txtQualifications.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQualifications.Size = new System.Drawing.Size(250, 65);
            this.txtQualifications.TabIndex = 9;

            this.lblQualifications.AutoSize = true;
            this.lblQualifications.Location = new System.Drawing.Point(13, 198);
            this.lblQualifications.Name = "lblQualifications";
            this.lblQualifications.Size = new System.Drawing.Size(82, 15);
            this.lblQualifications.TabIndex = 8;
            this.lblQualifications.Text = "Qualifications:";

            this.txtDescription.Location = new System.Drawing.Point(120, 115);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(250, 65);
            this.txtDescription.TabIndex = 7;

            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 118);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description:";

            this.cmbEmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpType.FormattingEnabled = true;
            this.cmbEmpType.Location = new System.Drawing.Point(120, 78);
            this.cmbEmpType.Name = "cmbEmpType";
            this.cmbEmpType.Size = new System.Drawing.Size(250, 23);
            this.cmbEmpType.TabIndex = 5;
   
            this.lblEmpType.AutoSize = true;
            this.lblEmpType.Location = new System.Drawing.Point(13, 81);
            this.lblEmpType.Name = "lblEmpType";
            this.lblEmpType.Size = new System.Drawing.Size(104, 15);
            this.lblEmpType.TabIndex = 4;
            this.lblEmpType.Text = "Employment Type:";

            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(120, 42);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(250, 23);
            this.cmbDepartment.TabIndex = 3;

            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(13, 45);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(73, 15);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Department:";
 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(120, 6);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(250, 23);
            this.cmbPosition.TabIndex = 1;

            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(13, 9);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(53, 15);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "Position:";

            this.btnSave.Location = new System.Drawing.Point(585, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Vacancy";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCloseVacancy.Location = new System.Drawing.Point(681, 490);
            this.btnCloseVacancy.Name = "btnCloseVacancy";
            this.btnCloseVacancy.Size = new System.Drawing.Size(95, 35);
            this.btnCloseVacancy.TabIndex = 5;
            this.btnCloseVacancy.Text = "Close Vacancy";
            this.btnCloseVacancy.UseVisualStyleBackColor = true;
            this.btnCloseVacancy.Click += new System.EventHandler(this.btnCloseVacancy_Click);

            this.btnReopenVacancy.Location = new System.Drawing.Point(782, 490);
            this.btnReopenVacancy.Name = "btnReopenVacancy";
            this.btnReopenVacancy.Size = new System.Drawing.Size(95, 35);
            this.btnReopenVacancy.TabIndex = 6;
            this.btnReopenVacancy.Text = "Reopen";
            this.btnReopenVacancy.UseVisualStyleBackColor = true;
            this.btnReopenVacancy.Click += new System.EventHandler(this.btnReopenVacancy_Click);

            this.btnClear.Location = new System.Drawing.Point(883, 490);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 35);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 541);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReopenVacancy);
            this.Controls.Add(this.btnCloseVacancy);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.lblStatusFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.dgvVacancies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmJobVacancyManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job Vacancy Management";
            this.Load += new System.EventHandler(this.frmJobVacancyManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacancies)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSlots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.DataGridView dgvVacancies;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblEmpType;
        private System.Windows.Forms.ComboBox cmbEmpType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblQualifications;
        private System.Windows.Forms.TextBox txtQualifications;
        private System.Windows.Forms.Label lblSlots;
        private System.Windows.Forms.NumericUpDown numSlots;
        private System.Windows.Forms.Label lblRequirements;
        private System.Windows.Forms.CheckedListBox clbRequirements;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseVacancy;
        private System.Windows.Forms.Button btnReopenVacancy;
        private System.Windows.Forms.Button btnClear;
    }
}