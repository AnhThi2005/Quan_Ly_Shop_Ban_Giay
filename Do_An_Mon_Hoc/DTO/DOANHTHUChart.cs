using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    public class DOANHTHU
    {
        private int thang;
        private decimal tongDoanhThu;

        public int Thang { get => thang; set => thang = value; }
        public decimal TongDoanhThu { get => tongDoanhThu; set => tongDoanhThu = value; }

        public DOANHTHU() { }

        public DOANHTHU(DataRow row)
        {
            thang = Int32.Parse(row["Thang"].ToString());
            tongDoanhThu = Decimal.Parse(row["TongDoanhThu"].ToString());
        }
    }
}
