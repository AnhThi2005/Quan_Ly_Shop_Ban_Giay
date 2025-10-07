using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Do_An_Mon_Hoc.DTO
{
    internal class KHACHHANG
    {
        private string maKH;
        private string tenTK;
        private string matKhau;
        private string tenKH;
        private string sdt;
        private string diaChi;
        private string email;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenTK { get => tenTK; set => tenTK = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }

        public KHACHHANG()
        {
        }

        public KHACHHANG(DataRow row)
        {
            MaKH = row["MAKH"].ToString();
            TenTK = row["TENTK"].ToString();
            MatKhau = row["MATKHAU"].ToString();
            TenKH = row["TENKH"].ToString();
            Sdt = row["SDT"].ToString();
            DiaChi = row["DIACHI"].ToString();
            Email = row["EMAIL"].ToString();


        }
    }
}
