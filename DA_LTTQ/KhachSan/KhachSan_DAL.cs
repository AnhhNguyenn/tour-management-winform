using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class KhachSan_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public KhachSan_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllKhachSan()
        {
            string sql = "SELECT * FROM KHACHSAN";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertKhachSan(tbl_KhachSan ks)
        {
            string sql = "INSERT INTO KHACHSAN(MAKS, TENKS, GIAKS, DIACHI, MALKS) VALUES (@MAKS, @TENKS, @GIAKS, @DIACHI, @MALKS)";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAKS", SqlDbType.VarChar).Value = ks.MAKS;
                cmd.Parameters.Add("@TENKS", SqlDbType.NVarChar).Value = ks.TENKS;
                cmd.Parameters.Add("@GIAKS", SqlDbType.Decimal).Value = ks.GIAKS;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = ks.DIACHI;
                cmd.Parameters.Add("@MALKS", SqlDbType.VarChar).Value = ks.MALKS;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateKhachSan(tbl_KhachSan ks)
        {
            string sql = "UPDATE KHACHSAN SET TENKS = @TENKS, GIAKS = @GIAKS, DIACHI = @DIACHI, MALKS = @MALKS WHERE MAKS = @MAKS";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAKS", SqlDbType.VarChar).Value = ks.MAKS;
                cmd.Parameters.Add("@TENKS", SqlDbType.NVarChar).Value = ks.TENKS;
                cmd.Parameters.Add("@GIAKS", SqlDbType.Decimal).Value = ks.GIAKS;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = ks.DIACHI;
                cmd.Parameters.Add("@MALKS", SqlDbType.VarChar).Value = ks.MALKS;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteKhachSan(tbl_KhachSan ks)
        {
            string sql = "DELETE KHACHSAN WHERE MAKS = @MAKS";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAKS", SqlDbType.VarChar).Value = ks.MAKS;
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
