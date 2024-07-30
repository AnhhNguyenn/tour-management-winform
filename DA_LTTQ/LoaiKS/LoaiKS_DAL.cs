using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class LoaiKS_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public LoaiKS_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllLoaiKhachSan()
        {
            string sql = "SELECT * FROM LOAIKS";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertLoaiKhachSan(tbl_LoaiKS lks)
        {
            string sql = "INSERT INTO LOAIKS(MALKS, TENLKS) VALUES (@MALKS, @TENLKS)";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALKS", SqlDbType.VarChar).Value = lks.MALKS;
                cmd.Parameters.Add("@TENLKS", SqlDbType.NVarChar).Value = lks.TENLKS;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateLoaiKhachSan(tbl_LoaiKS lks)
        {
            string sql = "UPDATE LOAIKS SET TENLKS = @TENLKS WHERE MALKS = @MALKS";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALKS", SqlDbType.VarChar).Value = lks.MALKS;
                cmd.Parameters.Add("@TENLKS", SqlDbType.NVarChar).Value = lks.TENLKS;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteLoaiKhachSan(tbl_LoaiKS lks)
        {
            string sql = "DELETE LOAIKS WHERE MALKS = @MALKS";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALKS", SqlDbType.VarChar).Value = lks.MALKS;
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
