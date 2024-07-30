using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class DiemDi_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public DiemDi_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllDDiTrongNc()
        {
            string sql = "SELECT * FROM dbo.DIEMDI WHERE MALTOUR = 'LT01'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable GetAllDDi(tbl_DiemDi ddi)
        {
            string sql = "SELECT * FROM dbo.DIEMDI WHERE MALTOUR = '" + ddi.MaLTour + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        //public DataTable GetAllDDiNgoaiNc()
        //{
        //    string sql = "SELECT * FROM dbo.DIEMDI WHERE MALTOUR = 'LT02'";
        //    SqlConnection con = dataCon.getConnect();
        //    sqlDA = new SqlDataAdapter(sql, con);
        //    con.Open();
        //    DataTable dataTable = new DataTable();
        //    sqlDA.Fill(dataTable);
        //    con.Close();
        //    return dataTable;
        //}

        public bool InsertDDi(tbl_DiemDi dd)
        {
            string sql = "INSERT INTO DIEMDI (MADDI, TENDDI, MALTOUR) VALUES (@MADDI, @TENDDI, @MALTOUR)";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MADDI", SqlDbType.VarChar).Value = dd.MaDDI;
                cmd.Parameters.Add("@TENDDI", SqlDbType.NVarChar).Value = dd.TenDDI;
                cmd.Parameters.Add("@MALTOUR", SqlDbType.VarChar).Value = dd.MaLTour;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateDDi(tbl_DiemDi dd)
        {
            string sql = "UPDATE DIEMDI SET TENDDI = @TENDDI, MALTOUR = @MALTOUR WHERE MADDI = @MADDI";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MADDI", SqlDbType.VarChar).Value = dd.MaDDI;
                cmd.Parameters.Add("@TENDDI", SqlDbType.NVarChar).Value = dd.TenDDI;
                cmd.Parameters.Add("@MALTOUR", SqlDbType.VarChar).Value = dd.MaLTour;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteDDi(tbl_DiemDi dd)
        {
            string sql = "DELETE DIEMDI WHERE MADDI = @MADDI";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MADDI", SqlDbType.VarChar).Value = dd.MaDDI;
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
