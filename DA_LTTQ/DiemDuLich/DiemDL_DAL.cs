using System;
using System.Data;
using System.Data.SqlClient;

namespace DA_LTTQ
{
    class DiemDL_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public DiemDL_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllDDLTrongNc()
        {
            string sql = "SELECT * FROM dbo.DIEMDULICH WHERE MALTOUR = 'LT01'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable GetAllDDLNgoaiNc()
        {
            string sql = "SELECT * FROM dbo.DIEMDULICH WHERE MALTOUR = 'LT02'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable GetAllDDL(tbl_DiemDL ddl)
        {
            string sql = "SELECT * FROM dbo.DIEMDULICH WHERE MALTOUR = '" + ddl.MaLTour + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertDDL(tbl_DiemDL ddl)
        {
            string sql = "INSERT INTO DIEMDULICH(MADDEN, TENDDEN, MALTOUR) VALUES (@MADDEN, @TENDDEN, @MALTOUR)";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MADDEN", SqlDbType.VarChar).Value = ddl.MaDDen;
                cmd.Parameters.Add("@TENDDEN", SqlDbType.NVarChar).Value = ddl.TenDDen;
                cmd.Parameters.Add("@MALTOUR", SqlDbType.VarChar).Value = ddl.MaLTour;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateDDL(tbl_DiemDL ddl)
        {
            string sql = "UPDATE DIEMDULICH SET TENDDEN = @TENDDEN, MALTOUR = @MALTOUR WHERE MADDEN = @MADDEN";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MADDEN", SqlDbType.VarChar).Value = ddl.MaDDen;
                cmd.Parameters.Add("@TENDDEN", SqlDbType.NVarChar).Value = ddl.TenDDen;
                cmd.Parameters.Add("@MALTOUR", SqlDbType.NVarChar).Value = ddl.MaLTour;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteDDL(tbl_DiemDL ddl)
        {
            string sql = "DELETE DIEMDULICH WHERE MADDEN = @MADDEN";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MADDEN", SqlDbType.VarChar).Value = ddl.MaDDen;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GetSLDDL()
        {
            string sql = "SELECT COUNT(MADDEN) +1 FROM DIEMDULICH";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            int IDDDL = (int)cmd.ExecuteScalar();
            con.Close();

            return IDDDL;
        }
    }
}
