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

namespace Do_An_Mon_Hoc
{
    public partial class UC_ThongTinCaNhan : UserControl
    {
        //Khai báo sự kiện
        public event EventHandler ThongTinNhanVienDaCapNhat;


        string fixPath = Path.Combine(Application.StartupPath, "Images");
        DTO.NHANVIEN nv = new DTO.NHANVIEN();
        BLL.EmployeeInfoBLL employeeInfo = new BLL.EmployeeInfoBLL();

        public UC_ThongTinCaNhan()
        {
            InitializeComponent();
            nv = employeeInfo.hienThiThongTin(TrangDangNhap.id);
            dtP_ngayVaoLam.MaxDate = DateTime.Now;

            if (nv != null)
            {
                if (nv.Anh != "")
                    pictureBox1.Image = Image.FromFile(fixPath + "\\" + nv.Anh);
                txt_hoTen.Text = nv.HoTen;
                txt_diaChi.Text = nv.DiaChi;
                txt_email.Text = nv.Email;
                txt_sdt.Text = nv.Sdt;
                if (nv.GioiTinh == "Nam")
                    rb_nam.Checked = true;
                else if (nv.GioiTinh == "Nữ")
                    rb_nu.Checked = true;

                dtP_ngSinh.Value = nv.NgSinh;
                dtP_ngayVaoLam.Value = nv.NgayVaoLam;

                if (nv.LoaiTaiKhoan == 1)
                    txt_chucVu.Text = "Quản lý";
                else
                    txt_chucVu.Text = "Nhân viên";
                txt_tenTK.Text = nv.TenTK;

            }
        }

        private void btn_taiLen_Click(object sender, EventArgs e)
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

        private void btn_capNhat_Click(object sender, EventArgs e)
        {
            int result = 0;

            string imageName = pictureBox1.Tag?.ToString() ?? "";

            nv.Anh = imageName;

            nv.HoTen = txt_hoTen.Text;

            nv.NgSinh = dtP_ngSinh.Value;

            if (rb_nam.Checked)
                nv.GioiTinh = "Nam";
            else
                nv.GioiTinh = "Nữ";

            nv.Email = txt_email.Text;

            nv.Sdt = txt_sdt.Text;

            nv.DiaChi = txt_diaChi.Text;

            result = employeeInfo.capNhatThongTinNhanVien(nv);
            if (result == 0)
                MessageBox.Show("Bạn đã cập nhật thất bại");
            else
            {
                MessageBox.Show("Bạn đã cập nhật thành công");
                ThongTinNhanVienDaCapNhat?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btn_doiMk_Click(object sender, EventArgs e)
        {
            string mk = txt_matKhau.Text;
            string mkMoi = txt_matKhauMoi.Text;
            string nhapLai = txt_nhapLaiMK.Text;

            if (mk == "" || mkMoi == "" || nhapLai == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if(mk != nv.MatKhau)
            {
                MessageBox.Show("Sai mật khẩu, vui lòng nhập lại");
            }    
            else if (mk == nv.MatKhau)
            {
                if (mkMoi == "" || nhapLai == "")
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                else if (mk == mkMoi)
                {
                    MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ");
                }
                else
                {
                    if (mkMoi != nhapLai)
                        MessageBox.Show("Nhập lại không đúng");
                    else
                    {
                        nv.MatKhau = mkMoi;
                        int result = employeeInfo.doiMatKhau(mkMoi, TrangDangNhap.id);
                        if (result == 1)
                            MessageBox.Show("Đổi mật khẩu thành công");
                        else
                            MessageBox.Show("Đổi mật khẩu thất bại");
                    }
                }
            }
        }

        private void picture_eye1_Click(object sender, EventArgs e)
        {
            if (txt_matKhau.PasswordChar == '*')
            {
                picture_hide1.BringToFront();
                txt_matKhau.PasswordChar = '\0';
            }
        }

        private void picture_hide1_Click(object sender, EventArgs e)
        {
            if (txt_matKhau.PasswordChar == '\0')
            {
                picture_eye1.BringToFront();
                txt_matKhau.PasswordChar = '*';
            }
        }

        private void picture_eye2_Click(object sender, EventArgs e)
        {
            if (txt_matKhauMoi.PasswordChar == '*')
            {
                picture_hide2.BringToFront();
                txt_matKhauMoi.PasswordChar = '\0';
            }
        }

        private void picture_hide2_Click(object sender, EventArgs e)
        {
            if (txt_matKhauMoi.PasswordChar == '\0')
            {
                picture_eye2.BringToFront();
                txt_matKhauMoi.PasswordChar = '*';
            }
        }

        private void picture_hide3_Click(object sender, EventArgs e)
        {
            if (txt_nhapLaiMK.PasswordChar == '\0')
            {
                picture_eye3.BringToFront();
                txt_nhapLaiMK.PasswordChar = '*';
            }
        }

        private void picture_eye3_Click(object sender, EventArgs e)
        {
            if (txt_nhapLaiMK.PasswordChar == '*')
            {
                picture_hide3.BringToFront();
                txt_nhapLaiMK.PasswordChar = '\0';
            }
        }
    }
}
