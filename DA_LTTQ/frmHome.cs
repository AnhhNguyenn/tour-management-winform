using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DA_LTTQ
{
    public partial class frmHome : Form
    {
        HoaDon_BLL bllhoadon;
        Tour_BLL bllTour;
        public frmHome()
        {
            InitializeComponent();
            bllhoadon = new HoaDon_BLL();
            bllTour = new Tour_BLL();
        }

        private void getDoanhThuNam()
        {
            chartRevenue.Series.Clear();
            chartRevenue.Series.Add("Doanh thu");
            tbl_HoaDon HoaDon = new tbl_HoaDon();
            HoaDon.Nam = Convert.ToInt32(cmbYear.Text);
            chartRevenue.DataSource = bllhoadon.ThongKe_DoanhThu_Nam(HoaDon);
            chartRevenue.ChartAreas[0].AxisX.Interval = 1;
            chartRevenue.ChartAreas[0].AxisY.Interval = 1500000;
            chartRevenue.Series[0].XValueMember = "Tháng";
            chartRevenue.Series[0].YValueMembers = "Thành tiền";
            chartRevenue.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;       
            chartRevenue.Series.Add("Doanh thu2");         
            chartRevenue.Series[1].XValueMember = "Tháng";
            chartRevenue.Series[1].YValueMembers = "Thành tiền";
            chartRevenue.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartRevenue.ChartAreas[0].AxisX.LineColor = Color.Gray;
            chartRevenue.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
            chartRevenue.Series[0].Palette = ChartColorPalette.Fire;
            chartRevenue.Series[1].Palette = ChartColorPalette.Fire;
            chartRevenue.Series[1].BorderWidth = 3;
            chartRevenue.ChartAreas[0].AxisY.LineColor = Color.Gray;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
        }

        private void GetTourBanChay()
        {
            DataTable dttb = bllTour.GetTourBanChay();
            lblMaTour.Text = dttb.Rows[0]["MATOUR"].ToString();
            lblTenTour.Text = dttb.Rows[0]["TENTOUR"].ToString();
            lblMoTa.Text = dttb.Rows[0]["MOTA"].ToString();
            lblGiaTour.Text = "Giá chỉ: " + string.Format("{0:#,##0}", decimal.Parse(dttb.Rows[0]["GIATOUR"].ToString())) + "đ";
            MemoryStream ms3 = new MemoryStream((byte[])(dttb.Rows[0]["ANH1"]));
            picHinh1.Image = Image.FromStream(ms3);
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            chartRevenue.Series.Clear();
            chartRevenue.Series.Add("Doanh thu");
            tbl_HoaDon HoaDon = new tbl_HoaDon();
            HoaDon.Nam = 2021;
            chartRevenue.DataSource = bllhoadon.ThongKe_DoanhThu_Nam(HoaDon);
            chartRevenue.ChartAreas[0].AxisX.Interval = 1;
            chartRevenue.ChartAreas[0].AxisY.Interval = 1500000;
            chartRevenue.Series[0].XValueMember = "Tháng";
            chartRevenue.Series[0].YValueMembers = "Thành tiền";
            chartRevenue.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chartRevenue.Series.Add("Doanh thu2");
            chartRevenue.Series[1].XValueMember = "Tháng";
            chartRevenue.Series[1].YValueMembers = "Thành tiền";
            chartRevenue.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartRevenue.ChartAreas[0].AxisX.LineColor = Color.Gray;
            chartRevenue.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
            chartRevenue.Series[0].Palette = ChartColorPalette.Fire;
            chartRevenue.Series[1].Palette = ChartColorPalette.Fire;
            chartRevenue.Series[1].BorderWidth = 3;
            chartRevenue.ChartAreas[0].AxisY.LineColor = Color.Gray;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;

            GetTourBanChay();
            cmbYear.Items.Add("-- Chọn năm --");
            cmbYear.SelectedIndex = 0;
            for (int a = 2015; a < 2026; a++)
            {
                cmbYear.Items.Add(a);
            }
            cmbYear.Text = 2021.ToString();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbYear.SelectedIndex != 0))
            {
                getDoanhThuNam();
            }
        }
    }
}
