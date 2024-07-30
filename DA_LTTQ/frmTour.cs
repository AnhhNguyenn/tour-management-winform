using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmTour : Form
    {
        Tour_BLL bllTour;
        LoaiKS_BLL bllLT;
        LoaiTour_BLL bllLoaiTour;
        PhuongTien_BLL bllPhuongTien;
        DiemDi_BLL bllDiemDi;
        DiemDL_BLL bllDiemDen;
        LoaiKS_BLL bllLKS;
        public frmTour()
        {
            InitializeComponent();
            bllTour = new Tour_BLL();
            bllLT = new LoaiKS_BLL();
            bllLoaiTour = new LoaiTour_BLL();
            bllPhuongTien = new PhuongTien_BLL();
            bllDiemDi = new DiemDi_BLL();
            bllDiemDen = new DiemDL_BLL();
            bllLKS = new LoaiKS_BLL();
        }

        void ResetBox()
        {
            txtTenTour.Clear();
            txtMoTa.Clear();
            numSL.Value = 0;
            dtpNgayDi.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            cmbLoaiTour.SelectedIndex = 0;
            cmbPT.SelectedIndex = 0;
            cmbDiemDi.SelectedIndex = 0;
            cmbKS.SelectedIndex = 0;
            txtGiaTour.Clear();
        }

        void OpenBox()
        {
            txtTenTour.ReadOnly = false;
            txtMoTa.ReadOnly = false;
            numSL.Enabled = true;
            dtpNgayDi.Enabled = true;
            dtpNgayKT.Enabled = true;
            cmbLoaiTour.Enabled = true;
            cmbPT.Enabled = true;
            cmbDiemDi.Enabled = true;
            cmbDDen.Enabled = true;
            cmbKS.Enabled = true;
            txtGiaTour.Enabled = true;
            btnAnh1.Enabled = true;
            btnHinh2.Enabled = true;
            btnHinh3.Enabled = true;
            btnHinh4.Enabled = true;
        }

        void CloseBox()
        {
            txtTenTour.ReadOnly = true;
            txtMoTa.ReadOnly = true;
            numSL.Enabled = false;
            dtpNgayDi.Enabled = false;
            dtpNgayKT.Enabled = false;
            cmbLoaiTour.Enabled = false;
            cmbPT.Enabled = false;
            cmbDiemDi.Enabled = false;
            cmbKS.Enabled = false;
            cmbDDen.Enabled = false;
            txtGiaTour.Enabled = false;
            btnAnh1.Enabled = false;
            btnHinh2.Enabled = false;
            btnHinh3.Enabled = false;
            btnHinh4.Enabled = false;
        }

        bool checkThemSua = false;
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetBox();
            ResetInf();
            string MaTour;
            if (bllTour.GetMaTour() < 10)
                MaTour = "T0" + bllTour.GetMaTour().ToString();
            else
                MaTour = "T" + bllTour.GetMaTour().ToString();
            txtMaTour.Text = MaTour;
            OpenBox();
            checkThemSua = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = true;

            //txtMaTour.ReadOnly = false;
            //lblMaTour.Text = MaTour;
        }

        private void txtGiaTour_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ResetInf()
        {
            lblTenTour.Text = "Tên Tour";
            lblMoTa.Text = "Mô tả";
            lblGiaTour.Text = "Giá Tour";
            picHinh1.Image = null;
            picHinh2.Image = null;
            picHinh3.Image = null;
            picHinh4.Image = null;
            lblTGKH.Text = "TG khởi hành";
            lblNoiKH.Text = "Nơi khởi hành";
            lblSoNgay.Text = "Số ngày";
            lblSlot.Text = "Số lượng";
            lblTGnho.Text = "Thời gian";
            lblPT.Text = "Phương tiện";
            lblDiemDen.Text = "Điểm đến";
            lblKS.Text = "Khách sạn";
            lblMaTour.Text = "Mã Tour";
        }

        private bool checkData()
        {
            string notice = "";
            if (string.IsNullOrEmpty(txtTenTour.Text))
            {
                notice += "\nChưa nhập tên Tour!";
                txtTenTour.Focus();
            }

            if (string.IsNullOrEmpty(txtMoTa.Text))
            {
                notice += "\nChưa nhập mô tả!";
                txtMoTa.Focus();
            }

            if (numSL.Value == 0)
            {
                notice += "\nChưa nhập tên số lượng!";
            }

            if (string.IsNullOrEmpty(txtGiaTour.Text))
            {
                notice += "\nChưa nhập giá Tour!";
                txtGiaTour.Focus();
            }

            if (dtpNgayKT.Value <= dtpNgayDi.Value)
            {
                notice += "\nNgày kết thúc phải lớn hơn ngày khởi hành!";
            }

            if (dtpNgayDi.Value < DateTime.Now)
            {
                notice += "\nNgày khởi hành phải lớn hơn ngày hôm nay!";
            }

            if (dtpNgayKT.Value < DateTime.Now)
            {
                notice += "Ngày kết thúc phải lớn hơn ngày hôm nay!";
            }


            if (imgLocation1 == null)
            {
                notice += "\nChưa thêm ảnh 1!";
            }

            if (imgLocation2 == null)
            {
                notice += "\nChưa thêm ảnh 2!";
            }

            if (imgLocation3 == null)
            {
                notice += "\nChưa thêm ảnh 3!";
            }

            if (imgLocation4 == null)
            {
                notice += "\nChưa thêm ảnh 4!";
            }

            if ((dtpNgayDi.Value < DateTime.Now) || (dtpNgayKT.Value < DateTime.Now) || (string.IsNullOrEmpty(txtTenTour.Text)) || (string.IsNullOrEmpty(txtMoTa.Text)) || (numSL.Value == 0) || (string.IsNullOrEmpty(txtGiaTour.Text) || (dtpNgayKT.Value <= dtpNgayDi.Value) || (imgLocation1 == null) || (imgLocation2 == null) || (imgLocation3 == null) || (imgLocation4 == null)))
            {
                MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool checkData1()
        {
            string notice = "";

            if (string.IsNullOrEmpty(txtTenTour.Text))
            {
                notice += "\nChưa nhập tên Tour!";
                txtTenTour.Focus();
            }

            if (string.IsNullOrEmpty(txtMoTa.Text))
            {
                notice += "\nChưa nhập mô tả!";
                txtMoTa.Focus();
            }

            if (string.IsNullOrEmpty(txtGiaTour.Text))
            {
                notice += "\nChưa nhập giá Tour!";
                txtGiaTour.Focus();
            }

            if (dtpNgayKT.Value <= dtpNgayDi.Value)
            {
                notice += "\nNgày kết thúc phải lớn hơn ngày khởi hành!";
            }

            if (dtpNgayDi.Value < DateTime.Now)
            {
                notice += "\nNgày khởi hành phải lớn hơn ngày hôm nay!";
            }

            if (dtpNgayKT.Value < DateTime.Now)
            {
                notice += "\nNgày kết thúc phải lớn hơn ngày hôm nay!";
            }

            if ((dtpNgayDi.Value < DateTime.Now) || (dtpNgayKT.Value < DateTime.Now) || (string.IsNullOrEmpty(txtTenTour.Text)) || (string.IsNullOrEmpty(txtMoTa.Text)) || (string.IsNullOrEmpty(txtGiaTour.Text) || (dtpNgayKT.Value <= dtpNgayDi.Value)))
            {
                MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public void ShowAllTour()
        {
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaLTour = cmbSortLT.SelectedValue.ToString();
            DataTable dataTable = bllTour.GetLocTour(Tour);
            dgvTour.DataSource = dataTable;
        }

        string imgLocation1, imgLocation2, imgLocation3, imgLocation4;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkThemSua == true)
            {
                if (checkData())
                {
                    tbl_Tour Tour = new tbl_Tour();
                    string MaTour;
                    if (bllTour.GetMaTour() < 10)
                        MaTour = "T0" + bllTour.GetMaTour().ToString();
                    else
                        MaTour = "T" + bllTour.GetMaTour().ToString();
                    txtMaTour.Text = MaTour;

                    Tour.MaTour = txtMaTour.Text;
                    Tour.TenTour = txtTenTour.Text;
                    Tour.MoTa = txtMoTa.Text;
                    Tour.SoLuongConLai = Convert.ToInt32(numSL.Value);
                    Tour.NgayDiTour = Convert.ToDateTime(dtpNgayDi.Text);
                    Tour.NgayKetThuc = Convert.ToDateTime(dtpNgayKT.Value);

                    byte[] images1 = null;
                    FileStream Stream1 = new FileStream(imgLocation1, FileMode.Open, FileAccess.Read);
                    BinaryReader brs1 = new BinaryReader(Stream1);
                    images1 = brs1.ReadBytes((int)Stream1.Length);

                    byte[] images2 = null;
                    FileStream Stream2 = new FileStream(imgLocation2, FileMode.Open, FileAccess.Read);
                    BinaryReader brs2 = new BinaryReader(Stream2);
                    images2 = brs2.ReadBytes((int)Stream2.Length);

                    byte[] images3 = null;
                    FileStream Stream3 = new FileStream(imgLocation3, FileMode.Open, FileAccess.Read);
                    BinaryReader brs3 = new BinaryReader(Stream3);
                    images3 = brs3.ReadBytes((int)Stream3.Length);

                    byte[] images4 = null;
                    FileStream Stream4 = new FileStream(imgLocation4, FileMode.Open, FileAccess.Read);
                    BinaryReader brs4 = new BinaryReader(Stream4);
                    images4 = brs4.ReadBytes((int)Stream4.Length);
                    Tour.Anh1 = images1;
                    Tour.Anh2 = images2;
                    Tour.Anh3 = images3;
                    Tour.Anh4 = images4;
                    Tour.GiaTour = Convert.ToDecimal(txtGiaTour.Text);
                    Tour.MaLTour = cmbLoaiTour.SelectedValue.ToString();
                    Tour.MaPT = cmbPT.SelectedValue.ToString();
                    Tour.MaDDi = cmbDiemDi.SelectedValue.ToString();
                    Tour.MaDDen = cmbDDen.SelectedValue.ToString();
                    Tour.MaLKS = cmbKS.SelectedValue.ToString();

                    if (bllTour.InsertTour(Tour))
                    {
                        imgLocation1 = null;
                        imgLocation2 = null;
                        imgLocation3 = null;
                        imgLocation4 = null;
                        ShowAllTour();
                        CloseBox();
                        MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;

                        activeForm = null;
                        lblSlot.Text = numSL.Value.ToString();
                        lblTGKH.Text = dtpNgayDi.Value.ToString();
                        lblSoNgay.Text = (dtpNgayKT.Value.Date - dtpNgayDi.Value.Date).ToString("dd") + " ngày";
                        lblTGnho.Text = (dtpNgayKT.Value.Date - dtpNgayDi.Value.Date).ToString("dd") + " ngày " + (Convert.ToInt32((dtpNgayKT.Value.Date - dtpNgayDi.Value.Date).ToString("dd")) - 1).ToString() + " đêm";
                        lblPT.Text = cmbPT.Text;
                        lblNoiKH.Text = cmbDiemDi.Text;
                        lblDiemDen.Text = cmbDDen.Text;
                        lblKS.Text = cmbKS.Text;
                        lblTenTour.Text = txtTenTour.Text;
                        lblMoTa.Text = txtMoTa.Text;
                        lblGiaTour.Text = string.Format("{0:#,##0}", decimal.Parse(txtGiaTour.Text.ToString())) + " đ/khách";
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtTenTour.Focus();
                    }
                }
            }

            if (checkThemSua == false)
            {
                if (checkData1())
                {
                    tbl_Tour Tour = new tbl_Tour();

                    Tour.MaTour = txtMaTour.Text;
                    Tour.TenTour = txtTenTour.Text;
                    Tour.MoTa = txtMoTa.Text;
                    Tour.SoLuongConLai = Convert.ToInt32(numSL.Value);
                    Tour.NgayDiTour = Convert.ToDateTime(dtpNgayDi.Text);
                    Tour.NgayKetThuc = Convert.ToDateTime(dtpNgayKT.Value);

                    frmThongTinTour TTTourfrm = new frmThongTinTour();
                    DataTable dttable = new DataTable();
                    tbl_Tour Tour2 = new tbl_Tour();
                    Tour2.MaTour = dgvTour.SelectedRows[0].Cells[0].Value.ToString();
                    dttable = bllTour.GetTTTour(Tour2);

                    /// fix image

                    //picHinh1.Image = GetImage((byte[])(dttable.Rows[0]["ANH1"]));
                    //picHinh2.Image = GetImage((byte[])(dttable.Rows[0]["ANH2"]));
                    //picHinh3.Image = GetImage((byte[])(dttable.Rows[0]["ANH3"]));
                    //picHinh4.Image = GetImage((byte[])(dttable.Rows[0]["ANH4"]));




                    //MemoryStream ms1 = new MemoryStream((byte[])(dttable.Rows[0]["ANH1"]));
                    if (imgLocation1 != null)
                    {
                        byte[] images1 = null;
                        FileStream Stream1 = new FileStream(imgLocation1, FileMode.Open, FileAccess.Read);
                        BinaryReader brs1 = new BinaryReader(Stream1);
                        images1 = brs1.ReadBytes((int)Stream1.Length);
                        Tour.Anh1 = images1;
                    }
                    if (imgLocation1 == null)
                    {
                        MemoryStream ms1 = new MemoryStream();
                        picHinh1.Image.Save(ms1, picHinh1.Image.RawFormat);
                        pic1 = ms1.GetBuffer();
                        Tour.Anh1 = pic1;
                    }

                    if (imgLocation2 != null)
                    {
                        byte[] images2 = null;
                        FileStream Stream2 = new FileStream(imgLocation2, FileMode.Open, FileAccess.Read);
                        BinaryReader brs2 = new BinaryReader(Stream2);
                        images2 = brs2.ReadBytes((int)Stream2.Length);
                        Tour.Anh2 = images2;
                    }

                    if (imgLocation2 == null)
                    {
                        MemoryStream ms1 = new MemoryStream();
                        picHinh2.Image.Save(ms1, picHinh2.Image.RawFormat);
                        pic2 = ms1.GetBuffer();
                        Tour.Anh2 = pic2;
                    }

                    if (imgLocation3 != null)
                    {
                        byte[] images3 = null;
                        FileStream Stream3 = new FileStream(imgLocation3, FileMode.Open, FileAccess.Read);
                        BinaryReader brs3 = new BinaryReader(Stream3);
                        images3 = brs3.ReadBytes((int)Stream3.Length);
                        Tour.Anh3 = images3;
                    }
                    if (imgLocation3 == null)
                    {
                        MemoryStream ms1 = new MemoryStream();
                        picHinh3.Image.Save(ms1, picHinh3.Image.RawFormat);
                        pic3 = ms1.GetBuffer();
                        Tour.Anh3 = pic3;
                    }


                    if (imgLocation4 != null)
                    {
                        byte[] images4 = null;
                        FileStream Stream4 = new FileStream(imgLocation4, FileMode.Open, FileAccess.Read);
                        BinaryReader brs4 = new BinaryReader(Stream4);
                        images4 = brs4.ReadBytes((int)Stream4.Length);
                        Tour.Anh4 = images4;
                    }
                    if (imgLocation4 == null)
                    {
                        MemoryStream ms1 = new MemoryStream();
                        picHinh4.Image.Save(ms1, picHinh4.Image.RawFormat);
                        pic4 = ms1.GetBuffer();
                        Tour.Anh4 = pic4;
                    }


                    Tour.GiaTour = Convert.ToDecimal(txtGiaTour.Text);
                    Tour.MaLTour = cmbLoaiTour.SelectedValue.ToString();
                    Tour.MaPT = cmbPT.SelectedValue.ToString();
                    Tour.MaDDi = cmbDiemDi.SelectedValue.ToString();
                    Tour.MaDDen = cmbDDen.SelectedValue.ToString();
                    Tour.MaLKS = cmbKS.SelectedValue.ToString();

                    if (bllTour.Update(Tour))
                    {
                        imgLocation1 = null;
                        imgLocation2 = null;
                        imgLocation3 = null;
                        imgLocation4 = null;
                        ShowAllTour();
                        CloseBox();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;

                        lblSlot.Text = numSL.Value.ToString();
                        lblTGKH.Text = dtpNgayDi.Value.ToString();
                        lblSoNgay.Text = (dtpNgayKT.Value.Date - dtpNgayDi.Value.Date).ToString("dd") + " ngày";
                        lblTGnho.Text = (dtpNgayKT.Value.Date - dtpNgayDi.Value.Date).ToString("dd") + " ngày " + (Convert.ToInt32((dtpNgayKT.Value.Date - dtpNgayDi.Value.Date).ToString("dd")) - 1).ToString() + " đêm";
                        lblPT.Text = cmbPT.Text;
                        lblNoiKH.Text = cmbDiemDi.Text;
                        lblDiemDen.Text = cmbDDen.Text;
                        lblKS.Text = cmbKS.Text;
                        lblTenTour.Text = txtTenTour.Text;
                        lblMoTa.Text = txtMoTa.Text;
                        lblGiaTour.Text = string.Format("{0:#,##0}", decimal.Parse(txtGiaTour.Text.ToString())) + " đ/khách";
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau 1", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtTenTour.Focus();
                    }
                }
            }
        }

        private void loadClick()
        {
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaTour = dgvTour.SelectedRows[0].Cells[0].Value.ToString();
            DataTable dataTable2 = new DataTable();
            dataTable2 = bllTour.GetAllTour2(Tour);
            txtMaTour.Text = dataTable2.Rows[0]["MATOUR"].ToString();
            txtTenTour.Text = dataTable2.Rows[0]["TENTOUR"].ToString();
            txtMoTa.Text = dataTable2.Rows[0]["MOTA"].ToString();
            numSL.Value = Convert.ToDecimal(dataTable2.Rows[0]["SOLUONGCONLAI"]);
            dtpNgayDi.Value = Convert.ToDateTime(dataTable2.Rows[0]["NGAYDITOUR"]);
            dtpNgayKT.Value = Convert.ToDateTime(dataTable2.Rows[0]["NGAYKETTHUC"]);
            cmbLoaiTour.SelectedValue = dataTable2.Rows[0]["MALTOUR"].ToString();
            cmbPT.SelectedValue = dataTable2.Rows[0]["MAPT"].ToString();
            cmbDiemDi.SelectedValue = dataTable2.Rows[0]["MADDI"].ToString();
            cmbDDen.SelectedValue = dataTable2.Rows[0]["MADDEN"].ToString();
            cmbKS.SelectedValue = dataTable2.Rows[0]["MALKS"].ToString();
            txtGiaTour.Text = dataTable2.Rows[0]["GIATOUR"].ToString();
        }

        private void btnAnh1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png|*.png|jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation1 = dialog.FileName.ToString();
                picHinh1.ImageLocation = imgLocation1;
            }
        }

        private void btnHinh2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png|*.png|jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation2 = dialog.FileName.ToString();
                picHinh2.ImageLocation = imgLocation2;
            }
        }

        private void frmTour_Load(object sender, EventArgs e)
        {
            loadcmb();
            CloseBox();
            ShowAllTour();
            ResetInf();
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnHinh3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png|*.png|jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation3 = dialog.FileName.ToString();
                picHinh3.ImageLocation = imgLocation3;
            }
        }

        private void btnHinh4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png|*.png|jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation4 = dialog.FileName.ToString();
                picHinh4.ImageLocation = imgLocation4;
            }
        }

        private Image GetImage(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);
            return Image.FromStream(ms);
        }

        byte[] pic1, pic2, pic3, pic4;
        private void dgvTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                CloseBox();

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                loadClick();
                DataTable dttable = new DataTable();
                tbl_Tour Tour = new tbl_Tour();
                Tour.MaTour = dgvTour.SelectedRows[0].Cells[0].Value.ToString();
                dttable = bllTour.GetTTTour(Tour);
                lblTenTour.Text = dttable.Rows[0]["TENTOUR"].ToString();
                lblMoTa.Text = dttable.Rows[0]["MOTA"].ToString();
                lblGiaTour.Text = string.Format("{0:#,##0}", decimal.Parse(dttable.Rows[0]["GIATOUR"].ToString())) + "/Khách";

                picHinh1.Image = GetImage((byte[])(dttable.Rows[0]["ANH1"]));
                picHinh2.Image = GetImage((byte[])(dttable.Rows[0]["ANH2"]));
                picHinh3.Image = GetImage((byte[])(dttable.Rows[0]["ANH3"]));
                picHinh4.Image = GetImage((byte[])(dttable.Rows[0]["ANH4"]));

                MemoryStream ms1 = new MemoryStream();
                picHinh1.Image.Save(ms1, picHinh1.Image.RawFormat);
                pic1 = ms1.GetBuffer();
                picHinh2.Image.Save(ms1, picHinh2.Image.RawFormat);
                pic2 = ms1.GetBuffer();
                picHinh3.Image.Save(ms1, picHinh3.Image.RawFormat);
                pic3 = ms1.GetBuffer();
                picHinh4.Image.Save(ms1, picHinh4.Image.RawFormat);
                pic4 = ms1.GetBuffer();

                lblTGKH.Text = dttable.Rows[0]["NGAYDITOUR"].ToString();
                //dttable.Rows[0]["NGAYKETTHUC"].ToString();
                lblNoiKH.Text = dttable.Rows[0]["TENDDI"].ToString();
                lblSoNgay.Text = dttable.Rows[0]["TG"].ToString() + " ngày";
                lblSlot.Text = dttable.Rows[0]["SOLUONGCONLAI"].ToString();
                int SoDem = Convert.ToInt32(dttable.Rows[0]["TG"].ToString()) - 1;
                lblTGnho.Text = lblSoNgay.Text + " " + SoDem + " đêm";
                lblPT.Text = dttable.Rows[0]["TENPT"].ToString();
                lblDiemDen.Text = dttable.Rows[0]["TENDDEN"].ToString();
                lblKS.Text = dttable.Rows[0]["TENLKS"].ToString();
                lblMaTour.Text = dttable.Rows[0]["MATOUR"].ToString();
            }
        }

        private void cmbLoaiTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiTour.Text == "Tour trong nước")
            {
                cmbDDen.ValueMember = "MaDDen";
                cmbDDen.DisplayMember = "TenDDen";
                cmbDDen.DataSource = bllDiemDen.GetAllDDLTrongNc();
            }
            if (cmbLoaiTour.Text == "Tour ngoài nước")
            {
                cmbDDen.ValueMember = "MaDDen";
                cmbDDen.DisplayMember = "TenDDen";
                cmbDDen.DataSource = bllDiemDen.GetAllDDLNgoaiNc();
            }
        }

        private void cmbSortLT_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaLTour = cmbSortLT.SelectedValue.ToString();
            dgvTour.DataSource = bllTour.GetLocTour(Tour);
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                txtTimKiem.Text = "Tìm Tour ...";
                txtTimKiem.ForeColor = Color.Silver;
            }
            if (txtTimKiem.Text == "Tìm Tour ...")
                ShowAllTour();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.ForeColor = Color.Black;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ResetInf();
                ResetBox();
                CloseBox();
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTroVe.Enabled = false;
            }
        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            tbl_Tour Tour = new tbl_Tour();
            Tour.MaTour = txtTimKiem.Text;
            Tour.TenTour = txtTimKiem.Text;
            dgvTour.DataSource = bllTour.SearchTour(Tour);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            OpenBox();
            txtMaTour.ReadOnly = true;
            checkThemSua = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTour.Text == "")
            {
                MessageBox.Show("Chưa chọn Tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tbl_Tour Tour = new tbl_Tour();
                    Tour.MaTour = txtMaTour.Text;

                    if (bllTour.DeleteTour(Tour))
                    {
                        ResetInf();
                        ResetBox();
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowAllTour();
                    }

                    else
                        MessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
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

        private void loadcmb()
        {
            cmbLoaiTour.ValueMember = "MaLTour";
            cmbLoaiTour.DisplayMember = "TenLTour";
            cmbLoaiTour.DataSource = bllLoaiTour.GetAllLTour();

            cmbPT.ValueMember = "MaPT";
            cmbPT.DisplayMember = "TenPT";
            cmbPT.DataSource = bllPhuongTien.GetAllPhuongTien();

            cmbDiemDi.ValueMember = "MaDDi";
            cmbDiemDi.DisplayMember = "TenDDi";
            cmbDiemDi.DataSource = bllDiemDi.GetAllDDiTrongNc();

            cmbDDen.ValueMember = "MaDDen";
            cmbDDen.DisplayMember = "TenDDen";
            cmbDDen.DataSource = bllDiemDen.GetAllDDLTrongNc();

            cmbKS.ValueMember = "MaLKS";
            cmbKS.DisplayMember = "TenLKS";
            cmbKS.DataSource = bllLKS.GetAllLoaiKhachSan();

            cmbSortLT.ValueMember = "MaLTour";
            cmbSortLT.DisplayMember = "TenLTour";
            cmbSortLT.DataSource = bllLoaiTour.GetAllLTour();
        }
    }
}
