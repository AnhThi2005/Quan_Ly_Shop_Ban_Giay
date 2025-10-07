using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.DAL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc.BLL
{
    internal class NhaCungCapBLL
    {
        private static NhaCungCapBLL instance;
        public static NhaCungCapBLL Instance
        {
            get
            {
                if(instance == null)
                    instance = new NhaCungCapBLL();
                return instance;
            }
            set => instance = value;
        }

        public List<string> layDsTenNCC()
        {
            try
            {
                return NhaCungCapDAL.Instance.layDSTenNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public string layTenTuMaNCC(string maNCC)
        {
            try
            {
                return NhaCungCapDAL.Instance.layTenNCCTuMa(maNCC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public string layMNCCTuTen(string tenNCC)
        {
            try
            {
                return NhaCungCapDAL.Instance.layMaNCCTuTen(tenNCC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public List<DTO.NHACUNGCAP> layDsNCC()
        {
            try
            {
                return NhaCungCapDAL.Instance.layDanhSachNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int themNCC(DTO.NHACUNGCAP ncc)
        {
            try
            {
                return NhaCungCapDAL.Instance.themNCC(ncc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int capnhatNcc(DTO.NHACUNGCAP ncc)
        {
            try
            {
                return NhaCungCapDAL.Instance.capnhatNCC(ncc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int xoaNcc(DTO.NHACUNGCAP ncc)
        {
            try
            {
                return NhaCungCapDAL.Instance.xoaNCC(ncc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public DTO.NHACUNGCAP hienthithongtinncc(string mancc)
        {
            try
            {
                return NhaCungCapDAL.Instance.laythongtinNcc(mancc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<DTO.NHACUNGCAP> hienthidssearch(string tenncc)
        {
            try
            {
                return NhaCungCapDAL.Instance.laydsSearch(tenncc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<SANPHAM> danhSachSanPhamNCCCap(string maNCC)
        {
            try
            {
                return NhaCungCapDAL.Instance.danhSachSanPhamNCCCap(maNCC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
