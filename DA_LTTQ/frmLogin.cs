using System;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmLogin : Form
    {
        User_BLL bllUser;
        public frmLogin()
        {
            InitializeComponent();
            bllUser = new User_BLL();
        }

        void CheckBox()
        {
            tbl_User User = new tbl_User();
            User.UserName = txtTenDN.Text;
            User.Password = txtMK.Text;
            //string quyen = "";
            if (bllUser.PhQuyen(User) == "Admin")
            {
                frmMainn MainFrm = new frmMainn();
                MainFrm.lblXinChao.Text = "Xin chào: " + txtTenDN.Text;
                MainFrm.Show();
                this.Hide();
            }

            if (bllUser.PhQuyen(User) == "User")
            {
                frmMainn Main = new frmMainn();
                Main.btnQLTT.Enabled = false;
                Main.Show();
                this.Hide();
            }

            if (bllUser.PhQuyen(User) == "Fail")
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
            {
                txtMK.PasswordChar = '\0';
            }

            else
                txtMK.PasswordChar = '\u25CF';
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CheckBox();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '\u25CF';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
