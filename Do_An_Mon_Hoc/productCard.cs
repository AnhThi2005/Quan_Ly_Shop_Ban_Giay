using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Mon_Hoc
{
    public partial class productCard : UserControl
    {
        public productCard()
        {
            InitializeComponent();
           
            //lbl_tensp.Left = pictureBox1.Left + (pictureBox1.Width - lbl_tensp.Width) / 2;
            this.Size = new Size(74, 106);

        }
        public string maSP
        {
            get; set;
        }
        public Image productImage
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        public string productName
        {
            get => lbl_tensp.Text;
            set => lbl_tensp.Text = value;
        }
        

    }
}
