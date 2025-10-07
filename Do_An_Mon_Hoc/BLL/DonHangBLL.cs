using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DAL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc.BLL
{
    internal class DonHangBLL
    {
        private static DonHangBLL instance;
        public static DonHangBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DonHangBLL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DONHANG> GetList()
        {
            return DAL.DonHangDAL.Instance.GetList();
        }

        public List<DONHANG> locDonHang(DateTime ngayA, DateTime ngayB, string tenNV)
        {
            try
            {
                return DonHangDAL.Instance.locDonHang(ngayA, ngayB, tenNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<DONHANG> locDonHangKhongNV(DateTime ngayA, DateTime ngayB)
        {
            try
            {
                return DonHangDAL.Instance.locDonHangKhongNV(ngayA, ngayB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<DTO.DONHANG> dstheomHD(string mahd)
        {
            return DAL.DonHangDAL.Instance.dstheomHD(mahd);
        }
    }
}
