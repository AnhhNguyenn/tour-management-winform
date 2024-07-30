using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace DA_LTTQ
{
    public partial class frmReportHD : Form
    {
        public tbl_Report Report;

        public frmReportHD()
        {
            InitializeComponent();
        }

        private void frmReportHD_Load(object sender, EventArgs e)
        {

            this.reportHD.RefreshReport();
        }
    }
}
