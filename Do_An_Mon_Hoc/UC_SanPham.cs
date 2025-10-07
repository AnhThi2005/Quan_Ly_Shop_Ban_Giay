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
using Do_An_Mon_Hoc.DAL;
using Do_An_Mon_Hoc.DTO;

namespace Do_An_Mon_Hoc
{
    public partial class UC_SanPham : UserControl
    {
        private ProductBLL employeeProcde = new ProductBLL();
        DTO.SANPHAM sp = new DTO.SANPHAM();
        string fixPath = Path.Combine(Application.StartupPath, "Images");
        private string maSP;
        

        public UC_SanPham()
        {
            InitializeComponent();
            flowLayoutPanel2.VisibleChanged += flowLayoutPanel2_VisibleChanged;
            cbB_maNCC.DataSource = NhaCungCapBLL.Instance.layDsTenNCC();
            //capnhatflowLayoutPanel(BLL.ProductBLL.Instance.hienThiDsSanPham());
            List<SANPHAM> dsSanPham = BLL.ProductBLL.Instance.hienThiDsSanPham();

            capnhatflowLayoutPanel(dsSanPham);
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

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            
        }

        private void loadSanPham()
        {
        }

        private void capnhatflowLayoutPanel(List<SANPHAM> dsSanPham)
        {
            try
            {
                //Nếu flowlayout hiển thị visibale = true
                if (flowLayoutPanel2.Visible)
                {
                    //Tạm dừng tự động bố trí ctrl
                    flowLayoutPanel2.SuspendLayout();

                    // Xóa trước khi thêm mới
                    flowLayoutPanel2.Controls.Clear(); 

                    foreach (SANPHAM sp in dsSanPham)
                    {
                        productCard card = new productCard();

                        card.productName = sp.TenSP;

                        card.maSP = sp.MaSP;

                        if (!string.IsNullOrEmpty(sp.HinhAnh))
                        {
                            string path = Path.Combine(Application.StartupPath, "Images", sp.HinhAnh);

                            if (File.Exists(path))
                            {
                                card.productImage = Image.FromFile(path);
                            }
                            //Else có thể gán ảnh mặc định: 
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox1_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel2_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void ProductCard_Click(object sender, EventArgs e)
        {
            //Ép sender sang cho ctrl
            Control clickedControl = sender as Control;

            //Duyệt tìm phần tử cha
            while (clickedControl != null && !(clickedControl is productCard))
            {
                clickedControl = clickedControl.Parent;
            }

            
            productCard clickedCard = clickedControl as productCard;
            if (clickedCard != null)
            {
                //Lấy mã sp từ productCard
                maSP = clickedCard.maSP;

                produceInformation(maSP);
            }
        }

        private void produceInformation(string maSp)
        {
            sp = employeeProcde.hienThiThongTinSP(maSP);

            if (!string.IsNullOrEmpty(sp.HinhAnh))
            {
                if (sp.HinhAnh != "")
                    pictureBox1.Image = Image.FromFile(fixPath + "\\" + sp.HinhAnh);
                else
                {
                    pictureBox1.Image = null;
                    pictureBox1.Tag = null;
                    return;
                }

                //string path = Path.Combine(Application.StartupPath, "Images", sp.HinhAnh);
                //if (File.Exists(path))
                //{
                //    pictureBox1.Image = Image.FromFile(path);
                //    pictureBox1.Tag = sp.HinhAnh;
                //}
                //else
                //{
                //    pictureBox1.Image = null;
                //    pictureBox1.Tag = null;
                //}
            }
            else
            {
                pictureBox1.Image = null;
                pictureBox1.Tag = null;
            }

            txt_maSP.Text = sp.MaSP;

            txt_tenSP.Text = sp.TenSP;

            txt_chatLieu.Text = sp.ChatLieu;

            nmr_soLuong.Value = sp.SoLuong;

            txt_giaNhap.Text = sp.DonGiaNhap.ToString();

            txt_giaBan.Text = sp.DonGiaBan.ToString();

            txt_ghichu.Text = sp.GhiChu;

            cbB_maNCC.Text = NhaCungCapBLL.Instance.layTenTuMaNCC(sp.MaNCC);
        }

        private void btn_themSP_Click(object sender, EventArgs e)
        {
            int result = 0;

            try
            {
                string imageName = pictureBox1.Tag?.ToString() ?? "";

                sp.HinhAnh = !string.IsNullOrEmpty(imageName) ? imageName : sp.HinhAnh;

                sp.TenSP = txt_tenSP.Text;

                sp.ChatLieu = txt_chatLieu.Text;

                sp.SoLuong = Int32.Parse(nmr_soLuong.Value.ToString());

                sp.DonGiaNhap = Double.Parse(txt_giaNhap.Text);

                sp.DonGiaBan = Double.Parse(txt_giaBan.Text);

                sp.GhiChu = txt_ghichu.Text;

                sp.MaNCC = BLL.NhaCungCapBLL.Instance.layMNCCTuTen(cbB_maNCC.SelectedItem.ToString());

                result = employeeProcde.themThongTinSanPhamMoi(sp);
                if (result == 0)
                    MessageBox.Show("Bạn đã thêm mới thất bại");
                else
                {
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    List<SANPHAM> dsSanPham = BLL.ProductBLL.Instance.hienThiDsSanPham();
                    capnhatflowLayoutPanel(dsSanPham);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin");
                return;
            }

        }

        private void btn_capNhat_Click(object sender, EventArgs e)
        {
            int result = 0;
            try
            {
                string imageName;
                if (pictureBox1.Tag == null)
                {
                    imageName = sp.HinhAnh;
                }
                else
                {
                    imageName = pictureBox1.Tag.ToString();
                }
                sp.HinhAnh = imageName;

                sp.MaSP = maSP;
               
                //MessageBox.Show(imageName);
                sp.TenSP = txt_tenSP.Text;

                sp.ChatLieu = txt_chatLieu.Text;

                sp.SoLuong = Int32.Parse(nmr_soLuong.Value.ToString());

                sp.DonGiaNhap = Double.Parse(txt_giaNhap.Text);

                sp.DonGiaBan = Double.Parse(txt_giaBan.Text);

                sp.MaNCC = BLL.NhaCungCapBLL.Instance.layMNCCTuTen(cbB_maNCC.SelectedItem.ToString());

                sp.GhiChu = txt_ghichu.Text;

                result = employeeProcde.capNhatThongTinSanPham(sp);
                if (result == 0)
                    MessageBox.Show("Bạn đã cập nhật thất bại");
                else
                {
                    List<SANPHAM> dsSanPham = BLL.ProductBLL.Instance.hienThiDsSanPham();
                    MessageBox.Show("Bạn đã cập nhật thành công");
                    capnhatflowLayoutPanel(dsSanPham);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin");
                return;
            }
        }

        private void btn_xoaSP_Click(object sender, EventArgs e)
        {
            sp.MaSP = maSP;
            int result = 0;

            result = employeeProcde.xoaThongTinSanPham(sp);

            if (result == 0)
                MessageBox.Show("Xóa sản phẩm không thành công");
            else
            {
                List<SANPHAM> dsSanPham = BLL.ProductBLL.Instance.hienThiDsSanPham();
                MessageBox.Show("Xóa sản phẩm thành công");
                capnhatflowLayoutPanel(dsSanPham);
            }
        }

        private void btn_taiLai_Click(object sender, EventArgs e)
        {
            List<SANPHAM> dsSanPham = BLL.ProductBLL.Instance.hienThiDsSanPham();
            capnhatflowLayoutPanel(dsSanPham);
            pictureBox1.Image = null;
            pictureBox1.Tag = null;
            txt_maSP.Text = "";
            txt_tenSP.Text = "";
            cbB_maNCC.Text = "";
            nmr_soLuong.Value = 0;
            txt_giaNhap.Text = "";
            txt_giaBan.Text = "";
            txt_chatLieu.Text = "";
            txt_ghichu.Text = "";
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
