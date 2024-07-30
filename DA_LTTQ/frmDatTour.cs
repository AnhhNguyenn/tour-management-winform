using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmDatTour : Form
    {
        DiemDi_BLL bllDiemDi;
        DiemDL_BLL bllDiemDL;
        PhuongTien_BLL bllPhuongTien;
        Tour_BLL bllTour;

        public frmDatTour()
        {
            InitializeComponent();
            bllDiemDi = new DiemDi_BLL();
            bllDiemDL = new DiemDL_BLL();
            bllPhuongTien = new PhuongTien_BLL();
            bllTour = new Tour_BLL();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void frmTour_Load(object sender, EventArgs e)
        {
            LoadData();
            ShowAllTour();
            KQSoTour();
        }
        #region Change Color            
        private void btnTrongNuoc_Click(object sender, EventArgs e)
        {
            KQSoTour();
            btnTrongNuoc.FillColor = ColorTranslator.FromHtml("#0C356A");
            btnTrongNuoc.FillColor2 = ColorTranslator.FromHtml("#0C356A");
            btnTrongNuoc.ForeColor = Color.White;

            btnNgoaiNuoc.FillColor = Color.White;
            btnNgoaiNuoc.FillColor2 = Color.White;
            btnNgoaiNuoc.ForeColor = ColorTranslator.FromHtml("#0C356A");

            cmbDiemDi.ValueMember = "MaDDi";
            cmbDiemDi.DisplayMember = "TenDDi";
            cmbDiemDi.DataSource = bllDiemDi.GetAllDDiTrongNc();

            cmbDiemDen.ValueMember = "MaDDen";
            cmbDiemDen.DisplayMember = "TenDDen";
            cmbDiemDen.DataSource = bllDiemDL.GetAllDDLTrongNc();

            tbl_Tour Tour = new tbl_Tour();
            Tour.MaLTour = CheckMaLTour();
            DataTable dataTable = bllTour.GetLocTour(Tour);
            dgvTour.DataSource = dataTable;
        }

        private void btnNgoaiNuoc_Click(object sender, EventArgs e)
        {
            KQSoTour();
            btnNgoaiNuoc.FillColor = ColorTranslator.FromHtml("#0C356A");
            btnNgoaiNuoc.FillColor2 = ColorTranslator.FromHtml("#0C356A");
            btnNgoaiNuoc.ForeColor = Color.White;

            btnTrongNuoc.FillColor = Color.White;
            btnTrongNuoc.FillColor2 = Color.White;
            btnTrongNuoc.ForeColor = ColorTranslator.FromHtml("#0C356A");

            cmbDiemDi.ValueMember = "MaDDi";
            cmbDiemDi.DisplayMember = "TenDDi";
            cmbDiemDi.DataSource = bllDiemDi.GetAllDDiTrongNc();

            cmbDiemDen.ValueMember = "MaDDen";
            cmbDiemDen.DisplayMember = "TenDDen";
            cmbDiemDen.DataSource = bllDiemDL.GetAllDDLNgoaiNc();

            tbl_Tour Tour = new tbl_Tour();
            Tour.MaLTour = CheckMaLTour();
            DataTable dataTable = bllTour.GetLocTour(Tour);
            dgvTour.DataSource = dataTable;
        }


        #endregion

        private void LoadData()
        {
            btnTrongNuoc.FillColor = ColorTranslator.FromHtml("#0C356A");
            btnTrongNuoc.FillColor2 = ColorTranslator.FromHtml("#0C356A");
            btnTrongNuoc.ForeColor = Color.White;

            btnNgoaiNuoc.FillColor = Color.White;
            btnNgoaiNuoc.FillColor2 = Color.White;
            btnNgoaiNuoc.ForeColor = ColorTranslator.FromHtml("#0C356A");

            cmbDiemDi.ValueMember = "MaDDi";
            cmbDiemDi.DisplayMember = "TenDDi";
            cmbDiemDi.DataSource = bllDiemDi.GetAllDDiTrongNc();

            cmbDiemDen.ValueMember = "MaDDen";
            cmbDiemDen.DisplayMember = "TenDDen";
            cmbDiemDen.DataSource = bllDiemDL.GetAllDDLTrongNc();

            cmbPhuongTien.ValueMember = "MaPT";
            cmbPhuongTien.DisplayMember = "TenPT";
            cmbPhuongTien.DataSource = bllPhuongTien.GetAllPhuongTien();

            cmbSoNgay.SelectedIndex = 0;
            dtpNgayDi.Value = DateTime.Today;

            dgvTour.Columns[5].DefaultCellStyle.Format = "N0";
        }

        public void ShowAllTour()
        {
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaLTour = CheckMaLTour();
            DataTable dataTable = bllTour.GetLocTour(Tour);
            dgvTour.DataSource = dataTable;
        }

        private string CheckMaLTour()
        {
            string MaLTour = "";
            if (btnTrongNuoc.ForeColor == Color.White)
            {
                MaLTour = "LT01";
            }

            if (btnNgoaiNuoc.ForeColor == Color.White)
            {
                MaLTour = "LT02";
            }
            return MaLTour;
        }

        int SoNgay1, SoNgay2;
        private void CheckSoNgay()
        {
            if (cmbSoNgay.SelectedIndex == 1)
            {
                SoNgay1 = 1;
                SoNgay2 = 3;
            }
            if (cmbSoNgay.SelectedIndex == 2)
            {
                SoNgay1 = 4;
                SoNgay2 = 7;
            }
            if (cmbSoNgay.SelectedIndex == 3)
            {
                SoNgay1 = 8;
                SoNgay2 = 14;
            }
            if (cmbSoNgay.SelectedIndex == 4)
            {
                SoNgay1 = 8;
                SoNgay2 = 14;
            }
        }

        private void dgvTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmThongTinTour TTTourfrm = new frmThongTinTour();
            DataTable dttable = new DataTable();
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaTour = dgvTour.SelectedRows[0].Cells[0].Value.ToString();
            dttable = bllTour.GetTTTour(Tour);
            TTTourfrm.lblTenTour.Text = "[" + dttable.Rows[0]["MATOUR"].ToString() + "] " + dttable.Rows[0]["TENTOUR"].ToString();
            TTTourfrm.lblMoTa.Text = dttable.Rows[0]["MOTA"].ToString();
            TTTourfrm.lblGiaTour.Text = string.Format("{0:#,##0}", decimal.Parse(dttable.Rows[0]["GIATOUR"].ToString())) + "/Khách";

            MemoryStream ms1 = new MemoryStream((byte[])(dttable.Rows[0]["ANH1"]));
            TTTourfrm.picHinh1.Image = Image.FromStream(ms1);

            MemoryStream ms2 = new MemoryStream((byte[])(dttable.Rows[0]["ANH2"]));
            TTTourfrm.picHinh2.Image = Image.FromStream(ms2);

            MemoryStream ms3 = new MemoryStream((byte[])(dttable.Rows[0]["ANH3"]));
            TTTourfrm.picHinh3.Image = Image.FromStream(ms3);

            MemoryStream ms4 = new MemoryStream((byte[])(dttable.Rows[0]["ANH4"]));
            TTTourfrm.picHinh4.Image = Image.FromStream(ms4);

            TTTourfrm.lblTGKH.Text = dttable.Rows[0]["NGAYDITOUR"].ToString();
            TTTourfrm.NgayKetThuc = dttable.Rows[0]["NGAYKETTHUC"].ToString();
            TTTourfrm.lblNoiKH.Text = dttable.Rows[0]["TENDDI"].ToString();
            TTTourfrm.lblSoNgay.Text = dttable.Rows[0]["TG"].ToString() + " ngày";
            TTTourfrm.lblSlot.Text = dttable.Rows[0]["SOLUONGCONLAI"].ToString();
            int SoDem = Convert.ToInt32(dttable.Rows[0]["TG"].ToString()) - 1;
            TTTourfrm.lblTGnho.Text = TTTourfrm.lblSoNgay.Text + " " + SoDem + " đêm";
            TTTourfrm.lblPT.Text = dttable.Rows[0]["TENPT"].ToString();
            TTTourfrm.lblDiemDen.Text = dttable.Rows[0]["TENDDEN"].ToString();
            TTTourfrm.lblKS.Text = dttable.Rows[0]["TENLKS"].ToString();
            TTTourfrm.lblMaTour.Text = dttable.Rows[0]["MATOUR"].ToString();

            String ngayDiTour = dttable.Rows[0]["NGAYDITOUR"].ToString();

            DateTime today = DateTime.Now;
            DateTime lastDay = Convert.ToDateTime(dttable.Rows[0]["NGAYDITOUR"]);

            TimeSpan calDays = lastDay - today;

            // Ngày đặt Tour phải trước Ngày đi Tour 1 ngày
            if (Convert.ToDouble(calDays.TotalDays) <= 1)
            {
                TTTourfrm.btlDatTour.Enabled = false;
            }

            if (Convert.ToDouble(calDays.TotalDays) > 1)
            {
                TTTourfrm.btlDatTour.Enabled = true;
            }
            openChildForm(TTTourfrm);
        }

        private void KQSoTour()
        {
            int numRows = dgvTour.Rows.Count - 1;
            lblKQSoTour.Text = "Đã tìm được " + numRows.ToString() + " tour";
        }

        public bool CheckLocKQ()
        {
            string notice = "";
            if (cmbSoNgay.SelectedIndex == 0)
            {
                notice += "\nChưa chọn số ngày đi!";
            }
            if (numSL.Value == 0)
            {
                notice += "\nChưa chọn số lượng thành viên";
            }

            if ((cmbSoNgay.SelectedIndex == 0) || (numSL.Value == 0))
            {
                MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
            ShowAllTour();
            KQSoTour();
            numSL.Value = 0;
        }

        private void btlLocKQ_Click(object sender, EventArgs e)
        {
            CheckLocKQ();
            CheckSoNgay();
            KQSoTour();
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaLTour = CheckMaLTour();
            Tour.MaDDi = cmbDiemDi.SelectedValue.ToString();
            Tour.MaDDen = cmbDiemDen.SelectedValue.ToString();
            Tour.SoNgay1 = SoNgay1;
            Tour.SoNgay2 = SoNgay2;
            Tour.NgayDiTour = dtpNgayDi.Value;
            Tour.SLLoc = Convert.ToInt32(numSL.Value);
            Tour.MaPT = cmbPhuongTien.SelectedValue.ToString();
            dgvTour.DataSource = bllTour.LocTour(Tour);
        }
    }
}
