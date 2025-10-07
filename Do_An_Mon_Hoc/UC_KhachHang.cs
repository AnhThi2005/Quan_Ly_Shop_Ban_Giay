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

namespace Do_An_Mon_Hoc
{
    public partial class UC_KhachHang : UserControl
    {
        DTO.KHACHHANG kh = new DTO.KHACHHANG();
        BLL.KhachHangBLL bll = new BLL.KhachHangBLL();
        public UC_KhachHang()
        {
            InitializeComponent();
            LoadData();

        }
        private void LoadData()
        {
            dataGridView1.DataSource = bll.GetList();
        }

        private void btn_capnhatkhachhang_Click(object sender, EventArgs e)
        {
            KhachHangBLL kHACHHANGBLL = new KhachHangBLL();
            // Lấy ID của loại sản phẩm từ dòng được chọn
            //int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            // Cập nhật thông tin loại sản phẩm
            kh.MaKH = txt_makh.Text;
            kh.Sdt = txt_sdtkh.Text;
            kh.TenKH = txt_tenkh.Text;
            kh.Email = txt_emailkh.Text;
            kh.DiaChi = txt_diachikh.Text;
            kh.TenTK = txt_tentkkh.Text;
            kh.MatKhau = txt_matkhaukh.Text;
            int result = bll.suaKhachHang(kh);

            // Cập nhật loại sản phẩm trong cơ sở dữ liệu
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txt_makh.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_tenkh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_sdtkh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_emailkh.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txt_diachikh.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txt_tentkkh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_matkhaukh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string searchma = txt_nhapthongtin.Text;
            string searchten = txt_nhapthongtin.Text;

            dataGridView1.DataSource = bll.SearchKhachHang(searchma, searchten);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
            txt_makh.Text = "";
            txt_tenkh.Text = "";
            txt_sdtkh.Text = "";
            txt_emailkh.Text = "";
            txt_diachikh.Text = ""  ;
            txt_tentkkh.Text = "";
            txt_matkhaukh.Text = "";
        }
    }
}
