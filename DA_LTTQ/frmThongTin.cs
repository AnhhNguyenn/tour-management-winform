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
    public partial class frmThongTin : Form
    {
        DiemDL_BLL bllDDL;
        DiemDi_BLL bllDDi;
        PhuongTien_BLL bllPT;
        LLT_BLL bllLLT;
        LoaiKS_BLL bllLKS;
        KhachSan_BLL bllKS;
        LoaiTour_BLL bllLoaiTour;

        public frmThongTin()
        {
            InitializeComponent();
            bllDDL = new DiemDL_BLL();
            bllPT = new PhuongTien_BLL();
            bllLLT = new LLT_BLL();
            bllLKS = new LoaiKS_BLL();
            bllKS = new KhachSan_BLL();
            bllLoaiTour = new LoaiTour_BLL();
            bllDDi = new DiemDi_BLL();
        }
        #region Điểm khởi hành
        private void btnResetDKH_Click(object sender, EventArgs e)
        {
            txtMaDKH.Clear();
            txtMaDKH.Enabled = true;
            txtTenDKH.Clear();
            cmbLTDKH.SelectedItem = 0;
        }

        public void ShowAllDDi()
        {
            DataTable dataTable = bllDDi.GetAllDDiTrongNc();
            dgvDDI.DataSource = dataTable;
        }

        public bool CheckDataDDi()
        {
            if (string.IsNullOrEmpty(txtMaDKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã điểm đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDKH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên điểm đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDKH.Focus();
                return false;
            }
            return true;
        }

        private void cmbLTDKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbl_DiemDi DDI = new tbl_DiemDi();
            DDI.MaLTour = cmbLTDKH.SelectedValue.ToString();
            DataTable dataTable = bllDDi.GetAllDDi(DDI);
            dgvDDI.DataSource = dataTable;
        }

        private void btnThemDDI_Click(object sender, EventArgs e)
        {
            if (CheckDataDDi())
            {
                tbl_DiemDi dd = new tbl_DiemDi();
                dd.MaDDI = txtMaDKH.Text;
                dd.TenDDI = txtTenDKH.Text;
                dd.MaLTour = cmbLTDKH.SelectedValue.ToString();
                if (bllDDi.InsertDDi(dd))
                    ShowAllDDi();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvDDI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDKH.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaDKH.Text = dgvDDI.Rows[index].Cells[0].Value.ToString();
                txtTenDKH.Text = dgvDDI.Rows[index].Cells[1].Value.ToString();
            }
            txtMaDKH.Enabled = false;
        }

        private void btnSuaDDi_Click(object sender, EventArgs e)
        {
            if (CheckDataDDi())
            {
                tbl_DiemDi dd = new tbl_DiemDi();
                dd.MaDDI = txtMaDKH.Text;
                dd.TenDDI = txtTenDKH.Text;
                dd.MaLTour = cmbLTDKH.SelectedValue.ToString();
                if (bllDDi.UpdateDDi(dd))
                    ShowAllDDi();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoaDDi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tbl_DiemDi dd = new tbl_DiemDi();
                dd.MaDDI = txtMaDKH.Text;
                if (bllDDi.DeleteDDi(dd))
                    ShowAllDDi();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region Điểm du lịch
    public void ShowAllDDL()
        {
            DataTable dataTable = bllDDL.GetAllDDLTrongNc();
            dgvDDL.DataSource = dataTable;
        }

        private void cmbLTDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbl_DiemDL DDL = new tbl_DiemDL();
            DDL.MaLTour = cmbLTDDL.SelectedValue.ToString();
            DataTable dataTable = bllDDL.GetAllDDL(DDL);
            dgvDDL.DataSource = dataTable;
        }

        public bool CheckDataDDL()
        {
            if (string.IsNullOrEmpty(txtTenDDL.Text))
            {
                MessageBox.Show("Chưa nhập tên điểm du lịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDDL.Focus();
                return false;
            }
            return true;
        }

        private void btnResetDDL_Click(object sender, EventArgs e)
        {
            txtMaDDL.Clear();
            txtMaDDL.Enabled = true;
            txtTenDDL.Clear();
            cmbLTDDL.SelectedItem = 0;
        }

        private void btnThemDDL_Click(object sender, EventArgs e)
        {
            if (CheckDataDDL())
            {
                txtMaDDL.Enabled = false;
                tbl_DiemDL ddl = new tbl_DiemDL();
                ddl.MaDDen = txtMaDDL.Text;
                ddl.TenDDen = txtTenDDL.Text;
                ddl.MaLTour = cmbLTDDL.SelectedValue.ToString();
                if (bllDDL.InsertDDL(ddl))
                    ShowAllDDL();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvDDL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDDL.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaDDL.Text = dgvDDL.Rows[index].Cells[0].Value.ToString();
                txtTenDDL.Text = dgvDDL.Rows[index].Cells[1].Value.ToString();
                cmbLTDDL.Text = dgvDDL.Rows[index].Cells[2].Value.ToString();             
            }
            txtMaDDL.Enabled = false;
        }

        private void btnSuaDDL_Click(object sender, EventArgs e)
        {
            if (CheckDataDDL())
            {
                tbl_DiemDL ddl = new tbl_DiemDL();
                ddl.MaDDen = txtMaDDL.Text;
                ddl.TenDDen = txtTenDDL.Text;
                ddl.MaLTour = cmbLTDDL.SelectedValue.ToString();
                if (bllDDL.UpdateDDL(ddl))
                    ShowAllDDL();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoaDDL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tbl_DiemDL ddl = new tbl_DiemDL();
                ddl.MaDDen = txtMaDDL.Text;
                if (bllDDL.DeleteDDL(ddl))
                    ShowAllDDL();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region Phương tiện
        public void ShowAllPhuongTien()
        {
            DataTable dataTable = bllPT.GetAllPhuongTien();
            dgvPT.DataSource = dataTable;
        }

        public bool CheckDataPT()
        {
            if (string.IsNullOrEmpty(txtMaPT.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenPT.Text))
            {
                MessageBox.Show("Bạn chưa nhập phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPT.Focus();
                return false;
            }
            return true;
        }

        private void btnResetPT_Click(object sender, EventArgs e)
        {
            txtMaPT.Clear();
            txtMaPT.Enabled = true;
            txtTenPT.Clear();
        }

        private void btnThemPT_Click(object sender, EventArgs e)
        {
            if (CheckDataPT())
            {
                txtMaPT.Enabled = false;
                tbl_PhuongTien pt = new tbl_PhuongTien();
                pt.MaPT = txtMaPT.Text;
                pt.TenPT = txtTenPT.Text;
                if (bllPT.InsertPhuongTien(pt))
                    ShowAllPhuongTien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSuaPT_Click(object sender, EventArgs e)
        {
            if (CheckDataPT())
            {
                tbl_PhuongTien pt = new tbl_PhuongTien();
                pt.MaPT = txtMaPT.Text;
                pt.TenPT = txtTenPT.Text;
                if (bllPT.UpdatePhuongTien(pt))
                    ShowAllPhuongTien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoaPT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tbl_PhuongTien pt = new tbl_PhuongTien();
                pt.MaPT = txtMaPT.Text;
                if (bllPT.DeletePhuongTien(pt))
                    ShowAllPhuongTien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPT.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaPT.Text = dgvPT.Rows[index].Cells[0].Value.ToString();
                txtTenPT.Text = dgvPT.Rows[index].Cells[1].Value.ToString();
            }
            txtMaPT.Enabled = false;
        }
        #endregion

        #region Loại lứa tuổi
        public void ShowAllLoaiLuaTuoi()
        {
            DataTable dataTable = bllLLT.GetAllLLT();
            dgvLLT.DataSource = dataTable;
        }

        private void btnResetLLT_Click(object sender, EventArgs e)
        {
            txtMaLLT.Clear();
            txtMaLLT.Enabled = true;
            txtTenLLT.Clear();
            txtGiaLLT.Clear();
        }

        public bool CheckDataLLT()
        {
            if (string.IsNullOrEmpty(txtMaLLT.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã loại lứa tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLLT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenLLT.Text))
            {
                MessageBox.Show("Bạn chưa nhập lứa tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLLT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGiaLLT.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá loại lứa tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaLLT.Focus();
                return false;
            }
            return true;
        }

        private void btnThemLLT_Click(object sender, EventArgs e)
        {
            if (CheckDataLLT())
            {
                txtMaLLT.Enabled = false;
                tbl_LoaiLT llt = new tbl_LoaiLT();
                llt.MaLLT = txtMaLLT.Text;
                llt.TenLLT = txtTenLLT.Text;
                llt.GiaTienLLT = Convert.ToDecimal(txtGiaLLT.Text);
                if (bllLLT.InsertLoaiLuaTuoi(llt))
                    ShowAllLoaiLuaTuoi();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSuaLLT_Click(object sender, EventArgs e)
        {
            if (CheckDataLLT())
            {
                tbl_LoaiLT llt = new tbl_LoaiLT();
                llt.MaLLT = txtMaLLT.Text;
                llt.TenLLT = txtTenLLT.Text;
                llt.GiaTienLLT = Convert.ToDecimal(txtGiaLLT.Text);
                if (bllLLT.UpdateLoaiLuaTuoi(llt))
                    ShowAllLoaiLuaTuoi();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoaLLT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tbl_LoaiLT llt = new tbl_LoaiLT();
                llt.MaLLT = txtMaLLT.Text;
                if (bllLLT.DeleteLoaiLuaTuoi(llt))
                    ShowAllLoaiLuaTuoi();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvLLT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLLT.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaLLT.Text = dgvLLT.Rows[index].Cells[0].Value.ToString();
                txtTenLLT.Text = dgvLLT.Rows[index].Cells[1].Value.ToString();
                txtGiaLLT.Text = dgvLLT.Rows[index].Cells[2].Value.ToString();
            }
            txtMaLLT.Enabled = false;
        }
        #endregion

        #region Loại khách sạn
        public void ShowAllLoaiKhachSan()
        {
            DataTable dataTable = bllLKS.GetAllLoaiKhachSan();
            dgvLKS.DataSource = dataTable;
        }

        private void btnResetLKS_Click(object sender, EventArgs e)
        {
            txtMaLKS.Clear();
            txtMaLKS.Enabled = true;
            txtTenLKS.Clear();
        }

        public bool CheckDataLKS()
        {
            if (string.IsNullOrEmpty(txtMaLKS.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã loại khách sạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLKS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenLKS.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên loại khách sạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLKS.Focus();
                return false;
            }
            return true;
        }

        private void btnThemLKS_Click(object sender, EventArgs e)
        {
            if (CheckDataLKS())
            {
                txtMaLKS.Enabled = false;
                tbl_LoaiKS lks = new tbl_LoaiKS();
                lks.MALKS = txtMaLKS.Text;
                lks.TENLKS = txtTenLKS.Text;
                if (bllLKS.InsertLoaiKhachSan(lks))
                    ShowAllLoaiKhachSan();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSuaLKS_Click(object sender, EventArgs e)
        {
            if (CheckDataLKS())
            {
                tbl_LoaiKS lks = new tbl_LoaiKS();
                lks.MALKS = txtMaLKS.Text;
                lks.TENLKS = txtTenLKS.Text;
                if (bllLKS.UpdateLoaiKhachSan(lks))
                    ShowAllLoaiKhachSan();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoaLKS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tbl_LoaiKS lks = new tbl_LoaiKS();
                lks.MALKS = txtMaLKS.Text;
                if (bllLKS.DeleteLoaiKhachSan(lks))
                    ShowAllLoaiKhachSan();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvLKS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLKS.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaLKS.Text = dgvLKS.Rows[index].Cells[0].Value.ToString();
                txtTenLKS.Text = dgvLKS.Rows[index].Cells[1].Value.ToString();
            }
            txtMaLKS.Enabled = false;
        }
        #endregion

        #region Khách sạn
        public void ShowAllKhachSan()
        {
            DataTable dataTable = bllKS.GetAllKhachSan();
            dgvKS.DataSource = dataTable;
        }

        private void btnResetKS_Click(object sender, EventArgs e)
        {
            txtMaKS.Clear();
            txtMaKS.Enabled = true;
            txtTenKS.Clear();
            txtDiaChiKS.Clear();
            txtGiaKS.Clear();
            cmbLoaiKS.SelectedItem = 0;
        }

        public bool CheckDataKhachSan()
        {
            if (string.IsNullOrEmpty(txtMaKS.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã Khách sạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKS.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên khách sạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGiaKS.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá khách sạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaKS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChiKS.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách sạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChiKS.Focus();
                return false;
            }
            return true;
        }

        private void btnThemKS_Click(object sender, EventArgs e)
        {
            if (CheckDataKhachSan())
            {
                txtMaKS.Enabled = true;
                tbl_KhachSan ks = new tbl_KhachSan();
                ks.MAKS = txtMaKS.Text;
                ks.TENKS = txtTenKS.Text;
                ks.GIAKS = txtGiaKS.Text;
                ks.DIACHI = txtDiaChiKS.Text;
                ks.MALKS = cmbLoaiKS.Text;
                if (bllKS.InsertKhachSan(ks))
                    ShowAllKhachSan();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSuaKS_Click(object sender, EventArgs e)
        {
            if (CheckDataKhachSan())
            {
                tbl_KhachSan ks = new tbl_KhachSan();
                ks.MAKS = txtMaKS.Text;
                ks.TENKS = txtTenKS.Text;
                ks.GIAKS = txtGiaKS.Text;
                ks.DIACHI = txtDiaChiKS.Text;
                ks.MALKS = cmbLoaiKS.Text;
                if (bllKS.UpdateKhachSan(ks))
                    ShowAllKhachSan();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoaKS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tbl_KhachSan ks = new tbl_KhachSan();
                ks.MAKS = txtMaKS.Text;
                if (bllKS.DeleteKhachSan(ks))
                    ShowAllKhachSan();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void dgvKS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKS.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaKS.Text = dgvKS.Rows[index].Cells[0].Value.ToString();
                txtTenKS.Text = dgvKS.Rows[index].Cells[1].Value.ToString();
                txtGiaKS.Text = dgvKS.Rows[index].Cells[2].Value.ToString();
                txtDiaChiKS.Text = dgvKS.Rows[index].Cells[3].Value.ToString();
                cmbLoaiKS.Text = dgvKS.Rows[index].Cells[4].Value.ToString();
            }
            txtMaKS.Enabled = false;
        }

        void LoadID()
        {
            string DDL;
            if (bllDDL.GetSLDDL() < 10)
                DDL = "DDL0" + bllDDL.GetSLDDL().ToString();
            else
                DDL = "DDL" + bllDDL.GetSLDDL().ToString();
            txtMaDDL.Text = DDL;
        }
        #endregion

        private void frmThongTin_Load(object sender, EventArgs e)
        {
            ShowAllDDL();
            ShowAllDDi();
            ShowAllPhuongTien();
            ShowAllLoaiLuaTuoi();
            ShowAllLoaiKhachSan();
            ShowAllKhachSan();

            cmbLTDDL.ValueMember = "MaLTour";
            cmbLTDDL.DisplayMember = "TenLTour";
            cmbLTDDL.DataSource = bllLoaiTour.GetAllLTour();

            cmbLTDKH.ValueMember = "MaLTour";
            cmbLTDKH.DisplayMember = "TenLTour";
            cmbLTDKH.DataSource = bllLoaiTour.GetAllLTour();
            //LoadID();

            cmbLoaiKS.ValueMember = "TENLKS";
            cmbLoaiKS.DisplayMember = "MALKS";
            cmbLoaiKS.DataSource = bllLKS.GetAllLoaiKhachSan();
        }

        private void txtGiaKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
