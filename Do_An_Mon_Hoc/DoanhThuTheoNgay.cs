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
using Do_An_Mon_Hoc.DTO;
using Microsoft.Reporting.WinForms;

namespace Do_An_Mon_Hoc
{
    public partial class DoanhThuTheoNgay : Form
    {
        private DateTime ngaybd;
        private DateTime ngaykt;
        public DoanhThuTheoNgay()
        {
            InitializeComponent();
        }
        public DoanhThuTheoNgay(DateTime ngaybd, DateTime ngaykt)
        {
            InitializeComponent();
            this.ngaybd = ngaybd;
            this.ngaykt = ngaykt;
        }

        private void DoanhThuTheoNgay_Load(object sender, EventArgs e)
        {
            
            List<DoanhThuRP> list = new List<DoanhThuRP>();
            list = DoanhThuRPBLL.Instance.hienthiDoanhthu(ngaybd,ngaykt);
            reportViewer1.LocalReport.ReportEmbeddedResource = "Do_An_Mon_Hoc.DoanhThuTheoNgay.rdlc";  // đường dẫn đúng

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DoanhThuTheoNgay", list));
            this.reportViewer1.RefreshReport();
        }
    }
}
