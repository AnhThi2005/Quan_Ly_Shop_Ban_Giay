using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Mon_Hoc.BLL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc
{
    public partial class UC_SanPham_NV : UserControl
    {
        private ProductBLL employeeProcde = new ProductBLL();
        DTO.SANPHAM sp = new DTO.SANPHAM();
        string fixPath = Path.Combine(Application.StartupPath, "Images");
        private string maSP;
        private List<SANPHAM> dsSanPham = BLL.ProductBLL.Instance.hienThiDsSanPham();

        public UC_SanPham_NV()
        {
            InitializeComponent();
            flowLayoutPanel2.VisibleChanged += flowLayoutPanel2_VisibleChanged;
            cbB_maNCC.DataSource = NhaCungCapBLL.Instance.layDsTenNCC();
            capnhatflowLayoutPanel(dsSanPham);
        }
        private void loadSanPham(List<SANPHAM> dsSanPham)
        {
            
        }
        private void btn_taiLen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Chon anh";

            ofd.Filter = "Hinh anh|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);

                string sourcePath = Path.Combine(Application.StartupPath, "Images");

                if (!Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(sourcePath);
                }

                Console.WriteLine(ofd.FileName);

                string imageName = Path.GetFileName(ofd.FileName);

                Console.WriteLine(imageName);

                string destPath = Path.Combine(sourcePath, imageName);

                if (!File.Exists(destPath))
                {
                    File.Copy(ofd.FileName, destPath, true);
                }
                pictureBox1.Tag = imageName;
            }
        }


        private void capnhatflowLayoutPanel(List<SANPHAM> dsSanPham)
        {
            try
            {
                if (flowLayoutPanel2.Visible)
                {
                    //Tạm dừng tự động bố trí ctrl
                    flowLayoutPanel2.SuspendLayout();

                    // Xóa trước khi thêm mới
                    flowLayoutPanel2.Controls.Clear(); 

                    foreach (SANPHAM sp in dsSanPham)
                    {
                        productCard card = new productCard();

                        card.productName = sp.TenSP ?? "Không tên";

                        card.maSP = sp.MaSP;

                        if (!string.IsNullOrEmpty(sp.HinhAnh))
                        {
                            string path = Path.Combine(Application.StartupPath, "Images");

                            card.productImage = Image.FromFile(path + "\\" + sp.HinhAnh);
                        }
                        else
                        {
                            card.productImage = null;
                        }

                        card.Click += ProductCard_Click;

                        card.Controls["lbl_tensp"].Click += ProductCard_Click;

                        card.Controls["pictureBox1"].Click += ProductCard_Click;

                        flowLayoutPanel2.Controls.Add(card);
                    }
                    //Bật bố trí giao diện sau khi thêm/sửa ctrl
                    flowLayoutPanel2.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void flowLayoutPanel2_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void ProductCard_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;

            while (clickedControl != null && !(clickedControl is productCard))
            {
                clickedControl = clickedControl.Parent;
            }

            productCard clickedCard = clickedControl as productCard;
            if (clickedCard != null)
            {
                maSP = clickedCard.maSP;

                produceInformation(maSP);
            }
        }

        private void produceInformation(string maSp)
        {
            sp = employeeProcde.hienThiThongTinSP(maSP);

            if (sp.HinhAnh != "")
                pictureBox1.Image = Image.FromFile(fixPath + "\\" + sp.HinhAnh);

            txt_maSP.Text = sp.MaSP;

            txt_tenSP.Text = sp.TenSP;

            txt_chatLieu.Text = sp.ChatLieu;

            nmr_soLuong.Value = sp.SoLuong;

            txt_giaNhap.Text = sp.DonGiaNhap.ToString();

            txt_giaBan.Text = sp.DonGiaBan.ToString();

            txt_ghichu.Text = sp.GhiChu;

            cbB_maNCC.Text = NhaCungCapBLL.Instance.layTenTuMaNCC(sp.MaNCC);
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string tenSP = txt_timKiem.Text;

            sp.TenSP = tenSP;

            List<SANPHAM> dsTimKiem = employeeProcde.hienThiDSTimKiem(tenSP);

            capnhatflowLayoutPanel(dsTimKiem);
        }
    }
}
