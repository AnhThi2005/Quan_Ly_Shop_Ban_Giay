using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DAL
{
    internal class DoanhThuDAL
    {
        private static DoanhThuDAL instance;
        public static DoanhThuDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoanhThuDAL();
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DoanhThu> layDSDoanhthu()
        {
            List<DTO.DoanhThu> list = new List<DTO.DoanhThu> ();
            string query = "SELECT MATHANHTOAN, PHUONGTHUC, TONGDOANHTHU FROM DoanhThu";
            DataTable table = DataProvider.Instance.excuteReader(query);
            foreach (DataRow row in table.Rows)
            {
                DTO.DoanhThu doanhthu = new DTO.DoanhThu(row);
                list.Add(doanhthu);
            }
            return list;
        }
        public double layTongdoanhthu(double tongdoanhthu)
        {
            string query = "select sum(tongdoanhthu) from doanhthu";
            object result = DataProvider.Instance.executeScalar(query);
            return Convert.ToDouble(result);
        }
        public double layTongdoanhthuTM(double tongdoanhthu)
        {
            string query = "select tongdoanhthu from doanhthu where phuongthuc like N'Tiền Mặt'";
            object result = DataProvider.Instance.executeScalar(query);
            return Convert.ToDouble(result);
        }
        public double layTongdoanhthuCK(double tongdoanhthu)
        {
            string query = "select tongdoanhthu from doanhthu where phuongthuc like N'Chuyển Khoản Ngân Hàng'";
            object result = DataProvider.Instance.executeScalar(query);
            return Convert.ToDouble(result);
        }
        public double layTongdoanhthuTS(double tongdoanhthu)
        {
            string query = "select tongdoanhthu from doanhthu where phuongthuc like N'Trả Sau'";
            object result = DataProvider.Instance.executeScalar(query);
            return Convert.ToDouble(result);
        }
        public double layTongdoanhthuThe(double tongdoanhthu)
        {
            string query = "select tongdoanhthu from doanhthu where phuongthuc like N'Thẻ Credit'";
            object result = DataProvider.Instance.executeScalar(query);
            return Convert.ToDouble(result);
        }
        public double layTongdoanhthuVi(double tongdoanhthu)
        {
            string query = "select tongdoanhthu from doanhthu where phuongthuc like N'Ví Điện Tử'";
            object result = DataProvider.Instance.executeScalar(query);
            return Convert.ToDouble(result);
        }
    }
}
