using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.DAL
{
    internal class NhanVienDAL
    {
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NhanVienDAL();
                }
                return instance;
            }
            private set => instance = value;
        }

        public DTO.NHANVIEN layThongTinNhanVien(string tenTk, string matKhau)
        {
            DTO.NHANVIEN nv;

            string query = "SELECT * FROM NHANVIEN WHERE TENTK = @TENTK AND MATKHAU = @MATKHAU AND TRANGTHAI = 1";

            List<object> parameters = new List<object>();

            parameters.Add(tenTk);

            parameters.Add(matKhau);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            nv = new DTO.NHANVIEN(table.Rows[0]);

            return nv;
        }

        public int doiMatKhau(string matKhauMoi, int id)
        {
            int result = 0;

            string query = "UPDATE NHANVIEN SET MATKHAU = @MATKHAU WHERE ID = @ID";

            List<object> parameters = new List<object>();

            parameters.Add(matKhauMoi);

            parameters.Add(id);

            result = DataProvider.Instance.executeNonQuery(query, parameters);

            return result;
        }

        public List<DTO.NHANVIEN> layDanhSachNhanVien()
        {
            List<DTO.NHANVIEN> listNV = new List<DTO.NHANVIEN>();

            string query = "SELECT * FROM NHANVIEN WHERE TRANGTHAI != 0";

            DataTable table = DataProvider.Instance.excuteReader(query);

            foreach (DataRow row in table.Rows)
            {
                DTO.NHANVIEN nv = new DTO.NHANVIEN(row);
                listNV.Add(nv);
            }

            return listNV;
        }
        //      Họ tên
        //      Giới tính
        //      Địa chỉ
        //      Email
        //      Loại tài khoản
        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoHoTen(string hoTen)
        {
            List<DTO.NHANVIEN> listNV = new List<DTO.NHANVIEN>();

            string query = "SELECT * FROM NHANVIEN WHERE HOTEN LIKE N'%' + @HOTEN + '%' ";

            List<object> parameters = new List<object>();

            parameters.Add(hoTen);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            foreach (DataRow row in table.Rows)
            {
                DTO.NHANVIEN nv = new DTO.NHANVIEN(row);
                listNV.Add(nv);
            }

            return listNV;
        }

        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoGioiTinh(string gioiTinh)
        {
            List<DTO.NHANVIEN> listNV = new List<DTO.NHANVIEN>();

            string query = "SELECT * FROM NHANVIEN WHERE GIOITINH LIKE N'%' + @GIOITINH + '%' ";

            List<object> parameters = new List<object>();

            parameters.Add(gioiTinh);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            foreach (DataRow row in table.Rows)
            {
                DTO.NHANVIEN nv = new DTO.NHANVIEN(row);
                listNV.Add(nv);
            }

            return listNV;
        }

        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoDiaChi(string diaChi)
        {
            List<DTO.NHANVIEN> listNV = new List<DTO.NHANVIEN>();

            string query = "SELECT * FROM NHANVIEN WHERE DIACHI LIKE N'%' + @DIACHI + '%' ";

            List<object> parameters = new List<object>();

            parameters.Add(diaChi);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            foreach (DataRow row in table.Rows)
            {
                DTO.NHANVIEN nv = new DTO.NHANVIEN(row);
                listNV.Add(nv);
            }

            return listNV;
        }

        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoEmail(string email)
        {
            List<DTO.NHANVIEN> listNV = new List<DTO.NHANVIEN>();

            string query = "SELECT * FROM NHANVIEN WHERE EMAIL LIKE N'%' + @EMAIL + '%' ";

            List<object> parameters = new List<object>();

            parameters.Add(email);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            foreach (DataRow row in table.Rows)
            {
                DTO.NHANVIEN nv = new DTO.NHANVIEN(row);
                listNV.Add(nv);
            }

            return listNV;
        }

        public List<DTO.NHANVIEN> hienThiDsTimKiemTheoTenTaiKhoan(string tenTaiKhoan)
        {
            List<DTO.NHANVIEN> listNV = new List<DTO.NHANVIEN>();

            string query = "SELECT * FROM NHANVIEN WHERE TENTK LIKE N'%' + @TENTK + '%' ";

            List<object> parameters = new List<object>();

            parameters.Add(tenTaiKhoan);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            foreach (DataRow row in table.Rows)
            {
                DTO.NHANVIEN nv = new DTO.NHANVIEN(row);
                listNV.Add(nv);
            }

            return listNV;
        }

        public DTO.NHANVIEN layThongTinNhanVienBangId(int id)
        {
            string query = "SELECT * FROM NHANVIEN WHERE ID = @ID";

            List<object> parameters = new List<object>();

            parameters.Add(id);

            DataTable table = DataProvider.Instance.excuteReader(query, parameters);

            return new DTO.NHANVIEN(table.Rows[0]);
        }

        public int capNhatThongTinNhanVien(DTO.NHANVIEN nv)
        {
            string query = "UPDATE NHANVIEN SET ANH = @ANH , HOTEN = @HOTEN , NGSINH = @NGSINH , GIOITINH = @GIOITINH , EMAIL = @EMAIL , "
                + "SDT = @SDT , DIACHI = @DIACHI , MATKHAU = @MATKHAU , LUONG = @LUONG , LOAITAIKHOAN = @LOAITAIKHOAN WHERE ID = @ID";

            List<object> parameters = new List<object>();

            parameters.Add(nv.Anh);
            parameters.Add(nv.HoTen);
            parameters.Add(nv.NgSinh);
            parameters.Add(nv.GioiTinh);
            parameters.Add(nv.Email);
            parameters.Add(nv.Sdt);
            parameters.Add(nv.DiaChi);
            parameters.Add(nv.MatKhau);
            parameters.Add(nv.Luong);
            parameters.Add(nv.LoaiTaiKhoan);
            parameters.Add(nv.Id);

            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }


        public int xoaNhanVien(int id)
        {


            string query = "UPDATE NHANVIEN SET TRANGTHAI = 0 WHERE ID = @ID ";
            List<object> parmeter = new List<object>();
            parmeter.Add(id);

            return DAL.DataProvider.Instance.executeNonQuery(query, parmeter);
        }

        public int themNhanVien(DTO.NHANVIEN nv)
        {
            string query = "INSERT INTO NHANVIEN (TENTK , MATKHAU , HOTEN , ANH , GIOITINH , NGSINH ," +
                " NGAYVAOLAM , SDT , DIACHI , EMAIL , LUONG , TRANGTHAI , LOAITAIKHOAN )" +

                " VALUES ( @TENTK , @MATKHAU , @HOTEN , @ANH , @GIOITINH , @NGSINH , @NGAYVAOLAM , @SDT ," +
                " @DIACHI , @EMAIL , @LUONG , @TRANGTHAI , @LOAITAIKHOAN )";

            List<object> parameters = new List<object>();

            parameters.Add(nv.TenTK);
            parameters.Add(nv.MatKhau);
            parameters.Add(nv.HoTen);
            parameters.Add(nv.Anh);
            parameters.Add(nv.GioiTinh);
            parameters.Add(nv.NgSinh);
            parameters.Add(nv.NgayVaoLam);
            parameters.Add(nv.Sdt);
            parameters.Add(nv.DiaChi);
            parameters.Add(nv.Email);
            parameters.Add(nv.Luong);
            parameters.Add(nv.TrangThai);
            parameters.Add(nv.LoaiTaiKhoan);

            return DAL.DataProvider.Instance.executeNonQuery(query, parameters);
        }

        public int timTraAnhTrungLap(string anh)
        {
            string query = " SELECT COUNT (*) FROM NHANVIEN WHERE ANH = @ANH ";
            List<object> parameter = new List<object>();
            parameter.Add(anh);

            int count = Convert.ToInt32(DAL.DataProvider.Instance.executeScalar(query, parameter));

            return count;
        }

        public bool ktraTuoi(DateTime ngaySinh)
        {
            bool kq = false;
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (tuoi >= 18)
            {
                kq = true;
            }
            return kq;
        }

        public List<string> layDsTenNv()
        {
            List<string> listNV = new List<string>();

            string query = "SELECT HOTEN FROM NHANVIEN";

            DataTable table = DataProvider.Instance.excuteReader(query);

            foreach (DataRow row in table.Rows)
            {
                listNV.Add(row["HOTEN"].ToString());
            }
            listNV.Add("None");
            return listNV;
        }
    }
}
