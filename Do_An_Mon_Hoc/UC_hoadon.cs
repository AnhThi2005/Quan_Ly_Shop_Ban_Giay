using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.BLL;

namespace Do_An_Mon_Hoc
{
    public partial class UC_hoadon: UserControl
    {
        DTO.HOADON hd = new DTO.HOADON();
        BLL.HOADONBLL bll = new BLL.HOADONBLL();
        public UC_hoadon()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = bll.GetList();
            dataGridView1.Refresh();

        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string searchma = txt_thongtintimkiem.Text;
            dataGridView1.DataSource = bll.searchHD(searchma);
        }

        private void btn_themHD_Click(object sender, EventArgs e)
        {

            HOADONBLL hOADONBLL = new HOADONBLL();
            //hd.Tenkh = txt_tenkh.Text;
            hd.MaHD = txt_mahd.Text;
            //hd.Masp = txt_masanpham.Text;
            hd.NgaylapHD = dateTimePicker1.Value;
            hd.Tongtien = double.Parse(txt_tongtien.Text);
            int result = bll.themHD(hd);
            // Cập nhật loại sản phẩm trong cơ sở dữ liệu
            if (result > 0)
            {
                MessageBox.Show("Thêm thành công");
                //dataGridView1.DataSource = bll.loadhd();
                LoadData();


            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btn_xoahd_Click(object sender, EventArgs e)
        {
            string mahd = txt_mahd.Text;

            int result = bll.xoaHD(mahd);
            // Cập nhật loại sản phẩm trong cơ sở dữ liệu
            if (result > 0)
            {
                MessageBox.Show("Xóa thành công");
                LoadData();
                txt_makh.Text = "";
                txt_mahd.Text = "";
                dateTimePicker1.Text = "";
                txt_tongtien.Text = "";
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btn_capnhatHD_Click(object sender, EventArgs e)
        {
            HOADONBLL hOADONBLL = new HOADONBLL();


            hd.MaHD = txt_mahd.Text;
            hd.NgaylapHD = dateTimePicker1.Value;
            hd.Tongtien = double.Parse(txt_tongtien.Text);

            int result = bll.suaHD(hd);

            // Cập nhật loại sản phẩm trong cơ sở dữ liệu
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công");
                //dataGridView1.DataSource = bll.loadhd();
                LoadData();

            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btn_xemCTHD_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2; // Chuyển sang tab thứ hai
            txt_kh.Text = dataGridView1.CurrentRow.Cells["TenKH"].Value.ToString();
            txt_mahoadon.Text = dataGridView1.CurrentRow.Cells["mahd"].Value.ToString();
            txt_makh2.Text = dataGridView1.CurrentRow.Cells["MAKH"].Value.ToString();
            txt_tt.Text = dataGridView1.CurrentRow.Cells["tongtien"].Value.ToString();
            dtnglap.Text = dataGridView1.CurrentRow.Cells["ngaylaphd"].Value.ToString();
            txt_SL.Text = dataGridView1.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txt_masp.Text = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            txt_gia.Text = dataGridView1.CurrentRow.Cells["TenSP"].Value.ToString();
            txt_tensp.Text = dataGridView1.CurrentRow.Cells["TenSP"].Value.ToString();
            txt_chatlieu.Text = dataGridView1.CurrentRow.Cells["Gia"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1; // Chuyển sang tab đầu tiên
            txt_mahd.Text = "";
            txt_makh2.Text = "";
            txt_kh.Text = "";
            txt_tt.Text = "";
            dtnglap.Text = "";
            txt_SL.Text = "";
            txt_masp.Text = "";
            txt_gia.Text = "";
            txt_tensp.Text = "";
            txt_chatlieu.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.SelectedCells[0].RowIndex;
            txt_makh.Text = dataGridView1.Rows[rowindex].Cells["MaKH"].Value.ToString();
            txt_mahd.Text = dataGridView1.Rows[rowindex].Cells["MaHD"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[rowindex].Cells["NgayLapHD"].Value.ToString();
            txt_tongtien.Text = dataGridView1.Rows[rowindex].Cells["tongtien"].Value.ToString();
        }
    }
}
