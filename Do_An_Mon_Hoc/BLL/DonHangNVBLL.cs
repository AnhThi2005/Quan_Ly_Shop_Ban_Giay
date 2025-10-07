using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.DAL;

namespace Do_An_Mon_Hoc.BLL
{
    internal class DonHangNVBLL
    {
        public static DonHangNVBLL instance;
        public static DonHangNVBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DonHangNVBLL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DONHANG> GetList()
        {
            return DAL.DonHangNVDAL.Instance.GetList();
        }

        public List<DTO.DONHANG> SearchKhachHang(string searchTerm, string seachten)
        {
            return DAL.DonHangNVDAL.Instance.SearchKhachHang(searchTerm, seachten);
        }
        public List<DTO.DONHANG> dstheomHD(string mahd)
        {
            return DAL.DonHangNVDAL.Instance.dstheomHD(mahd);
        }
    }
}
