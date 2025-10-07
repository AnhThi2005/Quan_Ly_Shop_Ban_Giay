using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.BLL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc
{
    public partial class UC_NhanVien : UserControl
    {
        private EmployeeInfoBLL NhanVien = new EmployeeInfoBLL();

        DTO.NHANVIEN nv = new DTO.NHANVIEN();

        string fixPath = Path.Combine(Application.StartupPath, "Images");

        public event EventHandler NhanVienDaCapNhat;

        public event EventHandler NhanVienDaXoa;

        private int id;
        public UC_NhanVien()
        {
            InitializeComponent();
            loadData();
            dTP_ngSinh.MaxDate = DateTime.Now;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void informationStaff(int id)
        {
            nv = NhanVien.hienThiThongTin(id);
            txt_tentk.Text = nv.TenTK;
            txt_hoten.Text = nv.HoTen;
            txt_sdt.Text = nv.Sdt;
            dTP_ngSinh.Value = nv.NgSinh;
            nmr_luong.Value = Convert.ToDecimal(nv.Luong);
            txt_email.Text = nv.Email;
            txt_diachi.Text = nv.DiaChi;

            // Loai tai khoan
            if (nv.LoaiTaiKhoan == 0)
            {
                cb_loaiTK.Text = cb_loaiTK.Items[0].ToString();
            }
            else
            {
                cb_loaiTK.Text = cb_loaiTK.Items[1].ToString();

            }

            // Gioi tinh
            if (nv.GioiTinh == "Nam")
            {
                rdo_nam.Checked = true;
            }
            else
            {
                ado_nu.Checked = true;
            }

            //Trang thai
            if (nv.TrangThai == 1)
            {
                cb_trangThai.Checked = true;
            }
            else
            {
                cb_trangThai.Checked = false;
            }

            if (nv.Anh != "")
                pictureBox1.Image = Image.FromFile(fixPath + "\\" + nv.Anh);
            else
            {
                pictureBox1.Image = null;
                return;
            }
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string thongTin = txt_nhapthongtin.Text;
            if (thongTin == "" || cb_timtheo.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Hãy nhập đủ tiêu chí và thông tin tìm kiếm!");
                return;
            }
            else
            {
                // Tìm theo Họ tên ,Giới tính, Địa chỉ ,Email

                if (cb_timtheo.Text == "Họ tên")
                {
                    nv.HoTen = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiTimKiemTheoHoTen(thongTin);

                }
                else if (cb_timtheo.Text == "Giới tính")
                {
                    nv.GioiTinh = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoGioiTinh(thongTin);
                }
                else if (cb_timtheo.Text == "Địa chỉ")
                {
                    nv.DiaChi = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoDiaChi(thongTin);
                }
                else if (cb_timtheo.Text == "Email")
                {
                    nv.DiaChi = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoEmail(thongTin);
                }
                else if (cb_timtheo.Text == "Tên tài khoản")
                {
                    nv.DiaChi = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoTenTaiKhoan(thongTin);
                }
                else
                {
                    MessageBox.Show("Không có tiêu chí tìm kiếm này");
                    return;
                }
            }
        }

        private void txt_nhapthongtin_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_timtheo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grb_thongtinnhanvien_Enter(object sender, EventArgs e)
        {

        }

        private void panel_chucnang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_capnhatnhanvien_Click(object sender, EventArgs e)
        {
            int result;
            nv.Id = id;
            nv.HoTen = txt_hoten.Text;
            nv.NgSinh = dTP_ngSinh.Value;
            nv.Sdt = txt_sdt.Text;
            nv.DiaChi = txt_diachi.Text;
            nv.Email = txt_email.Text;
            nv.Luong = nmr_luong.Value;
            // Cap nhat anh
            string imageName;
            if (pictureBox1.Tag == null)
            {
                imageName = dataGridView1.CurrentRow.Cells["ANH"].Value.ToString();
            }
            else
            {
                imageName = pictureBox1.Tag.ToString();
            }
            nv.Anh = imageName;

            // Cap nhat mat khau moi
            if (txt_matKhauMoi.Text  == nv.MatKhau)
            {
                MessageBox.Show("Mật khẩu mới nhập bị trùng");
            }
            else if(txt_matKhauMoi.Text != "" && txt_matkhau.Text == nv.MatKhau)
            {
                nv.MatKhau = txt_matKhauMoi.Text;
            }

            // Cập nhật giới tính
            if (rdo_nam.Checked == true)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }

            //Cập nhật loại tài khoản
            if (cb_loaiTK.SelectedIndex == 0)
            {
                nv.LoaiTaiKhoan = 0;
            }
            else if (cb_loaiTK.SelectedIndex == 1)
            {
                nv.LoaiTaiKhoan = 1;
            }
            else
            {
                nv.LoaiTaiKhoan = -1;
            }
            //Cập nhật trạng thái tài khoản ( 1: còn hoạt động,  0: đã nghỉ làm  )
            if (cb_trangThai.Checked == true)
            {
                nv.TrangThai = 1;
            }
            else
            {
                nv.TrangThai = 0;
            }
            result = NhanVien.capNhatThongTinNhanVien(nv);

            if (result == 0)
                MessageBox.Show("Bạn đã cập nhật thất bại");
            else
            {
                MessageBox.Show("Bạn đã cập nhật thành công");
                // load lại ảnh để khi thao tác tiếp theo không sử dụng lại 
                pictureBox1.Image = null;
                loadData();
            }
            NhanVienDaCapNhat?.Invoke(this, EventArgs.Empty);
        }

        private void btn_xoanhanvien_Click(object sender, EventArgs e)
        {
            DTO.NHANVIEN nvXoa = DAL.NhanVienDAL.Instance.layThongTinNhanVienBangId(id);
            //if (nvXoa.TrangThai == 0)
            //{
            //    MessageBox.Show("Nhân viên đang hoạt động" + nv.TrangThai);


            //}
            //else /*(nvXoa.TrangThai==0)*/
            //{
            int result;
            result = NhanVien.xoaNhanVien(id);
            if (result == 0)
                MessageBox.Show("Bạn đã xóa thất bại");
            else
            {
                MessageBox.Show("Bạn đã xóa thành công");
                loadData();
            }
            NhanVienDaXoa?.Invoke(this, EventArgs.Empty);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txt_diachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_hoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tentk_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void grb_thongtintk_Enter(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cb_chucvu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txt_matkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Chon anh";

            ofd.Filter = "Hinh anh|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);

                string sourcePath = Path.Combine(Application.StartupPath, "Images");

                if (!Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(sourcePath);
                }

                Console.WriteLine(ofd.FileName);

                string imageName = Path.GetFileName(ofd.FileName);

                Console.WriteLine(imageName);

                string destPath = Path.Combine(sourcePath, imageName);

                if (!File.Exists(destPath))
                {
                    File.Copy(ofd.FileName, destPath, true);
                }
                pictureBox1.Tag = imageName;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DTO.NHANVIEN nv = new DTO.NHANVIEN();
            BLL.EmployeeInfoBLL info = new BLL.EmployeeInfoBLL();

            //Đảm bảo không click vào tiêu đề
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                id = int.Parse(row.Cells["id"].Value.ToString());
                txt_matKhauMoi.Text = "";
                informationStaff(id);
            }
        }
        public void loadData()
        {
            dataGridView1.DataSource = NhanVien.hienThiDSNhanVien();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            string thongTin = txt_nhapthongtin.Text;
            if (thongTin == "" || cb_timtheo.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Hãy nhập đủ tiêu chí và thông tin tìm kiếm!");
                return;
            }
            else
            {
                // Tìm theo Họ tên ,Giới tính, Địa chỉ ,Email

                if (cb_timtheo.Text == "Họ tên")
                {
                    nv.HoTen = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiTimKiemTheoHoTen(thongTin);

                }
                else if (cb_timtheo.Text == "Giới tính")
                {
                    nv.GioiTinh = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoGioiTinh(thongTin);
                }
                else if (cb_timtheo.Text == "Địa chỉ")
                {
                    nv.DiaChi = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoDiaChi(thongTin);
                }
                else if (cb_timtheo.Text == "Email")
                {
                    nv.DiaChi = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoEmail(thongTin);
                }
                else if (cb_timtheo.Text == "Tên tài khoản")
                {
                    nv.DiaChi = thongTin;
                    dataGridView1.DataSource = NhanVien.hienThiDsTimKiemTheoTenTaiKhoan(thongTin);
                }
                else
                {
                    MessageBox.Show("Không có tiêu chí tìm kiếm này");
                    return;
                }
            }
        }
    }
}
