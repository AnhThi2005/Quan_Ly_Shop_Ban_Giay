using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.DAL;

namespace Do_An_Mon_Hoc.BLL
{
    internal class KhachHangBLL
    {
        public static KhachHangBLL instance;
        public static KhachHangBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangBLL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.KHACHHANG> GetList()
        {
            return DAL.KhachHangDAL.Instance.GetList();
        }

        public int suaKhachHang(DTO.KHACHHANG kh)
        {
            return DAL.KhachHangDAL.Instance.suaKhachHang(kh);
        }

        public List<DTO.KHACHHANG> SearchKhachHang(string searchTerm, string seachten)
        {
            return DAL.KhachHangDAL.Instance.SearchKhachHang(searchTerm, seachten);
        }
    }
}
