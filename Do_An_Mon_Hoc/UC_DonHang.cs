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
    public partial class UC_DonHang : UserControl
    {
        DTO.DONHANG kh = new DTO.DONHANG();
        BLL.DonHangBLL bll = new BLL.DonHangBLL();
        public string maHD;
        public UC_DonHang()
        {
            InitializeComponent();
            
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            LoadData();
        }
        private void LoadData()
        {
            dataGridView2.DataSource = BLL.DonHangBLL.Instance.GetList();
            cbB_TenNV.DataSource = BLL.EmployeeInfoBLL.Instance.layDsTenNv();

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_xemchitiet_Click(object sender, EventArgs e)
        {
        }
        private void txt_maKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btn_timkiemdh_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView2.SelectedCells[0].RowIndex;
            maHD = dataGridView2.Rows[rowindex].Cells["MaHD"].Value.ToString();
            loadDataCTHD(maHD);
        }

        void loadDataCTHD(string maHD)
        {
            dataGridView1.DataSource = BLL.ChiTietHoaDonBLL.Instance.layChiTietHD(maHD);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count != 0)
            {
                Trang_InHoaDon inHoaDon = new Trang_InHoaDon(maHD);
                inHoaDon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trước khi in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime a = dateTimePicker1.Value;
            DateTime b = dateTimePicker2.Value;
            string tenNV = cbB_TenNV.SelectedItem.ToString();

            List<DONHANG> list;

            if (tenNV == "None")
            { 
                list = DonHangBLL.Instance.locDonHangKhongNV(a,b);
            }
            else
            {
                list = DonHangBLL.Instance.locDonHang(a, b, tenNV);
            }

            dataGridView2.DataSource = list;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
