using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    public class NHACUNGCAP
    {
        private string maNcc;
        private string tenNcc;
        private string sdt;
        private string diaChi;
        private int trangThai;


        public string MaNcc { get => maNcc; set => maNcc = value; }
        public string TenNcc { get => tenNcc; set => tenNcc = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }

        public NHACUNGCAP()
        { }
        public NHACUNGCAP(DataRow row)
        {
            MaNcc = row["MANCC"].ToString();
            TenNcc = row["TENNCC"].ToString();
            Sdt = row["SDT"].ToString();
            DiaChi = row["DIACHI"].ToString();
            TrangThai = Int32.Parse(row["TRANGTHAI"].ToString());
        }

        
    }
}
