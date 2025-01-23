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
    public partial class KhachHang : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT * FROM KHACHHANG";
            dataGridView1.DataSource = ketnoi.Execute(query);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
                txtTen.Text = row.Cells[1].Value.ToString();
                txtMail.Text = row.Cells[2].Value.ToString();
                txtDT.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string mail = txtMail.Text;
            string sdt = txtDT.Text;
            string diachi = txtDiaChi.Text;
            string query = "INSERT INTO KHACHHANG (TEN, EMAIL, DIENTHOAI, DIACHI)" + "VALUES(N'" + ten + "',N'" + mail + "',N'" + sdt + "',N'" + diachi + "')";
            ketnoi.ExecuteNonQuery(query);
            loaddata();
            MessageBox.Show("Đã Thêm Khách Hàng Thành Công");
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtDT.Clear();
            txtMail.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string ma = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string ten = txtTen.Text;
                string mail = txtMail.Text;
                string sdt = txtDT.Text;
                string diachi = txtDiaChi.Text;

                string query = "UPDATE KHACHHANG SET TEN = N'" + ten + "', EMAIL = N'" + mail + "', DIENTHOAI = N'" + sdt + "', DIACHI = N'" + diachi + "' WHERE MAKHACHHANG = N'" + ma + "'";


                ketnoi.ExecuteNonQuery(query);

                loaddata();
                MessageBox.Show("Đã Cập Nhật Khách Hàng Thành Công");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để được cập nhật!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string ma = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE FROM KHACHHANG WHERE MAKHACHHANG = N'" + ma + "'";
                ketnoi.ExecuteNonQuery(query);
                loaddata();
                MessageBox.Show("Đã Xóa Khách Hàng Thành Công");
                txtMail.Clear();
                txtMa.Clear();
                txtDiaChi.Clear();
                txtTen.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để được xóa!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
           
            string ma = txtTim.Text;
            string query = $"SELECT * FROM KHACHHANG WHERE MAKHACHHANG LIKE '%{ma}%'";
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
    }
}
