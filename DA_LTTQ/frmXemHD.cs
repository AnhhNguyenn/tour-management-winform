using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmXemHD : Form
    {
        TTTV_BLL blltttv;
        KhachHang_BLL bllKhachHang;
        HoaDon_BLL bllHoaDon;
        public frmXemHD()
        {
            InitializeComponent();
            blltttv = new TTTV_BLL();
            bllKhachHang = new KhachHang_BLL();
            bllHoaDon = new HoaDon_BLL();
        }


        public void ShowTTTV()
        {
            tbl_HoaDon HD = new tbl_HoaDon();
            HD.SoHD = lblSoHD.Text;
            DataTable dtTable = blltttv.GetTTTV2(HD);
            dgvThanhVien.DataSource = dtTable;
        }


        public string getMaKH()
        {          
            tbl_HoaDon HD = new tbl_HoaDon();
            HD.SoHD = lblSoHD.Text;
            return bllKhachHang.getMaKH_HuyTour(HD);
        }

        private void frmXemHD_Load(object sender, EventArgs e)
        {
            ShowTTTV();
        }

        private void btnXemCTHD_Click(object sender, EventArgs e)
        {

        }

        private void btnHuyTour_Click(object sender, EventArgs e)
        {
            tbl_KhachHang KhachHang = new tbl_KhachHang();
            //KhachHang.MaKH = getMaKH();
            //bllKhachHang.DeleteKhachHang(KhachHang);
            tbl_HoaDon HD = new tbl_HoaDon();
            HD.SoHD = lblSoHD.Text;
            if (bllHoaDon.DeleteHoaDon(HD))
            {
             
                this.Close();;
                bllKhachHang.getMaKH_HuyTour(HD);
                bllKhachHang.DeleteKhachHang(KhachHang);
                MessageBox.Show("Hủy Tour thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.ShowAllHoaDon();
        }
    }
}
