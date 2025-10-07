using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Do_An_Mon_Hoc
{
    public partial class TrangDangNhap : Form
    {
        public static int id;
        public TrangDangNhap()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            if (txt_pass.PasswordChar == '\0')
            {
                txt_pass.PasswordChar = '*';
            }
        }
        private void picture_hide_Click(object sender, EventArgs e)
        {
            if (txt_pass.PasswordChar == '\0')
            {
                picture_eye.BringToFront();
                txt_pass.PasswordChar = '*';
            }
        }
        private void picture_eye_Click_1(object sender, EventArgs e)
        {

            if (txt_pass.PasswordChar == '*')
            {
                picture_hide.BringToFront();
                txt_pass.PasswordChar = '\0';
            }
        }
        private void btn_thoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tenTk = txt_user.Text;
            string matKhau = txt_pass.Text;

            if (tenTk == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                BLL.LoginBLL loginBLL = new BLL.LoginBLL();

                DTO.NHANVIEN nv = loginBLL.checkLogin(tenTk, matKhau);

                   
                if (nv == null)
                {
                    MessageBox.Show("Tài khoản/mật khẩu chưa chính xác");
                }
                else
                {
                    if (nv.TrangThai == 0)
                    {
                        MessageBox.Show("Nhân viên không tồn tại");
                    }
                    id = nv.Id;
                    if (nv.LoaiTaiKhoan == 1)
                    {
                        TrangChu_Admin admin = new TrangChu_Admin();
                        this.Hide();
                        admin.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        TrangChu_NhanVien nvien = new TrangChu_NhanVien();
                        this.Hide();
                        nvien.ShowDialog();
                        this.Show();
                    }
                }
            }
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_pass.Text = "";
            }
        }
    }
}
