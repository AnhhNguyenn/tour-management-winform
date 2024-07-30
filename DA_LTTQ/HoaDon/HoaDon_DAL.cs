using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class HoaDon_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public HoaDon_DAL()
        {
            dataCon = new DataConnection();
        }

        public int GetSoHD()
        {
            string sql = "SELECT COUNT(SoHD) +1 FROM HOADON";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            int SOHD = (int)cmd.ExecuteScalar();
            con.Close();

            return SOHD;
        }

        public DataTable getAllHoaDon()
        {
            string sql = "SELECT SOHD, TENNV, TENKH, NGAYLAPHOADON, THANHTIENHOADON, TOUR.TENTOUR, GIATOUR FROM HOADON, NHANVIEN, KHACHHANG, TOUR WHERE HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV AND TOUR.MATOUR = HOADON.MATOUR";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertHoaDon(tbl_HoaDon hoadon)
        {
            string sql = "INSERT INTO HOADON(SOHD, MATOUR, MANV, MAKH, NGAYLAPHOADON, THANHTIENHOADON) VALUES(@SOHD, @MATOUR, @MANV, @MAKH, @NGAYLAPHOADON, @THANHTIENHOADON)";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@SOHD", SqlDbType.VarChar).Value = hoadon.SoHD;
                cmd.Parameters.Add("@MATOUR", SqlDbType.VarChar).Value = hoadon.MaTour;
                cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = hoadon.MaNV;
                cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = hoadon.MaKH;
                cmd.Parameters.Add("@NGAYLAPHOADON", SqlDbType.DateTime).Value = hoadon.NgayLapHoaDon.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@THANHTIENHOADON", SqlDbType.Decimal).Value = hoadon.ThanhTienHoaDon;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public DataTable ThongKe_DoanhThu_Nam(tbl_HoaDon hoadon)
        {
            string sql = "select month(ngaylaphoadon) as N'Tháng', sum(thanhtienhoadon) as N'Thành tiền' from hoadon where year(ngaylaphoadon) =  "+ hoadon.Nam +" group by ngaylaphoadon ";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool DeleteHoaDon(tbl_HoaDon hoadon)
        {
            string sql = "UPDATE TOUR SET SOLUONGCONLAI = TOUR.SOLUONGCONLAI + (SELECT COUNT(THONGTINTV.MATV) FROM THONGTINTV, LOAILUATUOI, HOADON, KHACHHANG WHERE LOAILUATUOI.MALLT = THONGTINTV.MALLT AND SOHD = @SOHD  AND HOADON.MAKH = KHACHHANG.MAKH AND THONGTINTV.MAKH = KHACHHANG.MAKH) WHERE TOUR.MATOUR = (SELECT MATOUR FROM HOADON WHERE SOHD = @SOHD )" +
                "DELETE FROM THONGTINTV WHERE MAKH = (SELECT MAKH FROM HOADON WHERE SOHD = @SOHD )" +
                "DELETE FROM HOADON WHERE SOHD = @SOHD";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@SOHD", SqlDbType.VarChar).Value = hoadon.SoHD;
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
