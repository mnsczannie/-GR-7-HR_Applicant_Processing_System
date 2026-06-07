namespace HRApplicantSystem.Forms.Applicant
{
    partial class frmJobVacancies
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
            this.dgvVacancies = new System.Windows.Forms.DataGridView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacancies)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVacancies
            // 
            this.dgvVacancies.AllowUserToAddRows = false;
            this.dgvVacancies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVacancies.Location = new System.Drawing.Point(12, 12);
            this.dgvVacancies.Name = "dgvVacancies";
            this.dgvVacancies.ReadOnly = true;
            this.dgvVacancies.RowHeadersWidth = 62;
            this.dgvVacancies.RowTemplate.Height = 28;
            this.dgvVacancies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVacancies.Size = new System.Drawing.Size(776, 382);
            this.dgvVacancies.TabIndex = 1;
            this.dgvVacancies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVacancies_CellClick);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(331, 400);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(120, 39);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // frmJobVacancies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.dgvVacancies);
            this.Name = "frmJobVacancies";
            this.Text = "frmJobVacancies";
            this.Load += new System.EventHandler(this.frmJobVacancies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacancies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvVacancies;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Button btnApply;
    }
}