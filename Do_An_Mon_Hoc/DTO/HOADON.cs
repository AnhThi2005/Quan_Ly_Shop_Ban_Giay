using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    internal class HOADON
    {
        private string maHD;
        private string tenkh;
        private DateTime ngaylapHD;
        private double tongtien;
        private string makh;
        private int soluong;
        private string masp;
        private string tensp;
        private string chatlieu;
        private double gia;

        public string MaHD { get => maHD; set => maHD = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public DateTime NgaylapHD { get => ngaylapHD; set => ngaylapHD = value; }
        public double Tongtien { get => tongtien; set => tongtien = value; }
        public string Makh { get => makh; set => makh = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Chatlieu { get => chatlieu; set => chatlieu = value; }
        public double Gia { get => gia; set => gia = value; }

        public HOADON()
        {

        }
        public HOADON(DataRow row)
        {
            MaHD = row["MAHD"].ToString();
            Tenkh = row["TENKH"].ToString();
            NgaylapHD = DateTime.Parse(row["NGAYLAPHD"].ToString());
            Tongtien = float.Parse(row["TONGTIEN"].ToString());
            Makh = row["MAKH"].ToString();
            Soluong = int.Parse(row["SOLUONG"].ToString());
            Masp = row["MASP"].ToString();
            Tensp = row["Tensp"].ToString();
            Chatlieu = row["chatlieu"].ToString();
            Gia = double.Parse(row["Gia"].ToString());





        }
    }

}
