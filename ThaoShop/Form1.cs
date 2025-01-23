using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThaoShop
{
    public partial class Form1 : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBoxTaiKhoan.Text;
            string pass = textBoxMK.Text;
            string query = "EXEC USP_Login @TaiKhoan,@MatKhau ";
            DataTable dt = ketnoi.getLogin(query,user,pass);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG");
               Wellcome menu = new Wellcome();
               menu.Show();
               this.Hide();
            }
            else
            {
                MessageBox.Show("ĐĂNG NHẬP THẤT BẠI");
                textBoxTaiKhoan.Clear();
                textBoxMK.Clear();
            }
        }
    }
}
