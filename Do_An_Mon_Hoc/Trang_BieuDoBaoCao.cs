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
    public partial class Trang_BieuDoBaoCao : Form
    {
       
        public Trang_BieuDoBaoCao()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DoanhThu> list = new List<DoanhThu>();
            list = DoanhThuBLL.Instance.hienthiDoanhthu();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Do_An_Mon_Hoc.BieuDo.rdlc";  // đường dẫn đúng
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", list));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
