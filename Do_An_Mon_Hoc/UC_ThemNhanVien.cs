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
    public partial class UC_ThemNhanVien : UserControl
    {
        public event EventHandler NhanVienDaThem;

        private EmployeeInfoBLL NhanVien = new EmployeeInfoBLL();
        DTO.NHANVIEN nv = new DTO.NHANVIEN();
        string fixPath = Path.Combine(Application.StartupPath, "Images");
        private int id;
        public UC_ThemNhanVien()
        {
            InitializeComponent();
            loadData();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            int result;
            if (cbB_loaitk.SelectedIndex == -1 || txt_tenTK.Text == "" || txt_hoTen.Text == "" || txt_matKhau.Text == "" || txt_sdt.Text == "" ||
                txt_diaChi.Text == "" || txt_email.Text == "" || pictureBox_anh.Tag == null)
            {
                MessageBox.Show("Hãy nhập đủ thông tin nhân viên");
            }
            else
            {
                nv.TenTK = txt_tenTK.Text;
                nv.MatKhau = txt_matKhau.Text;
                nv.HoTen = txt_hoTen.Text;
                nv.NgSinh = dTP_ngSinh.Value;
                // Mặc định khi thêm ngày vào làm là ngày được thêm
                nv.NgayVaoLam = DateTime.Now;
                nv.Sdt = txt_sdt.Text;
                nv.DiaChi = txt_diaChi.Text;
                nv.Email = txt_email.Text;
                nv.Luong = nmr_luong.Value;
                // Thêm ảnh
                string imageName;
                if (pictureBox_anh.Tag != null)
                {
                    if (NhanVien.timAnhTungLap(pictureBox_anh.Tag.ToString()) > 0)
                    {
                        MessageBox.Show("Ảnh nhân viên đã tồn tại!" + pictureBox_anh.Tag, "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //MessageBox.Show("Ảnh nhân viên đã tồn tại!");
                        return;
                    }
                    else
                    {
                        imageName = pictureBox_anh.Tag.ToString();

                    }
                    nv.Anh = imageName;
                }

                // Thêm giới tính
                if (rd_nam.Checked == true)
                {
                    nv.GioiTinh = "Nam";
                }
                else if (rd_nu.Checked == true)
                {
                    nv.GioiTinh = "Nữ";
                }
                else
                {
                    nv.GioiTinh = "";
                }

                //Thêm loại tài khoản
                if (cbB_loaitk.SelectedIndex == 0)
                {
                    nv.LoaiTaiKhoan = 0;
                }
                else if (cbB_loaitk.SelectedIndex == 1)
                {
                    nv.LoaiTaiKhoan = 1;
                }
                else
                {
                    nv.LoaiTaiKhoan = -1;
                }
                //Cập nhật trạng thái tài khoản ( 1: còn hoạt động,  0: đã nghỉ làm ). Mặc định khi thêm trạng thái là 1
                nv.TrangThai = 1;

                result = NhanVien.themNhanVien(nv);

                if (result == 0)
                    MessageBox.Show("Bạn đã thêm thất bại");
                else
                {
                    MessageBox.Show("Bạn đã thêm thành công");
                    // load lại ảnh để khi thao tác tiếp theo không sử dụng lại 
                    pictureBox_anh.Image = null;
                    loadData();
                }
                NhanVienDaThem?.Invoke(this, EventArgs.Empty);

            }
        }

        private void btn_tailai_Click(object sender, EventArgs e)
        {
            pictureBox_anh.Image = null;
            cbB_loaitk.SelectedIndex = -1;
            txt_hoTen.Text = "";
            txt_tenTK.Text = "";
            txt_matKhau.Text = "";
            txt_email.Text = "";
            nmr_luong.Value = 0;
            txt_sdt.Text = "";
            txt_diaChi.Text = "";
            rd_nam.Checked = false;
            rd_nu.Checked = false;
        }
        public void loadData()
        {
            dataGridView_dsnhanvien.DataSource = NhanVien.hienThiDSNhanVien();
        }
        private void btn_taiLen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Chon anh";

            ofd.Filter = "Hinh anh|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox_anh.Image = Image.FromFile(ofd.FileName);

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
                pictureBox_anh.Tag = imageName;
            }
        }
    }
}
