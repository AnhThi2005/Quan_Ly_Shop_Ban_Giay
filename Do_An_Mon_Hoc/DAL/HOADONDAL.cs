using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DAL
{
    internal class HOADONDAL
    {
        public static HOADONDAL instance;
        public static HOADONDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HOADONDAL();
                }
                return instance;
            }
            private set => instance = value;
        }
        public List<DTO.HOADON> GetList()
        {
            List<DTO.HOADON> list = new List<DTO.HOADON>();
            string query = "SELECT *  FROM KHACHHANG AS KH INNER JOIN HOADON AS HD ON KH.MAKH=HD.MAKH INNER JOIN CHITIETHOADON  AS CT ON HD.MAHD=CT.MAHD INNER JOIN SANPHAM AS SP ON CT.MASP=SP.MASP";
            System.Data.DataTable d = DataProvider.Instance.excuteReader(query);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.HOADON ql = new DTO.HOADON(item);
                list.Add(ql);
            }
            return list;
        }
        public List<DTO.HOADON> loadhd()
        {
            List<DTO.HOADON> list = new List<DTO.HOADON>();
            string query = "SELECT *  FROM  HOADON ";
            System.Data.DataTable d = DataProvider.Instance.excuteReader(query);
            foreach (System.Data.DataRow item in d.Rows)
            {
                DTO.HOADON ql = new DTO.HOADON(item);
                list.Add(ql);
            }
            return list;
        }
        public int suaHD(DTO.HOADON hd)
        {
            List<object> parameters = new List<object>();
            string query = @"UPDATE hoadon set NGAYLAPHD = @NGAYLAPHD, TONGTIEN=@TONGTIEN where mahd=@mahd";

            parameters.Add(hd.NgaylapHD);
            parameters.Add(hd.Tongtien);
            parameters.Add(hd.MaHD);




            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public List<DTO.HOADON> SearchHD(string searchma)
        {
            List<DTO.HOADON> list = new List<DTO.HOADON>();
            string query = "SELECT *  FROM KHACHHANG KH INNER JOIN HOADON HD ON KH.MAKH=HD.MAKH INNER JOIN CHITIETHOADON  CT ON HD.MAHD=CT.MAHD INNER JOIN SANPHAM  SP ON CT.MASP=SP.MASP  where HD.MAHD like @searchma";


            List<object> parameters = new List<object>();
            parameters.Add("%" + searchma + "%");


            DataTable d = DataProvider.Instance.excuteReader(query, parameters);
            foreach (DataRow item in d.Rows)
            {
                DTO.HOADON ql = new DTO.HOADON(item);
                list.Add(ql);
            }
            return list;
        }
        public int xoaHD(string maHD)
        {
            string query = "UPDATE hoadon SET ngaylaphd=NULL, TONGTIEN=NULL,MAKH=NULL WHERE MAHD=@maHD";
            List<object> parameters = new List<object>();
            parameters.Add(maHD);
            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }
        public int themHD(DTO.HOADON hd)
        {
            string query = "INSERT INTO HOADON (MAHD, NGAYLAPHD, TONGTIEN) VALUES (@MAHD, @NGAYLAPHD, @TONGTIEN)";
            List<object> parameters = new List<object>();
            parameters.Add(hd.MaHD);
            parameters.Add(hd.NgaylapHD);
            parameters.Add(hd.Tongtien);
            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);



        }

    }
}
