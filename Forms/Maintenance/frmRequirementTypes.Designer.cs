namespace HRApplicantSystem.Forms.Maintenance
{
    partial class frmRequirementTypes
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
            this.dgvRequirementTypes = new System.Windows.Forms.DataGridView();
            this.txtRequirementName = new System.Windows.Forms.TextBox();
            this.lblReqName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequirementTypes)).BeginInit();
            this.SuspendLayout();

            this.dgvRequirementTypes.AllowUserToAddRows = false;
            this.dgvRequirementTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequirementTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequirementTypes.Location = new System.Drawing.Point(12, 12);
            this.dgvRequirementTypes.Name = "dgvRequirementTypes";
            this.dgvRequirementTypes.ReadOnly = true;
            this.dgvRequirementTypes.RowHeadersWidth = 51;
            this.dgvRequirementTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequirementTypes.Size = new System.Drawing.Size(460, 180);
            this.dgvRequirementTypes.TabIndex = 0;
            this.dgvRequirementTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequirementTypes_CellClick);

            this.txtRequirementName.Location = new System.Drawing.Point(140, 215);
            this.txtRequirementName.Name = "txtRequirementName";
            this.txtRequirementName.Size = new System.Drawing.Size(332, 23);
            this.txtRequirementName.TabIndex = 1;

            this.lblReqName.Location = new System.Drawing.Point(12, 218);
            this.lblReqName.Name = "lblReqName";
            this.lblReqName.Size = new System.Drawing.Size(120, 23);
            this.lblReqName.TabIndex = 2;
            this.lblReqName.Text = "Requirement Field:";

            this.btnAdd.Location = new System.Drawing.Point(140, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
 
            this.btnEdit.Location = new System.Drawing.Point(250, 260);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Location = new System.Drawing.Point(367, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 308);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblReqName);
            this.Controls.Add(this.txtRequirementName);
            this.Controls.Add(this.dgvRequirementTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRequirementTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Onboarding Requirement Categories";
            this.Load += new System.EventHandler(this.frmRequirementTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequirementTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.DataGridView dgvRequirementTypes;
        private System.Windows.Forms.TextBox txtRequirementName;
        private System.Windows.Forms.Label lblReqName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}