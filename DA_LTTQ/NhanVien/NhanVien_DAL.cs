using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{

    class NhanVien_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public NhanVien_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllNhanVien()
        {
            string sql = "SELECT * FROM NHANVIEN";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertNhanVien(tbl_NhanVien nv)
        {
            string sql = "INSERT INTO NHANVIEN(MANV, TENNV, NGSINH, SDT, CMND_CCCD, NGVL) VALUES (@MANV, @TENNV, @NGSINH, @SDT, @CMND_CCCD, @NGVL)";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = nv.MANV;
                cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = nv.TENNV;
                cmd.Parameters.Add("@NGSINH", SqlDbType.DateTime).Value = nv.NGSINH.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@SDT", SqlDbType.Decimal).Value = nv.SDT;
                cmd.Parameters.Add("@CMND_CCCD", SqlDbType.Decimal).Value = nv.CMND_CCCD;
                cmd.Parameters.Add("@NGVL", SqlDbType.DateTime).Value = nv.NGVL.ToString("yyyy-MM-dd");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateNhanVien(tbl_NhanVien nv)
        {
            string sql = "UPDATE NHANVIEN SET TENNV = @TENNV, NGSINH = @NGSINH, SDT = @SDT, CMND_CCCD = @CMND_CCCD, NGVL = @NGVL  WHERE MANV = @MANV";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = nv.MANV;
                cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = nv.TENNV;
                cmd.Parameters.Add("@NGSINH", SqlDbType.Date).Value = nv.NGSINH;
                cmd.Parameters.Add("@SDT", SqlDbType.Decimal).Value = nv.SDT;
                cmd.Parameters.Add("@CMND_CCCD", SqlDbType.Decimal).Value = nv.CMND_CCCD;
                cmd.Parameters.Add("@NGVL", SqlDbType.Date).Value = nv.NGVL;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteNhanVien(tbl_NhanVien nv)
        {
            string sql = "DELETE NHANVIEN WHERE MANV = @MANV";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = nv.MANV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GetSLNV()
        {
            string sql = "SELECT COUNT(MANV) +1 FROM NHANVIEN";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            int IDNV = (int)cmd.ExecuteScalar();
            con.Close();

            return IDNV;
        }
    }
}

