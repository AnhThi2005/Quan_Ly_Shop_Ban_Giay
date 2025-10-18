using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    public class DONHANG
    {
        private string maKH;
        private string maHD;
        private string hoTen;
        private DateTime ngayLap;
        private string tongTien;

        
        public DONHANG() { }    
        public DONHANG(DataRow row)
        {
            MaKH = row["MAKH"].ToString();
            MaHD = row["MAHD"].ToString();
            //NgayLap = DateTime.Parse(row["NGAYLAPHD"].ToString());
            if (row["NGAYLAPHD"] == DBNull.Value || string.IsNullOrWhiteSpace(row["NGAYLAPHD"].ToString()))
            {
                NgayLap = DateTime.MinValue; // hoặc DateTime.Now tùy bạn muốn
            }
            else
            {
                NgayLap = DateTime.Parse(row["NGAYLAPHD"].ToString());
            }

            TongTien = Convert.ToDecimal(row["TONGTIEN"]).ToString("N0");
            HoTen = row["HOTEN"].ToString();
        }

        public string MaKH { get => maKH; set => maKH = value; }
        public string MaHD { get => maHD; set => maHD = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }

        public string TongTien { get => tongTien; set => tongTien = value; }
    }
}
