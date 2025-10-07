using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.BLL;

namespace Do_An_Mon_Hoc.DAL
{
    internal class DonHangNVDAL
    {
        public static DonHangNVDAL instance;//chú ý "public"
        public static DonHangNVDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DonHangNVDAL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DONHANG> GetList()
        {
            List<DTO.DONHANG> list = new List<DTO.DONHANG>();
            string query = "SELECT khachhang.MAKH, KHACHHANG.TENKH, HOADON.MAHD, MASP, NGAYLAPHD, SOLUONG, TONGTIEN, DIACHI, SDT, PHUONGTHUC FROM KhachHang INNER JOIN HOADON ON KHACHHANG.MAKH=HOADON.MAKH INNER JOIN CHITIETHOADON ON HOADON.MAHD=CHITIETHOADON.MAHD, THANHTOAN WHERE HOADON.MATHANHTOAN=THANHTOAN.MATHANHTOAN";
            System.Data.DataTable d = DataProvider.Instance.excuteReader(query);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.DONHANG ql = new DTO.DONHANG(item);
                list.Add(ql);
            }
            return list;
        }

        public List<DTO.DONHANG> SearchKhachHang(string searchma, string seachten)
        {
            List<DTO.DONHANG> list = new List<DTO.DONHANG>();
            string query = "SELECT khachhang.MAKH, KHACHHANG.TENKH, HOADON.MAHD, MASP, NGAYLAPHD, SOLUONG, TONGTIEN, DIACHI, SDT, PHUONGTHUC FROM KhachHang INNER JOIN HOADON ON KHACHHANG.MAKH=HOADON.MAKH INNER JOIN CHITIETHOADON ON HOADON.MAHD=CHITIETHOADON.MAHD, THANHTOAN WHERE HOADON.MATHANHTOAN=THANHTOAN.MATHANHTOAN AND khachhang.MAKH LIKE @searchma OR TENKH LIKE @seachten";


            List<object> parameters = new List<object>();
            parameters.Add("%" + searchma + "%");
            parameters.Add("%" + seachten + "%");


            DataTable d = DataProvider.Instance.excuteReader(query, parameters);
            foreach (DataRow item in d.Rows)
            {
                DTO.DONHANG ql = new DTO.DONHANG(item);
                list.Add(ql);
            }
            return list;
        }
        public List<DTO.DONHANG> dstheomHD(string mahd)
        {
            List<DTO.DONHANG> list = new List<DTO.DONHANG>();
            string query = "SELECT khachhang.MAKH, KHACHHANG.TENKH, HOADON.MAHD, MASP, NGAYLAPHD, TONGTIEN, PHUONGTHUC FROM KhachHang INNER JOIN HOADON ON KHACHHANG.MAKH=HOADON.MAKH INNER JOIN CHITIETHOADON ON HOADON.MAHD=CHITIETHOADON.MAHD, THANHTOAN WHERE HOADON.MATHANHTOAN=THANHTOAN.MATHANHTOAN AND HOADON.MAHD LIKE @mahd";
            List<object> parameters = new List<object>();
            parameters.Add("%" + mahd + "%");


            DataTable d = DataProvider.Instance.excuteReader(query, parameters);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.DONHANG ql = new DTO.DONHANG(item);
                list.Add(ql);
            }
            return list;
        }
    }
}
