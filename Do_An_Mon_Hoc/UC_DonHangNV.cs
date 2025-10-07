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
using Microsoft.Reporting.WinForms;

namespace Do_An_Mon_Hoc
{
    public partial class UC_DonHangNV : UserControl
    {
        DTO.DONHANG kh = new DTO.DONHANG();
        BLL.DonHangNVBLL bll = new BLL.DonHangNVBLL();
        public UC_DonHangNV()
        {
            InitializeComponent();
            LoadData();

        }
        private void LoadData()
        {
            dataGridView2.DataSource = BLL.DonHangNVBLL.Instance.GetList();
        }
        private void btn_xemchitiet_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;


            string maHoaDon = txt_maHD.Text.Trim(); // Lấy từ textbox hoặc DataGridView

            // Gọi đến lớp BLL để lấy danh sách chi tiết hóa đơn
            List<DTO.DONHANG> ds = DonHangNVBLL.Instance.dstheomHD(maHoaDon);

            // Hiển thị report
            HienThiReport(ds);
        }

        private void btn_timkiemdh_Click(object sender, EventArgs e)
        {
            string searchma = textBox7.Text;
            string searchten = textBox7.Text;

            dataGridView2.DataSource = bll.SearchKhachHang(searchma, searchten);
        }
        public void HienThiReport(List<DTO.DONHANG> ds)
        {
            reportViewer1.LocalReport.ReportPath = "DonHangNV.rdlc";  // đường dẫn đúng
            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rds = new ReportDataSource("DataSet1", ds);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView2.SelectedCells[0].RowIndex;
            txt_maKH.Text = dataGridView2.Rows[rowindex].Cells["MaKH"].Value.ToString();
            txt_tenKH.Text = dataGridView2.Rows[rowindex].Cells["TenKH"].Value.ToString();
            txt_maHD.Text = dataGridView2.Rows[rowindex].Cells["MaHD"].Value.ToString();
            txt_sanPham.Text = dataGridView2.Rows[rowindex].Cells["MaSP"].Value.ToString();
            dTP_ngayLap.Text = dataGridView2.Rows[rowindex].Cells["NgayLap"].Value.ToString();// nhìn tên cột trong dataGridView
            txt_thanhToan.Text = dataGridView2.Rows[rowindex].Cells["Phuongthuc"].Value.ToString();
            mnr_tongTien.Text = dataGridView2.Rows[rowindex].Cells["TongTien"].Value.ToString();
        }
    }
}
