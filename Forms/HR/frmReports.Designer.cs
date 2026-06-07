namespace HRApplicantSystem.Forms.HR
{
    partial class frmReports
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
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.tabPending = new System.Windows.Forms.TabPage();
            this.dgvPending = new System.Windows.Forms.DataGridView();
            this.tabInterviews = new System.Windows.Forms.TabPage();
            this.dgvInterviews = new System.Windows.Forms.DataGridView();
            this.tabAccepted = new System.Windows.Forms.TabPage();
            this.dgvAccepted = new System.Windows.Forms.DataGridView();
            this.tabRejected = new System.Windows.Forms.TabPage();
            this.dgvRejected = new System.Windows.Forms.DataGridView();
            this.tabMissing = new System.Windows.Forms.TabPage();
            this.dgvMissing = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterviews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccepted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRejected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissing)).BeginInit();
            this.SuspendLayout();

            void ConfigGrid(System.Windows.Forms.DataGridView g)
            {
                g.AllowUserToAddRows = false;
                g.AllowUserToDeleteRows = false;
                g.ReadOnly = true;
                g.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                g.Dock = System.Windows.Forms.DockStyle.Fill;
                g.RowHeadersVisible = false;
                g.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            }

            ConfigGrid(this.dgvAll);
            ConfigGrid(this.dgvPending);
            ConfigGrid(this.dgvInterviews);
            ConfigGrid(this.dgvAccepted);
            ConfigGrid(this.dgvRejected);
            ConfigGrid(this.dgvMissing);

            this.tabAll.Controls.Add(this.dgvAll);
            this.tabAll.Text = "All Applicants";

            this.tabPending.Controls.Add(this.dgvPending);
            this.tabPending.Text = "Pending";

            this.tabInterviews.Controls.Add(this.dgvInterviews);
            this.tabInterviews.Text = "Interviews";

            this.tabAccepted.Controls.Add(this.dgvAccepted);
            this.tabAccepted.Text = "Accepted";

            this.tabRejected.Controls.Add(this.dgvRejected);
            this.tabRejected.Text = "Rejected";

            this.tabMissing.Controls.Add(this.dgvMissing);
            this.tabMissing.Text = "Missing Requirements";

            // tabReports
            this.tabReports.Controls.Add(this.tabAll);
            this.tabReports.Controls.Add(this.tabPending);
            this.tabReports.Controls.Add(this.tabInterviews);
            this.tabReports.Controls.Add(this.tabAccepted);
            this.tabReports.Controls.Add(this.tabRejected);
            this.tabReports.Controls.Add(this.tabMissing);
            this.tabReports.Location = new System.Drawing.Point(12, 12);
            this.tabReports.Size = new System.Drawing.Size(760, 380);
            this.tabReports.SelectedIndexChanged += new System.EventHandler(this.tabReports_SelectedIndexChanged);

            // btnExport
            this.btnExport.Location = new System.Drawing.Point(12, 405);
            this.btnExport.Size = new System.Drawing.Size(120, 30);
            this.btnExport.Text = "Export to CSV";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // btnPrint
            this.btnPrint.Location = new System.Drawing.Point(140, 405);
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.Text = "🖨 Print";
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // frmReports
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.tabReports);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.tabReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterviews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccepted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRejected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissing)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.TabPage tabPending;
        private System.Windows.Forms.DataGridView dgvPending;
        private System.Windows.Forms.TabPage tabInterviews;
        private System.Windows.Forms.DataGridView dgvInterviews;
        private System.Windows.Forms.TabPage tabAccepted;
        private System.Windows.Forms.DataGridView dgvAccepted;
        private System.Windows.Forms.TabPage tabRejected;
        private System.Windows.Forms.DataGridView dgvRejected;
        private System.Windows.Forms.TabPage tabMissing;
        private System.Windows.Forms.DataGridView dgvMissing;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
    }
}
