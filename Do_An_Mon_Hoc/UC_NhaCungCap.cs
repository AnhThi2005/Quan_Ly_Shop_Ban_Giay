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
using Do_An_Mon_Hoc.DAL;
using Do_An_Mon_Hoc.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Do_An_Mon_Hoc
{
    public partial class UC_NhaCungCap : UserControl
    {

        private string mancc;
        private NhaCungCapBLL NhaCungCap = new NhaCungCapBLL();
        DTO.NHACUNGCAP ncc = new DTO.NHACUNGCAP();
        public UC_NhaCungCap()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = NhaCungCapDAL.Instance.layDanhSachNCC();
            cbB_tenNCC.DataSource = BLL.NhaCungCapBLL.Instance.layDsTenNCC();
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (txt_tenNCC.Text == "" || txt_diaChi.Text == "" || txt_SDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                ncc.TenNcc = txt_tenNCC.Text;
                ncc.DiaChi = txt_diaChi.Text;
                ncc.Sdt = txt_SDT.Text;
                result = NhaCungCap.themNCC(ncc);
                if (result != 0)
                {
                    MessageBox.Show("thành công");

                }
                else
                {
                    MessageBox.Show("fail");
                }
                LoadData();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (mancc == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp muốn xóa");
            }
            else
            {
                ncc.MaNcc = mancc;
                result = NhaCungCap.xoaNcc(ncc);
                if (result == 0)
                    MessageBox.Show("fail");
                else
                    MessageBox.Show("thanh cong");
                LoadData();
            }
        }

        private void btn_capNhat_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (mancc == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp muốn xóa");
            }
            else if (txt_tenNCC.Text == "" || txt_diaChi.Text == "" || txt_SDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                ncc.TenNcc = txt_tenNCC.Text;
                ncc.DiaChi = txt_diaChi.Text;
                ncc.Sdt = txt_SDT.Text;
                ncc.MaNcc = mancc;
                result = NhaCungCap.capnhatNcc(ncc);
                if (result != 0)
                {
                    MessageBox.Show("thành công");

                }
                else
                {
                    MessageBox.Show("fail");
                }
                LoadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                mancc = row.Cells["MaNcc"].Value.ToString();
                hienthincc(mancc);
            }
        }

        private void hienthincc(string maNcc)
        {
            ncc = NhaCungCap.hienthithongtinncc(maNcc);
            txt_maNCC.Text = ncc.MaNcc;
            txt_tenNCC.Text = ncc.TenNcc;
            txt_SDT.Text = ncc.Sdt;
            txt_diaChi.Text = ncc.DiaChi;
            txt_trangThai.Text = "Hoạt động";
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string tenncc = txt_nhapthongtin.Text;
            ncc.TenNcc = tenncc;
            dataGridView1.DataSource = NhaCungCap.hienthidssearch(tenncc);
        }

        private void btn_taiLai_Click(object sender, EventArgs e)
        {
            LoadData();
            txt_maNCC.Text = "";
            txt_tenNCC.Text = "";
            txt_SDT.Text = "";
            txt_diaChi.Text = "";
            txt_trangThai.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenNCC = cbB_tenNCC.SelectedItem.ToString();

            LoadSanPhamTheoNCC(tenNCC);
        }

        private void LoadSanPhamTheoNCC(string tenNCC)
        {
            listView1.Clear(); // Xóa cũ nếu có

            listView1.View = View.Details;
            listView1.Columns.Add("Mã SP", 70);
            listView1.Columns.Add("Tên SP", 150);
            listView1.FullRowSelect = true;

            string maNCC = NhaCungCapBLL.Instance.layMNCCTuTen(tenNCC);
            List<SANPHAM> list = NhaCungCapBLL.Instance.danhSachSanPhamNCCCap(maNCC);

            foreach (SANPHAM sp in list)
            {
                ListViewItem item = new ListViewItem(sp.MaSP);
                item.SubItems.Add(sp.TenSP);
                listView1.Items.Add(item);
            }
        }

    }
}
