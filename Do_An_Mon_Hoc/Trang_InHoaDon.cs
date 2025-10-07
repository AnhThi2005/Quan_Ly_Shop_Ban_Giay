using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DTO;
using Microsoft.Reporting.WinForms;

namespace Do_An_Mon_Hoc
{
    public partial class Trang_InHoaDon : Form
    {
        private string maHD;
        public Trang_InHoaDon()
        {
            InitializeComponent();
        }

        public Trang_InHoaDon(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }
        //public void HienThiReport(List<CHITIETHOADON> list)
        //{
        //    reportViewer1.LocalReport.ReportEmbeddedResource = "Do_An_Mon_Hoc.Report1.rdlc";  // đường dẫn đúng

        //    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CTHD", list));

        //    this.reportViewer1.RefreshReport();
        private void Trang_InHoaDon_Load(object sender, EventArgs e)
        {
            List<HDREPORT> list = new List<HDREPORT>();
            list = BLL.HdReportBLL.Instance.layChiTietHD(maHD);
            
            BLL.HdReportBLL.Instance.layChiTietHD(maHD);

            reportViewer1.LocalReport.ReportEmbeddedResource = "Do_An_Mon_Hoc.Report1.rdlc";  // đường dẫn đúng

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("HDREPORT", list));

            this.reportViewer1.RefreshReport();
        }
    }
}
