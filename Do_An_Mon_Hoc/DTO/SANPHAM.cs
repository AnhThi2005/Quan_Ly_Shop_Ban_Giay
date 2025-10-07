using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    public class SANPHAM
    {
        private string maSP;
        private string tenSP;
        private string chatLieu;
        private int soLuong;
        private double donGiaNhap;
        private double donGiaBan;
        private string ghiChu;
        private string hinhAnh;
        private string maNCC;
        private int trangThai;

        //string query = "SELECT * FROM SANPHAM WHERE isDeleted != 1";
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string ChatLieu { get => chatLieu; set => chatLieu = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }
        public double DonGiaBan { get => donGiaBan; set => donGiaBan = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }

        public SANPHAM()
        {

        }

        public SANPHAM(DataRow row)
        {
            maSP = row["MASP"].ToString();
            tenSP = row["TENSP"].ToString();
            chatLieu = row["CHATLIEU"].ToString();
            soLuong = Int32.Parse(row["SOLUONG"].ToString());
            donGiaNhap = double.Parse(row["DONGIANHAP"].ToString());
            donGiaBan = double.Parse(row["DONGIABAN"].ToString());
            ghiChu = row["GHICHU"].ToString();
            hinhAnh = row["HINHANH"].ToString();
            maNCC = row["MANCC"].ToString();
            trangThai = Int32.Parse(row["TRANGTHAI"].ToString());
        }
    }
}
