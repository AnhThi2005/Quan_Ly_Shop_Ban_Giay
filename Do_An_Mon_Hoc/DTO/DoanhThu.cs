using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DTO
{
    internal class DoanhThu
    {
        private string mathanhtoan;
        private string phuongthuc;
        private double doanhthu;


        public string Mathanhtoan { get => mathanhtoan; set => mathanhtoan = value; }
        public string Phuongthuc { get => phuongthuc; set => phuongthuc = value; }
        public double Doanhthu { get => doanhthu; set => doanhthu = value; }

        public DoanhThu() { }
        public DoanhThu(DataRow row)
        {
            Mathanhtoan = row["mathanhtoan"].ToString();
            Phuongthuc = row["phuongthuc"].ToString();
            Doanhthu = double.Parse(row["tongdoanhthu"].ToString());
        }
    }
}
