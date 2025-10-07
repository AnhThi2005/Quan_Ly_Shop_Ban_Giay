using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DAL;

namespace Do_An_Mon_Hoc.BLL
{
    internal class EmployeeInfoBLL
    {
        public static EmployeeInfoBLL instance;
        public static EmployeeInfoBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeInfoBLL();
                return instance;
            }
            private set => instance = value;
        }
        public DTO.NHANVIEN hienThiThongTin(int id)
        {
            try
            {
                return NhanVienDAL.Instance.layThongTinNhanVienBangId(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int capNhatThongTinNhanVien(DTO.NHANVIEN nv)
        {
            try
            {
                // Kiểm tra input 
                // Ngày không được lớn hơn ngày hiện tại 
                if (nv.NgSinh > DateTime.Now)
                {

                    //MessageBox.Show("Ngày sinh không phù hợp!");
                    MessageBox.Show("Vui lòng chọn ngày sinh phù hợp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                else
                {
                    if (DAL.NhanVienDAL.Instance.ktraTuoi(nv.NgSinh) == false)
                    {
                        MessageBox.Show("Nhân viên chưa đủ 18 tuổi");
                        return 0;
                    }
                }
                if (nv.LoaiTaiKhoan == -1)
                {
                    //MessageBox.Show("Không tồn tại loại tài khoản này!");
                    MessageBox.Show("Vui lòng nhập loại tài khoản hợp lệ", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                if (nv.NgSinh > DateTime.Now.Date)
                {
                    //MessageBox.Show("Ngày sinh không phù hợp!");
                    MessageBox.Show("Vui lòng chọn ngày sinh phù hợp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                // Số điện thoại chỉ chứa chữ số
                string sdt = nv.Sdt;
                if (!sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chứa kí tự ngoài số.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }

                return DAL.NhanVienDAL.Instance.capNhatThongTinNhanVien(nv);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }


        public int xoaNhanVien(int id)
        {
            try
            {
                return NhanVienDAL.Instance.xoaNhanVien(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }


        public int themNhanVien(DTO.NHANVIEN nv)
        {
            try
            {
                // Ngày không được lớn hơn ngày hiện tại 
                if (nv.NgSinh > DateTime.Now)
                {

                    //MessageBox.Show("Ngày sinh không phù hợp!");
                    MessageBox.Show("Vui lòng chọn ngày sinh phù hợp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                else
                {
                    if (DAL.NhanVienDAL.Instance.ktraTuoi(nv.NgSinh) == false)
                    {
                        MessageBox.Show("Nhân viên chưa đủ 18 tuổi");
                        return 0;
                    }
                }

                // Số điện thoại chỉ chứa chữ số và độ dài là 10
                string sdt = nv.Sdt;
                if (!sdt.All(char.IsDigit) || sdt.Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải 10 chữ số.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }

                // Tên chỉ được chứa chữ cái
                string hoTen = nv.HoTen;

                if (hoTen.All(char.IsDigit))
                {
                    MessageBox.Show("Tên chỉ chưa chữ cái", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                return DAL.NhanVienDAL.Instance.themNhanVien(nv);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }


        public List<DTO.NHANVIEN> hienThiDSNhanVien()
        {
            try
            {
                return NhanVienDAL.Instance.layDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DTO.NHANVIEN> hienThiTimKiemTheoHoTen(string hoTen)
        {
            try
            {
                return NhanVienDAL.Instance.hienThiDsTimKiemTheoHoTen(hoTen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int doiMatKhau(string matKhauMoi, int id)
        {
            try
            {
                return NhanVienDAL.Instance.doiMatKhau(matKhauMoi, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoGioiTinh(string gioiTinh)
        {
            try
            {
                return NhanVienDAL.Instance.hienThiDsTimKiemTheoGioiTinh(gioiTinh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoDiaChi(string diaChi)
        {
            try
            {
                return NhanVienDAL.Instance.hienThiDsTimKiemTheoDiaChi(diaChi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoEmail(string email)
        {
            try
            {
                return NhanVienDAL.Instance.hienThiDsTimKiemTheoEmail(email);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoTenTaiKhoan(string tenTaiKhoan)
        {
            try
            {
                return NhanVienDAL.Instance.hienThiDsTimKiemTheoTenTaiKhoan(tenTaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int timAnhTungLap(string anh)
        {
            try
            {
                return NhanVienDAL.Instance.timTraAnhTrungLap(anh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public List<string> layDsTenNv()
        {
            try
            {
                return DAL.NhanVienDAL.Instance.layDsTenNv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
