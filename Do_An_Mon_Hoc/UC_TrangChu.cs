using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.BLL;
using System.Windows.Forms.DataVisualization.Charting;

namespace Do_An_Mon_Hoc
{
    public partial class UC_TrangChu : UserControl
    {
         BLL.DoanhThuChartBLL doanhthuBLL = new DoanhThuChartBLL();
        public UC_TrangChu()
        {
            InitializeComponent();
            LoadChart();

        }

        private void LoadChart()
        {
            int nam = DateTime.Now.Year;
            List<DTO.DOANHTHU> ds = doanhthuBLL.doanhThuThang(nam);

            chart1.Series.Clear();
            var series = chart1.Series.Add("Doanh thu");
            series.ChartType = SeriesChartType.Doughnut;

            foreach (var item in ds)
            {
                series.Points.AddXY(item.Thang, item.TongDoanhThu);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_TrangChu_Load(object sender, EventArgs e)
        {
            LoadChart();

            int nam = DateTime.Now.Year;
            int thang = DateTime.Now.Month;
            //int nam = 2025;
            //int thang = 3;
            lbl_tongSanPham.Text = doanhthuBLL.tongSLSanPhamDaBan(nam, thang).ToString();
            lbl_tongDoanhThu.Text = doanhthuBLL.tongDoanhThuThang(nam, thang).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
