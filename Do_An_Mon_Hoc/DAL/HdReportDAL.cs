using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc.DAL
{
    internal class HdReportDAL
    {
        private static HdReportDAL instance;

        public static HdReportDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HdReportDAL();
                return instance;
            }
            private set => instance = value;
        }

        public List<HDREPORT> layChiTietHD(string maHD)
        {
            List<HDREPORT> list = new List<HDREPORT>();

            string query = "SELECT HD.MAHD, NGAYLAPHD, NV.HOTEN, SP.TENSP, CTHD.SOLUONG, CTHD.GIA,THANHTIEN = CTHD.GIA * CTHD.SOLUONG , HD.TIENKHACHTRA ,hd.TONGTIEN, TIENTHUA = HD.TIENKHACHTRA - HD.TONGTIEN \r\nFROM HOADON HD INNER JOIN CHITIETHOADON CTHD ON HD.MAHD = CTHD.MAHD INNER JOIN NHANVIEN NV ON HD.ID = NV.ID INNER JOIN SANPHAM SP ON CTHD.MASP = SP.MASP\r\nWHERE HD.MAHD = @MAHD";

            List<object> parameters = new List<object>();

            parameters.Add(maHD);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new HDREPORT(row));
                }
            }

            return list;
        }
    }
}
