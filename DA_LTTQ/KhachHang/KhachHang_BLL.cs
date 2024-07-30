using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class KhachHang_BLL
    {
        KhachHang_DAL dalKhachHang;
        public KhachHang_BLL()
        {
            dalKhachHang = new KhachHang_DAL();
        }

        public DataTable GetAllKH()
        {
            return dalKhachHang.GetAllKH();
        }

        public bool InsertKhachHang(tbl_KhachHang khachhang)
        {
            return dalKhachHang.InsertKhachHang(khachhang);
        }

        public bool UpdateKhachHang(tbl_KhachHang khachhang)
        {
            return dalKhachHang.UpdateKhachHang(khachhang);
        }

        public bool DeleteKhachHang(tbl_KhachHang khachhang)
        {
            return dalKhachHang.DeleteKhachHang(khachhang);
        }

        public int GeTSoKHDangCo()
        {
            return dalKhachHang.GeTSoKHDangCo();
        }
        public string getMaKH_HuyTour(tbl_HoaDon hoaDon)
        {
            return dalKhachHang.getMaKH_HuyTour(hoaDon);
        }

    }
}
