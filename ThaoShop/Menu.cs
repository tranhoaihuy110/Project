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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelbody.Controls.Add(childForm);
            panelbody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChu());
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThanhToan());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThanhToan());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NCC());
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NCC());
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SP());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SP());
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NV());
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NV());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChu());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PN());
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PN());
        }
    }
}
