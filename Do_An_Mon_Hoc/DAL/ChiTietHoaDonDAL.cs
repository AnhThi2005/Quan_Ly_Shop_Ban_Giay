using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc.DAL
{
    internal class ChiTietHoaDonDAL
    {
        private static ChiTietHoaDonDAL instance;

        public static ChiTietHoaDonDAL Instance
        {
            get
            {
                if(instance == null)
                    instance = new ChiTietHoaDonDAL();
                return instance;
            }
            private set => instance = value;
        }

        public List<CHITIETHOADON> layChiTietHD(string maHD)
        {
            List<CHITIETHOADON> list = new List<CHITIETHOADON> ();

            string query = "SELECT MAHD, SANPHAM.MASP, TENSP, CHITIETHOADON.SOLUONG, CHITIETHOADON.GIA , THANHTIEN = CHITIETHOADON.SOLUONG * GIA " +
                " FROM CHITIETHOADON INNER JOIN SANPHAM ON CHITIETHOADON.MASP = SANPHAM.MASP WHERE MAHD = @MAHD";

            List<object> parameters= new List<object>();

            parameters.Add(maHD);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new CHITIETHOADON(row));
                }
            }

            return list;
        }
        
    }
}
