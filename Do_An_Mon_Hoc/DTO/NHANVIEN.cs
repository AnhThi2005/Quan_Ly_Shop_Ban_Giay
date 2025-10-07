using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    public class NHANVIEN
    {
        private int id;
        private string tenTK;
        private string matKhau;
        private string hoTen;
        private string gioiTinh;
        private DateTime ngSinh;
        private string sdt;
        private string diaChi;
        private string email;
        private int loaiTaiKhoan;
        private DateTime ngayVaoLam;
        private string anh;
        private decimal luong;
        private int trangThai;


        public int Id { get => id; set => id = value; }
        public string TenTK { get => tenTK; set => tenTK = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime NgSinh { get => ngSinh; set => ngSinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string Anh { get => anh; set => anh = value; }
        public decimal Luong { get => luong; set => luong = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }

        public NHANVIEN() { }

        public NHANVIEN(DataRow row)
        {
            Id = Int32.Parse(row["ID"].ToString());
            TenTK = row["TENTK"].ToString();
            matKhau = row["MATKHAU"].ToString();
            hoTen = row["HOTEN"].ToString();
            gioiTinh = row["GIOITINH"].ToString();
            ngSinh = DateTime.Parse(row["NGSINH"].ToString());
            sdt = row["SDT"].ToString();
            diaChi = row["DIACHI"].ToString();
            email = row["EMAIL"].ToString();
            loaiTaiKhoan = Int32.Parse(row["LOAITAIKHOAN"].ToString());
            ngayVaoLam = DateTime.Parse(row["NGAYVAOLAM"].ToString());
            anh = row["ANH"].ToString();
            luong = Decimal.Parse(row["LUONG"].ToString());
            trangThai = Int32.Parse(row["TRANGTHAI"].ToString());
        }
    }
}
