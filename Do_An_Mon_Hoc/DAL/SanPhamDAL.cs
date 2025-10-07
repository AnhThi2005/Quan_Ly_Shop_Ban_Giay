using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DAL
{
    internal class SanPhamDAL
    {
        private static SanPhamDAL instance;

        public static SanPhamDAL Instance
        {

            get
            {

                if (instance == null)

                    instance = new SanPhamDAL();

                return instance;
            }

            private set => instance = value;
        }
        //Lấy thông tin của 1 sản phẩm bằng mã sản phẩm
        public DTO.SANPHAM layThongTinSanPham(string maSP)
        {
            DTO.SANPHAM sp;

            string query = "SELECT * FROM SANPHAM WHERE MASP = @MASP";

            List<object> parameters = new List<object>();

            parameters.Add(maSP);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            sp = new DTO.SANPHAM(table.Rows[0]);

            return sp;
        }

        public List<DTO.SANPHAM> layDanhSachSanPham()
        {
            List<DTO.SANPHAM> listSP = new List<DTO.SANPHAM>();

            string query = "SELECT * FROM SANPHAM WHERE TRANGTHAI != 0";

            DataTable table = DataProvider.Instance.excuteReader(query);

            foreach (DataRow row in table.Rows)
            {
                DTO.SANPHAM sp = new DTO.SANPHAM(row);
                listSP.Add(sp);
            }

            return listSP;
        }


        //Cập nhật thông tin sản phẩm
        public int capNhatThongTinSanPham(DTO.SANPHAM sp)
        {
            string query = "UPDATE SANPHAM SET TENSP = @TENSP , CHATLIEU = @CHATLIEU , SOLUONG = @SOLUONG , DONGIANHAP = @DONGIANHAP , " +
                "DONGIABAN = @DONGIABAN , GHICHU = @GHICHU , HINHANH = @HINHANH , MANCC = @MANCC WHERE MASP = @MASP";

            List<object> parameters = new List<object>();

            parameters.Add(sp.TenSP);
            parameters.Add(sp.ChatLieu);
            parameters.Add(sp.SoLuong);
            parameters.Add(sp.DonGiaNhap);
            parameters.Add(sp.DonGiaBan);
            parameters.Add(sp.GhiChu);
            parameters.Add(sp.HinhAnh);
            parameters.Add(sp.MaNCC);
            parameters.Add(sp.MaSP);

            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public int themSanPhamMoi(DTO.SANPHAM sp)
        {
            string query = "INSERT INTO SANPHAM ( TENSP , CHATLIEU , SOLUONG, DONGIANHAP , DONGIABAN , GHICHU , HINHANH , MANCC )" +
                " VALUES ( @TENSP , @CHATLIEU , @SOLUONG , @DONGIANHAP , @DONGIABAN , @GHICHU , @HINHANH , @MANCC )";

            List<object> parameters = new List<object>();

            parameters.Add(sp.TenSP);
            parameters.Add(sp.ChatLieu);
            parameters.Add(sp.SoLuong);
            parameters.Add(sp.DonGiaNhap);
            parameters.Add(sp.DonGiaBan);
            parameters.Add(sp.GhiChu);
            parameters.Add(sp.HinhAnh);
            parameters.Add(sp.MaNCC);

            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }



        public int xoaSanPham(DTO.SANPHAM sp)
        {
            string query = "UPDATE SANPHAM SET TRANGTHAI = 0 WHERE MASP = @MASP";

            List<object> parameters = new List<object>();

            parameters.Add(sp.MaSP);

            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public List<DTO.SANPHAM> hienThiTimKiemSP(string tenSP)
        {
            List<DTO.SANPHAM> listSP = new List<DTO.SANPHAM>();

            string query = "SELECT * FROM SANPHAM WHERE TENSP LIKE N'%' + @TENSP + '%' AND TRANGTHAI != 0";

            List<object> parameters = new List<object>();

            parameters.Add(tenSP);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            foreach (DataRow row in table.Rows)
            {
                DTO.SANPHAM sp = new DTO.SANPHAM(row);
                listSP.Add(sp);
            }

            return listSP;

        }
    }
}
