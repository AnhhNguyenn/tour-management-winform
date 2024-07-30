using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class PhuongTien_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public PhuongTien_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllPhuongTien()
        {
            string sql = "SELECT * FROM PHUONGTIEN";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertPhuongTien(tbl_PhuongTien pt)
        {
            string sql = "INSERT INTO PHUONGTIEN(MAPT, TENPT) VALUES (@MAPT, @TENPT)";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAPT", SqlDbType.VarChar).Value = pt.MaPT;
                cmd.Parameters.Add("@TENPT", SqlDbType.NVarChar).Value = pt.TenPT;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdatePhuongTien(tbl_PhuongTien pt)
        {
            string sql = "UPDATE PHUONGTIEN SET TENPT = @TENPT WHERE MAPT = @MAPT";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAPT", SqlDbType.VarChar).Value = pt.MaPT;
                cmd.Parameters.Add("@TENPT", SqlDbType.NVarChar).Value = pt.TenPT;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeletePhuongTien(tbl_PhuongTien pt)
        {
            string sql = "DELETE PHUONGTIEN WHERE MAPT = @MAPT";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAPT", SqlDbType.VarChar).Value = pt.MaPT;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
