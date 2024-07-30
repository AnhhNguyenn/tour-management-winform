
namespace DA_LTTQ
{
    partial class frmReportHD
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
            this.reportHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportHD
            // 
            this.reportHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportHD.LocalReport.ReportEmbeddedResource = "DA_LTTQ.Report1.rdlc";
            this.reportHD.Location = new System.Drawing.Point(0, 0);
            this.reportHD.Name = "reportHD";
            this.reportHD.ServerReport.BearerToken = null;
            this.reportHD.Size = new System.Drawing.Size(650, 569);
            this.reportHD.TabIndex = 0;
            // 
            // frmReportHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 569);
            this.Controls.Add(this.reportHD);
            this.Name = "frmReportHD";
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.frmReportHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportHD;
    }
}