using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class KhachHang_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public KhachHang_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllKH()
        {
            string sql = "SELECT MAKH, TENKH, SDT, EMAIL, DIACHI FROM KHACHHANG";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertKhachHang(tbl_KhachHang khachhang)
        {
            string sql = "INSERT INTO KHACHHANG(MAKH, TENKH, SDT, EMAIL, DIACHI) VALUES(@MAKH, @TENKH, @SDT, @EMAIL, @DIACHI)";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = khachhang.MaKH;
                cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = khachhang.TenKH;
                cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = khachhang.SDT;
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = khachhang.Email;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = khachhang.DiaChi;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }


        public bool UpdateKhachHang(tbl_KhachHang khachhang)
        {
            string sql = "UPDATE KHACHHANG SET TENKH = @TENKH, SDT = @SDT, DIACHI = @DIACHI, EMAIL = @EMAIL WHERE MAKH = @MAKH";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = khachhang.MaKH;
                cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = khachhang.TenKH;
                cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = khachhang.SDT;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = khachhang.DiaChi;
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = khachhang.Email;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteKhachHang(tbl_KhachHang khachhang)
        {
            string sql = "DELETE KHACHHANG WHERE MAKH = @MAKH";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = khachhang.MaKH;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GeTSoKHDangCo()
        {
            string sql = "SELECT COUNT(MAKH) +1 FROM KHACHHANG";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            int KHDangCo = (int)cmd.ExecuteScalar();
            con.Close();

            return KHDangCo;
        }

        public string getMaKH_HuyTour(tbl_HoaDon hoaDon)
        {
            string sql = "SELECT MAKH FROM HOADON WHERE SOHD = @SOHD";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.Add("@SOHD", SqlDbType.VarChar).Value = hoaDon.SoHD;
            string MaKH = (string)cmd.ExecuteScalar();
            con.Close();

            return MaKH;
        }
    }
}
