using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace Do_An_Mon_Hoc.DTO
{
    public class CHITIETHOADON
    {
        private string maHD;
        private string maSP;
        private string tenSP;
        private int soLuong;
        private string gia;
        private string thanhTien;


        public CHITIETHOADON() { }


        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string Gia { get => gia; set => gia = value; }
        public string ThanhTien { get => thanhTien; set => thanhTien = value; }

        public CHITIETHOADON(DataRow row)
        {
            MaHD = row["MAHD"].ToString();
            MaSP = row["MASP"].ToString();
            TenSP = row["TENSP"].ToString();
            SoLuong = Int32.Parse(row["SOLUONG"].ToString());
            Gia = Convert.ToDecimal(row["GIA"]).ToString("N0");
            ThanhTien = Convert.ToDecimal(row["THANHTIEN"]).ToString("N0");

        }

    }
}
