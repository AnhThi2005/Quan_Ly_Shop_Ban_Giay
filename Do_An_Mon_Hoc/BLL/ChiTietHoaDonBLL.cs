using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DAL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc.BLL
{
    internal class ChiTietHoaDonBLL
    {
        private static ChiTietHoaDonBLL instance;

        public static ChiTietHoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonBLL();
                return instance;

            }

            set => instance = value;
        }

        public List<CHITIETHOADON> layChiTietHD(string maHD)
        {
            try
            {
                return ChiTietHoaDonDAL.Instance.layChiTietHD(maHD);
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
