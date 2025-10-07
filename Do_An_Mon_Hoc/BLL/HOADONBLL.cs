using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.BLL
{
    internal class HOADONBLL
    {
        public static HOADONBLL instance;
        public static HOADONBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HOADONBLL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.HOADON> GetList()
        {
            return DAL.HOADONDAL.Instance.GetList();
        }

        public List<DTO.HOADON> searchHD(string searchTerm)
        {
            return DAL.HOADONDAL.Instance.SearchHD(searchTerm);
        }
        public int suaHD(DTO.HOADON hd)
        {
            return DAL.HOADONDAL.Instance.suaHD(hd);
        }
        public int xoaHD(string maHD)
        {
            return DAL.HOADONDAL.Instance.xoaHD(maHD);
        }
        public int themHD(DTO.HOADON hd)
        {
            return DAL.HOADONDAL.Instance.themHD(hd);
        }
        public List<DTO.HOADON> loadhd()
        {
            return DAL.HOADONDAL.Instance.loadhd();
        }

    }
}
