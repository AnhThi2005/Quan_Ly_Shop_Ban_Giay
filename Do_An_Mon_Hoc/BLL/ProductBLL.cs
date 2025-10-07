using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.DAL;
using Do_An_Mon_Hoc.DTO;
using System.Windows.Forms;

namespace Do_An_Mon_Hoc.BLL
{
    internal class ProductBLL
    {
        private static ProductBLL instance;
        public static ProductBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductBLL();
                return instance;
            }
            private set => instance = value;
        }

        private SanPhamDAL sanPhamDAL = new SanPhamDAL();
        public List<DTO.SANPHAM> hienThiDsSanPham()
        {
            try
            {
                return sanPhamDAL.layDanhSachSanPham();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DTO.SANPHAM hienThiThongTinSP(string maSP)
        {
            try
            {
                return sanPhamDAL.layThongTinSanPham(maSP);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int capNhatThongTinSanPham(SANPHAM sp)
        {
            // Có thể thêm các kiểm tra ở đây nếu cần, ví dụ như kiểm tra đầu vào.
            try
            {
                if (string.IsNullOrEmpty(sp.MaSP))
                {
                    throw new Exception("Mã sản phẩm không được để trống.");
                }

                return SanPhamDAL.Instance.capNhatThongTinSanPham(sp); // Gọi DAL để thực hiện cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int themThongTinSanPhamMoi(SANPHAM sp)
        {
            try
            {
                return SanPhamDAL.Instance.themSanPhamMoi(sp); // Gọi DAL để thực hiện cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }


        public List<DTO.SANPHAM> hienThiDSTimKiem(string tenSP)
        {
            try
            {
                return DAL.SanPhamDAL.Instance.hienThiTimKiemSP(tenSP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int xoaThongTinSanPham(SANPHAM sp)
        {
            try
            {
                return DAL.SanPhamDAL.Instance.xoaSanPham(sp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
