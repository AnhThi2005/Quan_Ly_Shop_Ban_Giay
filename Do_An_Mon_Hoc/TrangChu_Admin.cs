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
    public partial class TrangChu_Admin : Form
    {
        bool sidebarExpand;
        bool nhanvienColapse;
        bool sanphamColapse;
        
        private object btn_themvnanien;

        private NHANVIEN nv;
        public TrangChu_Admin()
        {
            InitializeComponent();
            this.Size = new Size(1845, 836); 
            this.StartPosition = FormStartPosition.CenterScreen;
            uC_ThemNhanVien1.NhanVienDaThem += (s, args) =>
            {
                uC_NhanVien1.loadData(); // Gọi load lại danh sách
            };

            uC_NhanVien1.NhanVienDaXoa += (s, args) =>
            {
                uC_ThemNhanVien1.loadData();
            };

            uC_NhanVien1.NhanVienDaCapNhat += (s, args) =>
            {
                uC_ThemNhanVien1.loadData(); 
            };
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
        
        private void TrangChu_Admin_Load(object sender, EventArgs e)
        {
            
            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Xin Chào Admin !";

            uC_NhanVien1.Hide();
            uC_ThongTinCaNhan1.Hide();
            uC_ThemNhanVien1.Hide();
            uC_SanPham1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_DoanhThu1.Hide();
            uC_NhaCungCap2.Hide();

            nv = EmployeeInfoBLL.Instance.hienThiThongTin(TrangDangNhap.id);
            string fixPath = Path.Combine(Application.StartupPath, "Images");
            if (nv != null)
            {
                if (!string.IsNullOrEmpty(nv.Anh))
                    picture_acc.Image = Image.FromFile(fixPath + "\\" + nv.Anh);
                lbl_tenTK.Text = nv.HoTen;
                lbl_tenTK.Left = picture_acc.Left + (picture_acc.Width - lbl_tenTK.Width) / 2;
            }

        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Trang Chủ";
            uC_TrangChu1.Show();

            lbl_tranghienthi.Text=btn_trangchu.Text;
            uC_NhanVien1.Hide();
            uC_ThongTinCaNhan1.Hide();
            uC_ThemNhanVien1.Hide();
            uC_SanPham1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_DoanhThu1.Hide();
            uC_NhaCungCap2.Hide();
        }

        private void btn_thongtincanhan_Click(object sender, EventArgs e)
        {
            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Thông Tin Cá Nhân ";

            //Ẩn các trang còn lại
            uC_NhanVien1.Hide();
            uC_ThemNhanVien1.Hide();
            uC_SanPham1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_DoanhThu1.Hide();
            uC_NhaCungCap2.Hide();

            //Hiện UC_ThongTinCaNhan
            uC_ThongTinCaNhan1.Show();
            uC_ThongTinCaNhan1.BringToFront();
        }

        private void btn_qlnhanien_Click(object sender, EventArgs e)
        {
            //Bắt đầu timer của chức năng nhân viên
            timer_nhanvien.Start();

            //Hiện trang quản lý nhân viên với tính năng cập nhật và xóa
            uC_NhanVien1.Show();
            uC_NhanVien1.BringToFront();

            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Quản Lý Nhân Viên";

            //Ẩn các trang còn lại
            uC_ThongTinCaNhan1.Hide();
            uC_ThemNhanVien1.Hide() ;
            uC_SanPham1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_DoanhThu1.Hide();
            uC_NhaCungCap2.Hide();


        }

        private void btn_qlsanpham_Click(object sender, EventArgs e)
        {
            //Ẩn các trang còn lại
            uC_NhanVien1.Hide();
            uC_ThongTinCaNhan1.Hide();
            uC_ThemNhanVien1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_DoanhThu1.Hide();
            uC_NhaCungCap2.Hide();

            //Hiện UC_SanPham
            uC_SanPham1.Show();
            uC_SanPham1.BringToFront();

            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Quản Lý Sản Phẩm";
        }

        //private void btn_qlkhachhang_Click(object sender, EventArgs e)
        //{
        //    Ẩn các trang còn lại
        //    uC_NhanVien1.Hide();
        //    uC_ThongTinCaNhan1.Hide();
        //    uC_ThemNhanVien1.Hide();
        //    uC_SanPham1.Hide();
        //    uC_DonHang1.Hide();
        //    uC_DoanhThu1.Hide();
        //    uC_NhaCungCap2.Hide();

        //    Hiện UC_KhachHang
        //    uC_KhachHang1.Show();
        //    uC_KhachHang1.BringToFront();

        //    Tên của trang hiển thị
        //    lbl_tranghienthi.Text = btn_qlkhachhang.Text;

        //}

        //private void btn_qldonhang_Click_1(object sender, EventArgs e)
        //{
        //    //Ẩn các trang còn lại
        //    uC_NhanVien1.Hide();
        //    uC_ThongTinCaNhan1.Hide();
        //    uC_ThemNhanVien1.Hide();
        //    uC_SanPham1.Hide();
        //    uC_KhachHang1.Hide();
        //    uC_DoanhThu1.Hide();
        //    uC_NhaCungCap2.Hide();


        //    //Hiện UC_DonHang
        //    uC_DonHang1.Show();
        //    uC_DonHang1.BringToFront();

        //    //Tên của trang hiển thị
        //    lbl_tranghienthi.Text = btn_qldonhang.Text;
        ////}

        private void btn_dangxuat_Click_1(object sender, EventArgs e)
        {
            uC_NhanVien1.Hide();
            uC_ThongTinCaNhan1.Hide();
            uC_ThemNhanVien1.Hide();
            uC_KhachHang1.Hide();
            uC_DoanhThu1.Hide();
            uC_NhaCungCap2.Hide();
            //TrangDangNhap trangDangNhap = new TrangDangNhap();
            //trangDangNhap.Show();
            this.Hide();
            TrangDangNhap trangDangNhap = new TrangDangNhap();
            trangDangNhap.ShowDialog();

        }

        private void btn_qldoanhthu_Click(object sender, EventArgs e)
        {
            //Ẩn các trang còn lại
            uC_NhanVien1.Hide();
            uC_ThongTinCaNhan1.Hide();
            uC_ThemNhanVien1.Hide();
            uC_SanPham1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_NhaCungCap2.Hide();

            //Hiện UC_DoanhThu
            uC_DoanhThu1.Show();
            uC_DoanhThu1.BringToFront();

            //Tên của trang hiển thị
            lbl_tranghienthi.Text = btn_qldoanhthu.Text;
        }

        private void btn_qlnhacc_Click(object sender, EventArgs e)
        {
            //Ẩn các trang còn lại
            uC_NhanVien1.Hide();
            uC_ThongTinCaNhan1.Hide();
            uC_ThemNhanVien1.Hide();
            uC_SanPham1.Hide();
            uC_KhachHang1.Hide();
            uC_DonHang1.Hide();
            uC_DoanhThu1.Hide();


            //Hiện UC_SanPham
            uC_NhaCungCap2.Show();
            uC_NhaCungCap2.BringToFront();

            //Tên của trang hiển thị
            lbl_tranghienthi.Text = btn_qlnhacc.Text;
        }

        // Hàm tạo timer cho sidebar khi ấn vào picture menu
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                sidebar.Width -= 10;
                
                if (sidebar.Width==sidebar.MinimumSize.Width )
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

        // Hàm khởi tạo timer sidebar khi nhấn picture menu
        private void pictureBox_chucnang_Click(object sender, EventArgs e)
        {

            timer1.Start();
        }

        // Hàm timer của quản lý nhân viên
        private void timer_nhanvien_Tick(object sender, EventArgs e)
        {
            if (nhanvienColapse)
            {
                panel_chucnangnv.Height += 10;
                if (panel_chucnangnv.Height == panel_chucnangnv.MaximumSize.Height)
                {
                    nhanvienColapse = false;
                    
                    timer_nhanvien.Stop();

                }
            }
            else
            {
                panel_chucnangnv.Height -= 10;
                if (panel_chucnangnv.Height == panel_chucnangnv.MinimumSize.Height)
                {
                    nhanvienColapse = true;
                    timer_nhanvien.Stop();
                }

            }
        }


        // Sự kiện Click của button thêm nhân viên (btn_themvn) 
        private void btn_themvn_Click(object sender, EventArgs e)
        {
                //Ẩn các trang còn lại
                uC_NhanVien1.Hide();
                uC_ThongTinCaNhan1.Hide();

                //Hiện UC_ThemNhanVien
                uC_ThemNhanVien1.Show();
                uC_ThemNhanVien1.BringToFront();
            
        }

        //Sự kiện Click của button thêm sản phẩm (btn_themsp) 
        private void btn_themsanpham_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tenTK_TextChanged(object sender, EventArgs e)
        {
            lbl_tenTK.Left = picture_acc.Left + (picture_acc.Width - lbl_tenTK.Width) / 2;
        }

        private void btn_qldonhang_Click(object sender, EventArgs e)
        {
            uC_ThongTinCaNhan1.Hide();
            uC_KhachHang1.Hide();
            //uC_SanPham_NV1.Hide();
            //Hiện UC_DonHang
            uC_DonHang1.Show();
            uC_DonHang1.BringToFront();

            //Tên của trang hiển thị
            lbl_tranghienthi.Text = "Quản Lý Đơn Hàng";
        }

        //private void timer_sanpham_Tick(object sender, EventArgs e)
        //{
        //    if (sanphamColapse)
        //    {
        //        panel_chucnangsanpham.Height += 10;
        //        if (panel_chucnangsanpham.Height == panel_chucnangsanpham.MaximumSize.Height)
        //        {
        //            sanphamColapse = false;

        //            timer_sanpham.Stop();

        //        }
        //    }
        //    else
        //    {
        //        panel_chucnangsanpham.Height -= 10;
        //        if (panel_chucnangsanpham.Height == panel_chucnangsanpham.MinimumSize.Height)
        //        {
        //            sanphamColapse = true;
        //            timer_sanpham.Stop();
        //        }

        //    }
        //}
    }
}
