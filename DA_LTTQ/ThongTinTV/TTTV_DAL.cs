using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class TTTV_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public TTTV_DAL()
        {
            dataCon = new DataConnection();
        }

        public bool InsertTTTV(tbl_TTTV tttv)
        {
            string sql = "INSERT INTO THONGTINTV(MAKH, MALLT, TENTV, GIOITINH, NGAYSINH) VALUES(@MAKH, @MALLT, @TENTV, @GIOITINH, @NGAYSINH)";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                //cmd.Parameters.Add("@MATV", SqlDbType.VarChar).Value = tttv.MaTV;
                cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = tttv.MaKH;
                cmd.Parameters.Add("@MALLT", SqlDbType.VarChar).Value = tttv.MaLLT;
                cmd.Parameters.Add("@TENTV", SqlDbType.NVarChar).Value = tttv.TenTV;
                cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = tttv.GioiTinh;
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = tttv.NgaySinh.ToString("yyyy-MM-dd");
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateTTTV(tbl_TTTV tttv)
        {
            string sql = "UPDATE THONGTINTV SET MALLT = @MALLT, TENTV = @TENTV, GIOITINH = @GIOITINH, NGAYSINH = @NGAYSINH WHERE MATV = @MATV";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MATV", SqlDbType.VarChar).Value = tttv.MaTV;
                //cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = tttv.MaKH;
                cmd.Parameters.Add("@MALLT", SqlDbType.VarChar).Value = tttv.MaLLT;
                cmd.Parameters.Add("@TENTV", SqlDbType.NVarChar).Value = tttv.TenTV;
                cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = tttv.GioiTinh;
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = tttv.NgaySinh.ToString("yyyy-MM-dd");
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteTTTV(tbl_TTTV tttv)
        {
            string sql = "DELETE FROM THONGTINTV WHERE MATV = @MATV";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MATV", SqlDbType.VarChar).Value = tttv.MaTV;
                cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = tttv.MaKH;
                //cmd.Parameters.Add("@MALLT", SqlDbType.VarChar).Value = tttv.MaLLT;
                //cmd.Parameters.Add("@TENTV", SqlDbType.NVarChar).Value = tttv.TenTV;
                //cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = tttv.GioiTinh;
                //cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = tttv.NgaySinh.ToString("yyyy-MM-dd");
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GeTSoTVDangCo()
        {
            string sql = "SELECT COUNT(MATV) +1 FROM THONGTINTV";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            int TVDangCo = (int)cmd.ExecuteScalar();
            con.Close();

            return TVDangCo;
        }

        public DataTable GetTTTV(tbl_TTTV tttv)
        {
            string sql = "SELECT MATV, TENTV, GIOITINH, NGAYSINH, TENLLT FROM THONGTINTV, LOAILUATUOI WHERE LOAILUATUOI.MALLT = THONGTINTV.MALLT AND MAKH = '"+ tttv.MaKH +"'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable GetTTTV2(tbl_HoaDon hoadon)
        {
            string sql = "SELECT MATV, TENTV, GIOITINH, NGAYSINH, TENLLT FROM THONGTINTV, LOAILUATUOI, HOADON, KHACHHANG WHERE LOAILUATUOI.MALLT = THONGTINTV.MALLT AND SOHD = '"+ hoadon.SoHD +"' AND HOADON.MAKH = KHACHHANG.MAKH AND THONGTINTV.MAKH = KHACHHANG.MAKH";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }
    }
}
