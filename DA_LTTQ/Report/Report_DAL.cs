using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class Report_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;

        public Report_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataSet getReport(tbl_Report report)
        {
            string sql = "SELECT * FROM VI_ShowHD WHERE SOHD = '" + report.SoHD + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataSet dataset = new DataSet();
            sqlDA.Fill(dataset, "DataTable_Bill");
            con.Close();
            return dataset;
        }

        public DataSet getReport2(tbl_Report report)
        {
            string sql = "SELECT * FROM VI_GetSLLLT where MAKH = '" + report.MaKH + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataSet dataset = new DataSet();
            sqlDA.Fill(dataset, "DataTable_Bill");
            con.Close();
            return dataset;
        }
    }
}
