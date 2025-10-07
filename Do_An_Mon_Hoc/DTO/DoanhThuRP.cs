using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.BLL;

namespace Do_An_Mon_Hoc.DTO
{
    internal class DoanhThuRP
    {
        private string mathanhtoan;
        private string phuongthuc;
        private DateTime ngaylaphd;
        private double tongdoanhthu;

        public string Mathanhtoan { get => mathanhtoan; set => mathanhtoan = value; }
        public string Phuongthuc { get => phuongthuc; set => phuongthuc = value; }
        public DateTime Ngaylaphd { get => ngaylaphd; set => ngaylaphd = value; }
        public double Tongdoanhthu { get => tongdoanhthu; set => tongdoanhthu = value; }

        public DoanhThuRP() { }
        public DoanhThuRP(DataRow row)
        {
            Mathanhtoan = row["mathanhtoan"].ToString();
            Phuongthuc = row["phuongthuc"].ToString();
            Ngaylaphd = DateTime.Parse(row["ngaylaphd"].ToString());
            Tongdoanhthu = double.Parse(row["tongdoanhthu"].ToString());
        }
    }
}
