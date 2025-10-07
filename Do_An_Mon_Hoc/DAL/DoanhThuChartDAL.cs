using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Do_An_Mon_Hoc.DAL
{
    internal class DoanhThuChartDAL
    {
        private static DoanhThuChartDAL instance;//chú ý "public"
        public static DoanhThuChartDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DoanhThuChartDAL();
                }
                return instance;
            }
            private set => instance = value;
        }

        public List<DTO.DOANHTHU> doanhThuTheoThang(int nam)
        {
            List<DTO.DOANHTHU> list = new List<DTO.DOANHTHU> ();
            string query = " SELECT FORMAT(NGAYLAPHD, 'MM') AS Thang , SUM(TONGTIEN) AS TongDoanhThu" +
                " FROM HOADON Where YEAR(NGAYLAPHD) = @nam" +
                " GROUP BY FORMAT(NGAYLAPHD, 'MM')" +
                " ORDER BY Thang ";
            List<object> parameter = new List<object>();
            parameter.Add (nam);
            DataTable d = DataProvider.Instance.excuteReader(query, parameter);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.DOANHTHU doanhThuThang = new DTO.DOANHTHU(item);
                list.Add(doanhThuThang);
            }
            return list;
        }

        public decimal tongDoanhThuThang(int nam, int thang)
        {
            string query = "SELECT SUM ( TONGTIEN ) FROM HOADON Where YEAR ( NGAYLAPHD ) = @nam AND MONTH ( NGAYLAPHD ) = @thang";

            List<object> parameter = new List<object>();
            parameter.Add(nam);
            parameter.Add (thang);

            object result = DAL.DataProvider.Instance.executeScalar(query, parameter);

            if (result == null || result == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToDecimal(result);

        }

        public int tongSLSanPhamDaBan(int nam, int thang)
        {
            string query = "select sum ( SOLUONG ) from CHITIETHOADON join HOADON on CHITIETHOADON.MAHD = HOADON.MAHD Where YEAR ( NGAYLAPHD ) = @nam AND MONTH ( NGAYLAPHD ) = @thang";
            List<object> parameter = new List<object>();
            parameter.Add((nam));
            parameter.Add((thang));
            object count = (DAL.DataProvider.Instance.executeScalar(query, parameter));
            if (count == null || count == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(count);
        }
    }
}
