using System;
using System.Drawing;
using System.Windows.Forms;

namespace DA_LTTQ
{
    public partial class frmMainn : Form
    {
        public frmMainn()
        {
            InitializeComponent();
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

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTrangChu());
        }

        private void btnTour_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1192, 785);
            openChildForm(new frmDatTour());

            btnTour.FillColor = Color.FromArgb(255, 196, 54);
            btnTour.FillColor2 = Color.FromArgb(255, 196, 54);
            btnTour.ForeColor = Color.White;

            btnTrangChu.FillColor = Color.FromArgb(1, 116, 190);
            btnTrangChu.FillColor2 = Color.FromArgb(1, 116, 190);
            btnTrangChu.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(1, 116, 190);
            btnQLTT.FillColor2 = Color.FromArgb(1, 116, 190);
            btnQLTT.ForeColor = Color.White;

            btnTrangChu.FillColor = Color.FromArgb(1, 116, 190);
            btnTrangChu.FillColor2 = Color.FromArgb(1, 116, 190);
            btnTrangChu.ForeColor = Color.White;

            btnHoaDon.FillColor = Color.FromArgb(1, 116, 190);
            btnHoaDon.FillColor2 = Color.FromArgb(1, 116, 190);
            btnHoaDon.ForeColor = Color.White;
        }

        private void btnQLTT_Click(object sender, EventArgs e)
        {
            panelChildForm.Size = new Size(1192, 785);
            this.Size = new Size(1218, 933);

            this.Hide();
            frmQLThongTin QLTT = new frmQLThongTin();

            QLTT.ShowDialog();
        }

        private void frmMainn_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1192, 785);

            btnTrangChu.FillColor = Color.FromArgb(255, 196, 54);
            btnTrangChu.FillColor2 = Color.FromArgb(255, 196, 54);
            btnTrangChu.ForeColor = Color.White;

            btnTour.FillColor = Color.FromArgb(1, 116, 190);
            btnTour.FillColor2 = Color.FromArgb(1, 116, 190);
            btnTour.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(1, 116, 190);
            btnQLTT.FillColor2 = Color.FromArgb(1, 116, 190);
            btnQLTT.ForeColor = Color.White;

            btnHoaDon.FillColor = Color.FromArgb(1, 116, 190);
            btnHoaDon.FillColor2 = Color.FromArgb(1, 116, 190);
            btnHoaDon.ForeColor = Color.White;
            openChildForm(new frmHome());
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin LoginFrm = new frmLogin();
            LoginFrm.Show();
        }

        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {
            this.Size = new Size(1218, 933);
            panelChildForm.Size = new Size(1192, 785);

            btnTrangChu.FillColor = Color.FromArgb(255, 196, 54);
            btnTrangChu.FillColor2 = Color.FromArgb(255, 196, 54);
            btnTrangChu.ForeColor = Color.White;

            btnTour.FillColor = Color.FromArgb(1, 116, 190);
            btnTour.FillColor2 = Color.FromArgb(1, 116, 190);
            btnTour.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(1, 116, 190);
            btnQLTT.FillColor2 = Color.FromArgb(1, 116, 190);
            btnQLTT.ForeColor = Color.White;

            btnHoaDon.FillColor = Color.FromArgb(1, 116, 190);
            btnHoaDon.FillColor2 = Color.FromArgb(1, 116, 190);
            btnHoaDon.ForeColor = Color.White;
            openChildForm(new frmHome());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            panelChildForm.Size = new Size(1192, 552);
            this.Size = new Size(1218, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            btnHoaDon.FillColor = Color.FromArgb(255, 196, 54);
            btnHoaDon.FillColor2 = Color.FromArgb(255, 196, 54);
            btnHoaDon.ForeColor = Color.White;

            btnTour.FillColor = Color.FromArgb(1, 116, 190);
            btnTour.FillColor2 = Color.FromArgb(1, 116, 190);
            btnTour.ForeColor = Color.White;

            btnQLTT.FillColor = Color.FromArgb(1, 116, 190);
            btnQLTT.FillColor2 = Color.FromArgb(1, 116, 190);
            btnQLTT.ForeColor = Color.White;

            btnTrangChu.FillColor = Color.FromArgb(1, 116, 190);
            btnTrangChu.FillColor2 = Color.FromArgb(1, 116, 190);
            btnTrangChu.ForeColor = Color.White;
            openChildForm(new frmHoaDon());
        }


        //private void btnKhachHang_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new frmKhachHang());
        //    //frmKhachHang KhachHang = new frmKhachHang();
        //    //KhachHang.ShowDialog();
        //}

        //private void btnThongTin_Click(object sender, EventArgs e)
        //{
        //    //if(pnlSubMenuThongTin.Visible == true)
        //    //    pnlSubMenuThongTin.Visible = false;
        //    //else
        //    //    pnlSubMenuThongTin.Visible = true;
        //}

        //private void btnQLTT_Click(object sender, EventArgs e)
        //{


        //}
    }
}
