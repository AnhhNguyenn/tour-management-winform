using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmKhachHang : Form
    {
        KhachHang_BLL bllKH;
        public frmKhachHang()
        {
            InitializeComponent();
            bllKH = new KhachHang_BLL();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void ShowAllKH()
        {
            DataTable dataTable = bllKH.GetAllKH();
            dgvKH.DataSource = dataTable;
        }

        string notice = "";
        private bool checkData()
        {
            string notice = "";

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                notice += "Chưa nhập số điện thoại\n";
                txtSDT.Focus();
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                notice += "Chưa nhập địa chỉ\n";
                txtDiaChi.Focus();
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                notice += "Chưa nhập Email\n";
                txtEmail.Focus();
            }

            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtEmail.Text, pattern) == false)
            {
                notice += "Nhập sai định dạng Email\n";
                txtEmail.Focus();
            }

            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                notice += "Chưa nhập tên\n";
                txtTenKH.Focus();
            }

            if ((string.IsNullOrEmpty(txtSDT.Text)) || (string.IsNullOrEmpty(txtDiaChi.Text)) || (string.IsNullOrEmpty(txtEmail.Text)) || (Regex.IsMatch(txtEmail.Text, pattern) == false) || (string.IsNullOrEmpty(txtTenKH.Text)))
            {
                MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                tbl_KhachHang KhachHang = new tbl_KhachHang();
                KhachHang.MaKH = txtMaKH.Text;
                KhachHang.TenKH = txtTenKH.Text;
                KhachHang.SDT = txtSDT.Text;
                KhachHang.DiaChi = txtDiaChi.Text;
                KhachHang.Email = txtEmail.Text;

                if (bllKH.UpdateKhachHang(KhachHang))
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllKH();
                }

                else
                {
                    MessageBox.Show("Lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMaKH.Focus();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tbl_KhachHang KhachHang = new tbl_KhachHang();
                KhachHang.MaKH = dgvKH.SelectedRows[0].Cells[0].Value.ToString();

                if (bllKH.DeleteKhachHang(KhachHang))
                {
                    btnXoa.Enabled = false;
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllKH();
                }

                else
                    MessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ShowAllKH();
            btnXoa.Visible = false;
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                btnXoa.Enabled = true;
                txtMaKH.Text = dgvKH.Rows[index].Cells[0].Value.ToString();
                txtTenKH.Text = dgvKH.Rows[index].Cells[1].Value.ToString();
                txtSDT.Text = dgvKH.Rows[index].Cells[2].Value.ToString();
                txtEmail.Text = dgvKH.Rows[index].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvKH.Rows[index].Cells[4].Value.ToString();
            }
            txtMaKH.Enabled = false;
        }
    }
}
