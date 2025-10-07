using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    public class DONHANGNV
    {
        private string makh;
        private string tenkh;
        private string mahd;
        private string masp;
        private DateTime ngaylap;
        private float tongtien;
        private string phuongthuc;

        public DONHANGNV()
        {
        }

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Mahd { get => mahd; set => mahd = value; }
        public string Masp { get => masp; set => masp = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
        public string Phuongthuc { get => phuongthuc; set => phuongthuc = value; }

        public DONHANGNV(DataRow row)
        {
            Makh = row["MAKH"].ToString();
            Tenkh = row["TENKH"].ToString();
            Mahd = row["MAHD"].ToString();
            Masp = row["MASP"].ToString();
            Ngaylap = DateTime.Parse(row["NGAYLAPHD"].ToString());
            Tongtien = float.Parse(row["TONGTIEN"].ToString());
            Phuongthuc = row["PHUONGTHUC"].ToString();
        }
    }
}
