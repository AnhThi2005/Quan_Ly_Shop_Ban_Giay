using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    internal class HDREPORT
    {
        private string maHD;
        private DateTime ngayLap;
        private string hoTen;
        private string tenSP;
        private int soLuong;
        private string gia;
        private string thanhTien;
        private string tongTien;
        private string tienKhachTra;
        private string tienThua;

        public string MaHD { get => maHD; set => maHD = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string Gia { get => gia; set => gia = value; }
        public string ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
        public string TienKhachTra { get => tienKhachTra; set => tienKhachTra = value; }
        public string TienThua { get => tienThua; set => tienThua = value; }

        public HDREPORT() { 
        }

        public HDREPORT(DataRow row)
        {
            MaHD = row["MAHD"].ToString();
            TenSP = row["TENSP"].ToString();
            SoLuong = Int32.Parse(row["SOLUONG"].ToString());
            Gia = Convert.ToDecimal(row["GIA"]).ToString("N0");
            ThanhTien = Convert.ToDecimal(row["THANHTIEN"]).ToString("N0");
            NgayLap = DateTime.Parse(row["NGAYLAPHD"].ToString());
            TongTien = Convert.ToDecimal(row["TONGTIEN"]).ToString("N0");
            TienKhachTra = Convert.ToDecimal(row["TIENKHACHTRA"]).ToString("N0");
            TienThua = Convert.ToDecimal(row["TIENTHUA"]).ToString("N0");
            HoTen = row["HOTEN"].ToString();
        }
    }
}
