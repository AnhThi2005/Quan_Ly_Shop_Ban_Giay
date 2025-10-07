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
    public partial class UC_DoanhThu : UserControl
    {
        public UC_DoanhThu()
        {
            InitializeComponent();
            datetime_ngaybd.MaxDate = DateTime.Now;
            datetime_ngaykt.MaxDate = DateTime.Now;
        }
        DTO.DoanhThu dt = new DTO.DoanhThu();
        private void UC_DoanhThu_Load(object sender, EventArgs e)
        {
            List<DoanhThu> list = new List<DoanhThu>();
            list = DoanhThuBLL.Instance.hienthiDoanhthu();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Do_An_Mon_Hoc.Report2.rdlc";  // đường dẫn đúng

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DoanhThu", list));

            this.reportViewer1.RefreshReport();
            label_tongdoanhthu.Text = DoanhThuBLL.Instance.hienthiTongdoanhthu(dt.Doanhthu).ToString();
            label_tienmat.Text = DoanhThuBLL.Instance.hienthiTongdoanhthuTM(dt.Doanhthu).ToString();
            label_chuyenkhoan.Text = DoanhThuBLL.Instance.hienthiTongdoanhthuCK(dt.Doanhthu).ToString();
            label_trasau.Text = DoanhThuBLL.Instance.hienthiTongdoanhthuTS(dt.Doanhthu).ToString();
            label_vi.Text = DoanhThuBLL.Instance.hienthiTongdoanhthuVi(dt.Doanhthu).ToString();
            label_the.Text = DoanhThuBLL.Instance.hienthiTongdoanhthuThe(dt.Doanhthu).ToString();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label_tongdoanhthu_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_xemchitiet_Click(object sender, EventArgs e)
        {
            if (datetime_ngaybd.Value < datetime_ngaykt.Value)
            {
                DoanhThuTheoNgay doanhThu = new DoanhThuTheoNgay(datetime_ngaybd.Value, datetime_ngaykt.Value);
                doanhThu.Show();
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc");
            }    
        }

        private void label_chuyenkhoan_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trang_BieuDoBaoCao form1 = new Trang_BieuDoBaoCao();
            form1.ShowDialog();

        }
    }
}
