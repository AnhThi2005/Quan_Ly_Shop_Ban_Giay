using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DAL
{
    internal class KhachHangDAL
    {
        public static KhachHangDAL instance;//chú ý "public"
        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangDAL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.KHACHHANG> GetList()
        {
            List<DTO.KHACHHANG> list = new List<DTO.KHACHHANG>();
            string query = "SELECT * FROM KHACHHANG";
            System.Data.DataTable d = DataProvider.Instance.excuteReader(query);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.KHACHHANG ql = new DTO.KHACHHANG(item);
                list.Add(ql);
            }
            return list;
        }
        public int suaKhachHang(DTO.KHACHHANG kh)
        {
            List<object> parameters = new List<object>();
            string query = "UPDATE KhachHang SET TENKH = @TENKH, SDT = @SDT, EMAIL = @EMAIL, DIACHI = @DIACHI, TENTK = @TENTK, MATKHAU = @MATKHAU WHERE MAKH = @MAKH";
            parameters.Add(kh.TenKH);
            parameters.Add(kh.Sdt);
            parameters.Add(kh.Email);
            parameters.Add(kh.DiaChi);
            parameters.Add(kh.TenTK);
            parameters.Add(kh.MatKhau);
            parameters.Add(kh.MaKH);


            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public List<DTO.KHACHHANG> SearchKhachHang(string searchma, string seachten)
        {
            List<DTO.KHACHHANG> list = new List<DTO.KHACHHANG>();
            string query = "SELECT * FROM KhachHang WHERE  MAKH LIKE @searchma OR TENKH LIKE @seachten";


            List<object> parameters = new List<object>();
            parameters.Add("%" + searchma + "%");
            parameters.Add("%" + seachten + "%");


            DataTable d = DataProvider.Instance.excuteReader(query, parameters);
            foreach (DataRow item in d.Rows)
            {
                DTO.KHACHHANG ql = new DTO.KHACHHANG(item);
                list.Add(ql);
            }
            return list;
        }
    }
}
