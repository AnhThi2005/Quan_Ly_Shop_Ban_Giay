using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.DAL;
using System.Windows.Forms;

namespace Do_An_Mon_Hoc.BLL
{
    internal class DoanhThuRPBLL
    {
        private static DoanhThuRPBLL instance;
        public static DoanhThuRPBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoanhThuRPBLL();
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DoanhThuRP> hienthiDoanhthu(DateTime ngaybd, DateTime ngaykt)
        {
            try
            {
                return DoanhThuRPDAL.Instance.layDSDoanhthu(ngaybd, ngaykt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<DTO.DoanhThuRP> hienthiDoanhthutheophuongthuc()
        {
            try
            {
                return DoanhThuRPDAL.Instance.laydoanhthutheophuongthuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
