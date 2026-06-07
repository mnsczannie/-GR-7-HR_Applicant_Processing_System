namespace HRApplicantSystem.Forms.Maintenance
{
    partial class frmEmploymentTypes
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
            this.dgvEmploymentTypes = new System.Windows.Forms.DataGridView();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmploymentTypes)).BeginInit();
            this.SuspendLayout();

            this.dgvEmploymentTypes.AllowUserToAddRows = false;
            this.dgvEmploymentTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmploymentTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmploymentTypes.Location = new System.Drawing.Point(12, 12);
            this.dgvEmploymentTypes.Name = "dgvEmploymentTypes";
            this.dgvEmploymentTypes.ReadOnly = true;
            this.dgvEmploymentTypes.RowHeadersWidth = 51;
            this.dgvEmploymentTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmploymentTypes.Size = new System.Drawing.Size(460, 180);
            this.dgvEmploymentTypes.TabIndex = 0;
            this.dgvEmploymentTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmploymentTypes_CellClick);

            this.txtTypeName.Location = new System.Drawing.Point(130, 215);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(342, 23);
            this.txtTypeName.TabIndex = 1;

            this.lblTypeName.Location = new System.Drawing.Point(12, 218);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(110, 23);
            this.lblTypeName.TabIndex = 2;
            this.lblTypeName.Text = "Employment Type:";

            this.btnAdd.Location = new System.Drawing.Point(130, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Location = new System.Drawing.Point(250, 260);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Location = new System.Drawing.Point(372, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
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
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.dgvEmploymentTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmploymentTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Employment Types";
            this.Load += new System.EventHandler(this.frmEmploymentTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmploymentTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.DataGridView dgvEmploymentTypes;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}