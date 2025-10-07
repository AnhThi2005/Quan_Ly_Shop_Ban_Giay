using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.DAL;
using Do_An_Mon_Hoc.DTO;
using System.Windows.Forms;

namespace Do_An_Mon_Hoc.BLL
{
    internal class HdReportBLL
    {
        private static HdReportBLL instance;

        public static HdReportBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HdReportBLL();
                return instance;

            }

            set => instance = value;
        }

        public List<HDREPORT> layChiTietHD(string maHD)
        {
            try
            {
                return HdReportDAL.Instance.layChiTietHD(maHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
