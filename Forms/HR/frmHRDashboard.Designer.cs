namespace HRApplicantSystem.Forms.HR
{
    partial class frmHRDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPendingCaption = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblIntCaption = new System.Windows.Forms.Label();
            this.lblInterviews = new System.Windows.Forms.Label();
            this.lblAccCaption = new System.Windows.Forms.Label();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.lblRejCaption = new System.Windows.Forms.Label();
            this.lblRejected = new System.Windows.Forms.Label();
            this.btnApplicantReview = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnVacancyManagement = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlCards.SuspendLayout();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(15, 18);
            this.lblWelcome.Text = "Welcome";

            // pnlCards
            this.pnlCards.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCards.Location = new System.Drawing.Point(15, 55);
            this.pnlCards.Size = new System.Drawing.Size(570, 100);
            this.pnlCards.Controls.Add(this.lblTotalCaption);
            this.pnlCards.Controls.Add(this.lblTotal);
            this.pnlCards.Controls.Add(this.lblPendingCaption);
            this.pnlCards.Controls.Add(this.lblPending);
            this.pnlCards.Controls.Add(this.lblIntCaption);
            this.pnlCards.Controls.Add(this.lblInterviews);
            this.pnlCards.Controls.Add(this.lblAccCaption);
            this.pnlCards.Controls.Add(this.lblAccepted);
            this.pnlCards.Controls.Add(this.lblRejCaption);
            this.pnlCards.Controls.Add(this.lblRejected);

            // Total
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalCaption.Location = new System.Drawing.Point(10, 12);
            this.lblTotalCaption.Text = "Total";
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotal.Location = new System.Drawing.Point(10, 30);
            this.lblTotal.Text = "0";

            // Pending
            this.lblPendingCaption.AutoSize = true;
            this.lblPendingCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPendingCaption.Location = new System.Drawing.Point(110, 12);
            this.lblPendingCaption.Text = "Pending";
            this.lblPending.AutoSize = true;
            this.lblPending.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPending.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblPending.Location = new System.Drawing.Point(110, 30);
            this.lblPending.Text = "0";

            // Interviews
            this.lblIntCaption.AutoSize = true;
            this.lblIntCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblIntCaption.Location = new System.Drawing.Point(210, 12);
            this.lblIntCaption.Text = "Interviews";
            this.lblInterviews.AutoSize = true;
            this.lblInterviews.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblInterviews.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblInterviews.Location = new System.Drawing.Point(210, 30);
            this.lblInterviews.Text = "0";

            // Accepted
            this.lblAccCaption.AutoSize = true;
            this.lblAccCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAccCaption.Location = new System.Drawing.Point(340, 12);
            this.lblAccCaption.Text = "Accepted";
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAccepted.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblAccepted.Location = new System.Drawing.Point(340, 30);
            this.lblAccepted.Text = "0";

            // Rejected
            this.lblRejCaption.AutoSize = true;
            this.lblRejCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRejCaption.Location = new System.Drawing.Point(460, 12);
            this.lblRejCaption.Text = "Rejected";
            this.lblRejected.AutoSize = true;
            this.lblRejected.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblRejected.ForeColor = System.Drawing.Color.Crimson;
            this.lblRejected.Location = new System.Drawing.Point(460, 30);
            this.lblRejected.Text = "0";

            // btnApplicantReview
            this.btnApplicantReview.Location = new System.Drawing.Point(15, 175);
            this.btnApplicantReview.Size = new System.Drawing.Size(120, 40);
            this.btnApplicantReview.Text = "Applicant Review";
            this.btnApplicantReview.Click += new System.EventHandler(this.btnApplicantReview_Click);

            // btnReports
            this.btnReports.Location = new System.Drawing.Point(145, 175);
            this.btnReports.Size = new System.Drawing.Size(90, 40);
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // btnVacancyManagement
            this.btnVacancyManagement.Location = new System.Drawing.Point(245, 175);
            this.btnVacancyManagement.Size = new System.Drawing.Size(130, 40);
            this.btnVacancyManagement.Text = "Vacancy Management";
            this.btnVacancyManagement.Click += new System.EventHandler(this.btnVacancyManagement_Click);

            // btnMaintenance
            this.btnMaintenance.Location = new System.Drawing.Point(385, 175);
            this.btnMaintenance.Size = new System.Drawing.Size(90, 40);
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.Visible = false;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(485, 175);
            this.btnRefresh.Size = new System.Drawing.Size(90, 40);
            this.btnRefresh.Text = "↺ Refresh";
            this.btnRefresh.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(15, 225);
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.Salmon;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // frmHRDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 275);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.btnApplicantReview);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnVacancyManagement);
            this.Controls.Add(this.btnMaintenance);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHRDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Dashboard";
            this.Load += new System.EventHandler(this.frmHRDashboard_Load);
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPendingCaption;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblIntCaption;
        private System.Windows.Forms.Label lblInterviews;
        private System.Windows.Forms.Label lblAccCaption;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.Label lblRejCaption;
        private System.Windows.Forms.Label lblRejected;
        private System.Windows.Forms.Button btnApplicantReview;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnVacancyManagement;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
    }
}
