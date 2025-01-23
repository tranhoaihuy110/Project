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
    public partial class TrangChu : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT * FROM CHITIETDONHANG";
            dataGridView1.DataSource = ketnoi.Execute(query);
            txtGia.Clear();
            txtMa.Clear();
            txtMact.Clear();
            txtMasp.Clear();
            txtSoluong.Clear();
            txtTim.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string masp = txtMasp.Text;
            string sl = txtSoluong.Text;
            string gia = txtGia.Text;
            string mact = txtMact.Text;
            string query = "INSERT INTO CHITIETDONHANG (MADONHANG, MASANPHAM, SOLUONG, GIA)  VALUES(N'" + ma + "',N'" + masp + "',N'" + sl + "',N'" + gia + "')";
            ketnoi.ExecuteNonQuery(query);
            loaddata();
            MessageBox.Show("Đã Thêm Đơn Hàng Thành Công");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mact = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string ma = txtMa.Text;
                string masp = txtMasp.Text;
                string sl = txtSoluong.Text;
                string gia = txtGia.Text;

                string query = "UPDATE CHITIETDONHANG SET MADONHANG = N'" + ma + "', MASANPHAM = N'" + masp + "', SOLUONG = N'" + sl + "', GIA = N'" + gia + "' WHERE MACHITIET = N'" + mact + "'";

                ketnoi.ExecuteNonQuery(query);
                loaddata();
                MessageBox.Show("Đã Cập Nhật Đơn Hàng Thành Công");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để được cập nhật!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mact = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE FROM CHITIETDONHANG WHERE MACHITIET = N'" + mact + "'";
                ketnoi.ExecuteNonQuery(query);
                loaddata();
                MessageBox.Show("Đã Xóa Đơn Hàng Thành Công");

            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để được xóa!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ma = txtTim.Text;
            string query = $"SELECT * FROM CHITIETDONHANG WHERE MADONHANG LIKE '%{ma}%'";
            if (!string.IsNullOrEmpty(query))
            {
                DataTable result = ketnoi.Execute(query);
                if (result.Rows.Count > 0)
                {
                    dataGridView1.DataSource = result;
                    MessageBox.Show("Tìm thấy dữ liệu.");
                    txtTim.Clear();
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Không tìm thấy dữ liệu.");
                    txtTim.Clear();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tùy chọn tìm kiếm.");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMact.Text = row.Cells[0].Value.ToString();
                txtMa.Text = row.Cells[1].Value.ToString();
                txtMasp.Text = row.Cells[2].Value.ToString();
                txtSoluong.Text = row.Cells[3].Value.ToString();
                txtGia.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
