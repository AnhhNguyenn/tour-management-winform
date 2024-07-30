using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class LLT_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public LLT_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllLLT()
        {
            string sql = "SELECT * FROM LOAILUATUOI";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }


        public bool InsertLoaiLuaTuoi(tbl_LoaiLT llt)
        {
            string sql = "INSERT INTO LOAILUATUOI(MALLT, TENLLT, GIATIENLLT) VALUES (@MALLT, @TENLLT, @GIATIENLLT)";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALLT", SqlDbType.VarChar).Value = llt.MaLLT;
                cmd.Parameters.Add("@TENLLT", SqlDbType.NVarChar).Value = llt.TenLLT;
                cmd.Parameters.Add("@GIATIENLLT", SqlDbType.Decimal).Value = llt.GiaTienLLT;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateLoaiLuaTuoi(tbl_LoaiLT llt)
        {
            string sql = "UPDATE LOAILUATUOI SET TENLLT = @TENLLT, GIATIENLLT = @GIATIENLLT WHERE MALLT = @MALLT";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALLT", SqlDbType.VarChar).Value = llt.MaLLT;
                cmd.Parameters.Add("@TENLLT", SqlDbType.NVarChar).Value = llt.TenLLT;
                cmd.Parameters.Add("@GIATIENLLT", SqlDbType.Decimal).Value = llt.GiaTienLLT;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteLoaiLuaTuoi(tbl_LoaiLT llt)
        {
            string sql = "DELETE LOAILUATUOI WHERE MALLT = @MALLT";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALLT", SqlDbType.VarChar).Value = llt.MaLLT;
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
