using System;
using System.Data;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmHoaDon : Form
    {
        NhanVien_BLL bllNhanVien;
        KhachHang_BLL bllKhachHang;
        HoaDon_BLL bllHoaDon;
        Report_BLL bllReport;

        public frmHoaDon()
        {
            InitializeComponent();
            bllNhanVien = new NhanVien_BLL();
            bllKhachHang = new KhachHang_BLL();
            bllHoaDon = new HoaDon_BLL();
            bllReport = new Report_BLL();
        }

        public void ShowAllHoaDon()
        {
            DataTable dtTable = bllHoaDon.getAllHoaDon();
            dgvHoaDon.DataSource = dtTable;
        }

        private void btnXemCTHD_Click(object sender, EventArgs e)
        {
            frmXemHD XemHD = new frmXemHD();
            XemHD.lblSoHD.Text = dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString();
            XemHD.lblTenNV.Text = dgvHoaDon.SelectedRows[0].Cells[1].Value.ToString();
            XemHD.lblTenKH.Text = dgvHoaDon.SelectedRows[0].Cells[2].Value.ToString();
            XemHD.lblNgayLapHD.Text = dgvHoaDon.SelectedRows[0].Cells[3].Value.ToString();
            XemHD.txtThanhTien.Text = string.Format("{0:#,##0}", decimal.Parse(dgvHoaDon.SelectedRows[0].Cells[4].Value.ToString()));
            XemHD.lblTenTour.Text = dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString();
            XemHD.lblGiaTour.Text = string.Format("{0:#,##0}", decimal.Parse(dgvHoaDon.SelectedRows[0].Cells[6].Value.ToString())) + "đ";
            XemHD.ShowDialog();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            ShowAllHoaDon();
            //checkBXemHDTrongThang.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ShowAllHoaDon();
            //checkBXemHDTrongThang.Checked = false;
        }
    }
}
