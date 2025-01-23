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
    public partial class ThanhToan : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();
        public ThanhToan()
        {
            InitializeComponent();
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT * FROM THANHTOAN";
            dataGridView1.DataSource = ketnoi.Execute(query);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMatt.Text;
            string madh = txtMa.Text;
            string manv = txtManv.Text;
            string ngaytt = txtNgay.Text;
            string tien = txtTien.Text;
            string query = "INSERT INTO THANHTOAN (MADONHANG, MANHANVIEN, NGAYTHANHTOAN,TONGTIEN)  VALUES(N'" + madh + "',N'" + manv + "',N'" + ngaytt + "',N'" + tien + "')";
            ketnoi.ExecuteNonQuery(query);
            loaddata();
            MessageBox.Show("Đã Thêm Thanh Toán Thành Công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
