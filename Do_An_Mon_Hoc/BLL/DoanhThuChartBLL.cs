using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DAL;

namespace Do_An_Mon_Hoc.BLL
{
    public class DoanhThuChartBLL
    {

        private static DoanhThuChartBLL instance;//chú ý "public"
        public static DoanhThuChartBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DoanhThuChartBLL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DOANHTHU> doanhThuThang(int nam)
        {
            try
            {
                return DoanhThuChartDAL.Instance.doanhThuTheoThang(nam);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public decimal tongDoanhThuThang(int nam, int thang)
        {
            try
            {
                decimal k = DoanhThuChartDAL.Instance.tongDoanhThuThang(nam, thang);
                if (k > 0)
                {
                    return DoanhThuChartDAL.Instance.tongDoanhThuThang(nam, thang);

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int tongSLSanPhamDaBan(int nam, int thang)
        {
            try
            {
                return DoanhThuChartDAL.Instance.tongSLSanPhamDaBan(nam, thang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
