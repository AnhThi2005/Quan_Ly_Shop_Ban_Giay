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
    public partial class TrangChu_NhanVien : Form
    {
        bool sidebarExpand;

        NHANVIEN nv = new NHANVIEN();
        public TrangChu_NhanVien()
        {
            InitializeComponent();
            this.Size = new Size(1845, 836);
            this.StartPosition = FormStartPosition.CenterScreen;

            uC_ThongTinCaNhan1.ThongTinNhanVienDaCapNhat += (s, e) =>
            {
                // Load lại thông tin nhân viên sau khi cập nhật
                nv = EmployeeInfoBLL.Instance.hienThiThongTin(TrangDangNhap.id);

                string fixPath = Path.Combine(Application.StartupPath, "Images");
                if (nv != null)
                {
                    if (!string.IsNullOrEmpty(nv.Anh))
                        picture_acc.Image = Image.FromFile(fixPath + "\\" + nv.Anh);
                    lbl_tenTK.Text = nv.HoTen;
                    lbl_tenTK.Left = picture_acc.Left + (picture_acc.Width - lbl_tenTK.Width) / 2;
                }
            };
        }

        private void TrangChu_NhanVien_Load(object sender, EventArgs e)
        {
            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Xin Chào Nhân Viên !";

            uC_ThongTinCaNhan1.Hide();
            uC_KhachHang1.Hide();
            uC_SanPham_NV1.Hide();
            uC_DonHang1.Hide();
            uC_hoadon1.Hide();

            nv = EmployeeInfoBLL.Instance.hienThiThongTin(TrangDangNhap.id);
            if (nv != null)
            {
                string fixPath = Path.Combine(Application.StartupPath, "Images");
                if (nv.Anh != null && nv.Anh != "")
                    picture_acc.Image = Image.FromFile(fixPath + "\\" + nv.Anh);
                lbl_tenTK.Text = nv.HoTen;

                lbl_tenTK.Left = picture_acc.Left + (picture_acc.Width - lbl_tenTK.Width) / 2;
            }
        }

        private void btn_trangchunv_Click(object sender, EventArgs e)
        {
            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Trang Chủ";
            uC_TrangChu2.Show();
            uC_TrangChu2.BringToFront();
            


            //Ẩn các trang còn lại
            uC_ThongTinCaNhan1.Hide();
            uC_KhachHang1.Hide();
            uC_SanPham_NV1.Hide();
            uC_DonHang1.Hide();
            uC_hoadon1.Hide();
        }
        private void btn_thongtincanhan_Click(object sender, EventArgs e)
        {
            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Thông Tin Cá Nhân";

            //Ẩn các trang còn lại
            uC_KhachHang1.Hide();
            uC_SanPham_NV1.Hide();
            uC_DonHang1.Hide();
            uC_hoadon1.Hide();
            //Hiện UC_ThongTinCaNhan
            uC_ThongTinCaNhan1.Show();
            uC_ThongTinCaNhan1.BringToFront();
        }

        

        private void btn_qlsanpham_Click(object sender, EventArgs e)
        {
            //Ẩn các trang còn lại
            uC_ThongTinCaNhan1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_hoadon1.Hide();
            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Quản Lý Sản Phẩm";

            //Hiện UC_SanPham
            uC_SanPham_NV1.Show();
            uC_SanPham_NV1.BringToFront();

        }

        private void btn_qlkhachhang_Click(object sender, EventArgs e)
        {
            //Ẩn các trang còn lại

            uC_ThongTinCaNhan1.Hide();
            uC_SanPham_NV1.Hide();
            uC_DonHang1.Hide();
            uC_hoadon1.Hide();
            //Hiện UC_KhachHang
            uC_KhachHang1.Show();
            uC_KhachHang1.BringToFront();

            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Quản Lý Khách Hàng";
        }

        private void btn_qldonhang_Click(object sender, EventArgs e)
        {
            //Ẩn các trang còn lại
            uC_ThongTinCaNhan1.Hide();
            uC_KhachHang1.Hide();
            uC_SanPham_NV1.Hide();
            uC_hoadon1.Hide();
            uC_TrangChu1.Hide();
            uC_TrangChu2.Hide();
            uC_DonHang1.Show();            //Hiện UC_DonHang
            //UC_DonHangNV uC_DonHangNV = new UC_DonHangNV();
            //uC_DonHangNV.Show();
            //uC_DonHangNV.BringToFront();

            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Quản Lý Đơn Hàng";
        }

        // Hàm tạo timer cho sidebar khi ấn vào picture menu
        
        private void pictureBox_chucnang_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;

                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    //pictureBox1.Hide(); sửa
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;

                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    //pictureBox1.Show(); sửa
                    timer1.Stop();
                }
            }
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            uC_ThongTinCaNhan1.Hide();
            uC_KhachHang1.Hide();
            this.Hide();
            TrangDangNhap trangDangNhap = new TrangDangNhap();
            trangDangNhap.ShowDialog();

        }

        private void btn_HD_Click(object sender, EventArgs e)
        {
            //UC_hoadon uC_Hoadon = new UC_hoadon();
            uC_hoadon1.Show();
            uC_hoadon1.BringToFront();
            uC_ThongTinCaNhan1.Hide();
            uC_KhachHang1.Hide();
            uC_SanPham_NV1.Hide();
            uC_TrangChu1.Hide();
            uC_DonHang1.Hide();
            lbl_tranghienthi.Text = "Quản Lý Hóa Đơn";
        }
    }
}
