using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.BLL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc.DAL
{
    internal class DonHangDAL
    {
        private static DonHangDAL instance;//chú ý "public"
        public static DonHangDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DonHangDAL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DONHANG> GetList()
        {
            List<DTO.DONHANG> list = new List<DTO.DONHANG>();
            string query = "SELECT MAHD, NGAYLAPHD, HOTEN , MAKH, TONGTIEN\r\n FROM NHANVIEN INNER JOIN HOADON ON NHANVIEN.ID = HOADON.ID";
            System.Data.DataTable d = DataProvider.Instance.excuteReader(query);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.DONHANG ql = new DTO.DONHANG(item);
                list.Add(ql);
            }
            return list;
        }

        public List<DONHANG> locDonHang(DateTime ngayA, DateTime ngayB, string tenNV)
        {
            List<DONHANG> list = new List<DONHANG>();

            string query = "SELECT MAHD, NGAYLAPHD, HOTEN , MAKH, TONGTIEN\r\nFROM NHANVIEN INNER JOIN HOADON " +
                "ON NHANVIEN.ID = HOADON.ID\r\nWHERE NGAYLAPHD >= @NGAYA AND NGAYLAPHD <= @NGAYB AND HOTEN LIKE @HOTEN";
            List<object> parameters = new List<object>();
            parameters.Add(ngayA);
            parameters.Add(ngayB);
            parameters.Add($"%{tenNV}%");
            DataTable d = DataProvider.Instance.excuteReader(query, parameters);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.DONHANG ql = new DTO.DONHANG(item);
                list.Add(ql);
            }
            return list;
        }

        public List<DONHANG> locDonHangKhongNV(DateTime ngayA, DateTime ngayB)
        {
            List<DONHANG> list = new List<DONHANG>();

            string query = "SELECT MAHD, NGAYLAPHD, HOTEN , MAKH, TONGTIEN\r\nFROM NHANVIEN INNER JOIN HOADON " +
                "ON NHANVIEN.ID = HOADON.ID\r\nWHERE NGAYLAPHD >= @NGAYA AND NGAYLAPHD <= @NGAYB";
            List<object> parameters = new List<object>();
            parameters.Add(ngayA);
            parameters.Add(ngayB);
            DataTable d = DataProvider.Instance.excuteReader(query, parameters);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.DONHANG ql = new DTO.DONHANG(item);
                list.Add(ql);
            }
            return list;
        }

        public List<DTO.DONHANG> dstheomHD(string mahd)
        {
            List<DTO.DONHANG> list = new List<DTO.DONHANG>();
            string query = "SELECT khachhang.MAKH, KHACHHANG.TENKH, HOADON.MAHD, MASP, NGAYLAPHD, TONGTIEN, PHUONGTHUC FROM KhachHang INNER JOIN HOADON ON KHACHHANG.MAKH=HOADON.MAKH INNER JOIN CHITIETHOADON ON HOADON.MAHD=CHITIETHOADON.MAHD, DOANHTHU WHERE HOADON.MATHANHTOAN=DOANHTHU.MATHANHTOAN AND HOADON.MAHD LIKE @mahd";
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
