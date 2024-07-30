using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class Report_BLL
    {
        Report_DAL dalReport;

        public Report_BLL()
        {
            dalReport = new Report_DAL();
        }

        public DataSet getReport(tbl_Report report)
        {
            return dalReport.getReport(report);
        }
        public DataSet getReport2(tbl_Report report)
        {
            return dalReport.getReport2(report);
        }

    }
}
