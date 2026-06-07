namespace HRApplicantSystem.Forms.Maintenance
{
    partial class frmPositions
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
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.txtPositionTitle = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.SuspendLayout();

            this.dgvPositions.AllowUserToAddRows = false;
            this.dgvPositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Location = new System.Drawing.Point(12, 12);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.ReadOnly = true;
            this.dgvPositions.RowHeadersWidth = 51;
            this.dgvPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPositions.Size = new System.Drawing.Size(460, 180);
            this.dgvPositions.TabIndex = 0;
            this.dgvPositions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPositions_CellClick);

            this.txtPositionTitle.Location = new System.Drawing.Point(130, 210);
            this.txtPositionTitle.Name = "txtPositionTitle";
            this.txtPositionTitle.Size = new System.Drawing.Size(342, 23);
            this.txtPositionTitle.TabIndex = 1;

            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(130, 245);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(342, 23);
            this.cmbDepartment.TabIndex = 2;

            this.lblTitle.Location = new System.Drawing.Point(12, 213);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Position Title:";

            this.lblDept.Location = new System.Drawing.Point(12, 248);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(100, 23);
            this.lblDept.TabIndex = 4;
            this.lblDept.Text = "Department:";

            this.btnAdd.Location = new System.Drawing.Point(130, 285);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Location = new System.Drawing.Point(250, 285);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Location = new System.Drawing.Point(372, 285);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 335);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.txtPositionTitle);
            this.Controls.Add(this.dgvPositions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPositions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Positions Configuration";
            this.Load += new System.EventHandler(this.frmPositions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.TextBox txtPositionTitle;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}