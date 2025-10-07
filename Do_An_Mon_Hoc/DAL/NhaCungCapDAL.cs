using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_An_Mon_Hoc.BLL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc.DAL
{
    internal class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCapDAL();
                return instance;
            }
            private set => instance = value;
        }

        public List<string> layDSTenNCC()
        {
            List<string> list = new List<string>();

            string query = "SELECT TENNCC FROM NHACUNGCAP WHERE TRANGTHAI != 0";

            DataTable table = DataProvider.Instance.excuteReader(query);

            foreach(DataRow row in table.Rows)
            {
                list.Add(row["TENNCC"].ToString());
            }    

            return list;
        } 

        public string layTenNCCTuMa(string maNCC)
        {
            string tenNCC = "";

            string query = "SELECT TENNCC FROM NHACUNGCAP WHERE MANCC = @MANCC";

            List<object> parameters = new List<object>();

            parameters.Add(maNCC);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            tenNCC = table.Rows[0]["TENNCC"].ToString();

            return tenNCC;
        }


        public string layMaNCCTuTen(string tenNCC)
        {
            string maNCC = "";

            string query = "SELECT MANCC FROM NHACUNGCAP WHERE TENNCC = @TENNCC";

            List<object> parameters = new List<object>();

            parameters.Add(tenNCC);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

           maNCC = table.Rows[0]["MANCC"].ToString();

            return maNCC;
        }

        public List<DTO.NHACUNGCAP> layDanhSachNCC()
        {
            List<DTO.NHACUNGCAP> list = new List<DTO.NHACUNGCAP>();
            string query = "Select * from NHACUNGCAP WHERE TRANGTHAI = 1";
            DataTable table = DataProvider.Instance.excuteReader(query);
            foreach (DataRow row in table.Rows)
            {
                DTO.NHACUNGCAP ncc = new DTO.NHACUNGCAP(row);
                list.Add(ncc);
            }
            return list;
        }

        public int themNCC(DTO.NHACUNGCAP ncc)
        {
            string query = "insert into NHACUNGCAP (tenncc, sdt, diachi) " +
                " values ( @TENNCC, @SDT, @DIACHI)";

            List<object> parameters = new List<object>();

            parameters.Add(ncc.TenNcc);
            parameters.Add(ncc.Sdt);
            parameters.Add(ncc.DiaChi);
            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public int capnhatNCC(DTO.NHACUNGCAP ncc)
        {
            string query = "update NHACUNGCAP set TENNCC = @TENNCC, SDT = @SDT, DIACHI = @DIACHI where mancc=@mancc";
            List<object> parameters = new List<object>();

            parameters.Add(ncc.TenNcc);
            parameters.Add(ncc.Sdt);
            parameters.Add(ncc.DiaChi);
            parameters.Add(ncc.MaNcc);
            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public int xoaNCC(DTO.NHACUNGCAP ncc)
        {
            string query = "update NHACUNGCAP set trangthai = 0 where mancc = @mancc ";
            List<object> parameters = new List<object>();
            parameters.Add(ncc.MaNcc);
            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public DTO.NHACUNGCAP laythongtinNcc(string mancc)
        {
            DTO.NHACUNGCAP ncc;
            string query = "select * from NHACUNGCAP where mancc = @mancc";
            List<object> parameters = new List<object>();
            parameters.Add(mancc);
            DataTable table = DataProvider.Instance.excuteReader(query, parameters);
            ncc = new DTO.NHACUNGCAP(table.Rows[0]);
            return ncc;
        }

        public List<DTO.NHACUNGCAP> laydsSearch(string tenncc)
        {
            List<DTO.NHACUNGCAP> list = new List<DTO.NHACUNGCAP>();
            string query = "select * from NHACUNGCAP where tenncc like N'%' + @tenncc + '%'";
            List<object> parameters = new List<object>();
            parameters.Add(tenncc);
            DataTable table = DataProvider.Instance.excuteReader(query, parameters);
            foreach (DataRow row in table.Rows)
            {
                DTO.NHACUNGCAP ncc = new DTO.NHACUNGCAP(row);
                list.Add(ncc);
            }
            return list;
        }

        public List<SANPHAM> danhSachSanPhamNCCCap(string maNCC)
        {
            List<SANPHAM> list = new List<SANPHAM>();

            string query = "SELECT * FROM SANPHAM WHERE MANCC = @MANCC";

            List<object> parameters = new List<object>();

            parameters.Add(maNCC);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            foreach (DataRow row in table.Rows)
            {
                SANPHAM sp = new SANPHAM(row);
                list.Add(sp);
            }
            return list;
        }
    }
}
