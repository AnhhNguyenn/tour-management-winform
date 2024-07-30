using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmThongTinTour : Form
    {
        public frmThongTinTour()
        {
            InitializeComponent();
        }

        public string NgayKetThuc;
        private void LoadData()
        {
            frmThongTinKhachHang TTKHfrm = new frmThongTinKhachHang();
            TTKHfrm.picAnh1.Image = picHinh1.Image;
            TTKHfrm.lblTenTour.Text = lblTenTour.Text;
            TTKHfrm.lblTGKH.Text = lblTGKH.Text;
            TTKHfrm.lblSoNgay.Text = lblSoNgay.Text;
            TTKHfrm.lblNoiKH.Text = lblNoiKH.Text;
            TTKHfrm.lblSlot.Text = lblSlot.Text;
            TTKHfrm.picAnh1N.Image = picHinh1.Image;
            TTKHfrm.lblDateBatDauChuyenDi.Text = lblTGKH.Text;
            TTKHfrm.lblDateKetThucChuyenDi.Text = NgayKetThuc;
            TTKHfrm.lblMaTour.Text = lblMaTour.Text;
            TTKHfrm.Show();
        }

        private void btlDatTour_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
