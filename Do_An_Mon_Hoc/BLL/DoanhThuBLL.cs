using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DAL;

namespace Do_An_Mon_Hoc.BLL
{
    internal class DoanhThuBLL
    {
        private static DoanhThuBLL instance;
        public static DoanhThuBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoanhThuBLL();
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.DoanhThu> hienthiDoanhthu()
        {
            try
            {
                return DoanhThuDAL.Instance.layDSDoanhthu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public double hienthiTongdoanhthu(double tongdoanhthu)
        {
            try
            {
                return DoanhThuDAL.Instance.layTongdoanhthu(tongdoanhthu);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public double hienthiTongdoanhthuTM(double tongdoanhthu)
        {
            try
            {
                return DoanhThuDAL.Instance.layTongdoanhthuTM(tongdoanhthu);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public double hienthiTongdoanhthuCK(double tongdoanhthu)
        {
            try
            {
                return DoanhThuDAL.Instance.layTongdoanhthuCK(tongdoanhthu);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public double hienthiTongdoanhthuTS(double tongdoanhthu)
        {
            try
            {
                return DoanhThuDAL.Instance.layTongdoanhthuTS(tongdoanhthu);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public double hienthiTongdoanhthuThe(double tongdoanhthu)
        {
            try
            {
                return DoanhThuDAL.Instance.layTongdoanhthuThe(tongdoanhthu);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public double hienthiTongdoanhthuVi(double tongdoanhthu)
        {
            try
            {
                return DoanhThuDAL.Instance.layTongdoanhthuVi(tongdoanhthu);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
