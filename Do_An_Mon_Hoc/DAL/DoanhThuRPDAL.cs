using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DAL
{
    internal class DoanhThuRPDAL
    {
        private static DoanhThuRPDAL instance;
        public static DoanhThuRPDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoanhThuRPDAL();
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DoanhThuRP> layDSDoanhthu(DateTime ngaybd,DateTime ngaykt)
        {
            List<DTO.DoanhThuRP> list = new List<DTO.DoanhThuRP>();
            string query = "SELECT a.MATHANHTOAN, PHUONGTHUC,NGAYLAPHD, TONGDOANHTHU FROM DoanhThu a, HOADON b where a.mathanhtoan = b.mathanhtoan and ngaylaphd between @ngaybd and @ngaykt";
            List<object> parameters = new List<object>();
            parameters.Add(ngaybd);
            parameters.Add(ngaykt);
            DataTable table = DataProvider.Instance.excuteReader(query,parameters);
            foreach (DataRow row in table.Rows)
            {
                DTO.DoanhThuRP doanhthu = new DTO.DoanhThuRP(row);
                list.Add(doanhthu);
            }
            return list;
        }
        public List<DTO.DoanhThuRP> laydoanhthutheophuongthuc()
        {
            List<DTO.DoanhThuRP> list = new List<DTO.DoanhThuRP> ();
            string query = "select sum(tongdoanhthu) from doanhthu group by phuongthuc";
            DataTable table = DataProvider.Instance.excuteReader(query);
            foreach (DataRow row in table.Rows)
            {
                DTO.DoanhThuRP doanhthu = new DTO.DoanhThuRP(row);
                list.Add(doanhthu);
            }
            return list;
        }
    }
}
