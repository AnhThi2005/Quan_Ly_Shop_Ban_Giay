using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Mon_Hoc.BLL
{
    internal class LoginBLL
    {
        public DTO.NHANVIEN checkLogin(string tenTk, string matKhau)
        {
            try
            {
                DTO.NHANVIEN nv = DAL.NhanVienDAL.Instance.layThongTinNhanVien(tenTk, matKhau);

                return nv;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
