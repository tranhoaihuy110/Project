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
    public partial class PN : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();
        public PN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PN_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT * FROM CHITIETPHIEUNHAP";
            dataGridView1.DataSource = ketnoi.Execute(query);
            txtGia.Clear();
            txtMa.Clear();
            txtMact.Clear();
            txtMasp.Clear();
            txtSoluong.Clear();
            txtTim.Clear();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string masp = txtMasp.Text;
            string sl = txtSoluong.Text;
            string gia = txtGia.Text;
            string mact = txtMact.Text;
            string query = "INSERT INTO CHITIETPHIEUNHAP (MAPHIEUNHAP, MASANPHAM, SOLUONG, GIA)  VALUES(N'" + ma +  "',N'" + masp + "',N'" + sl + "',N'" + gia + "')";
            ketnoi.ExecuteNonQuery(query);
            loaddata();
            MessageBox.Show("Đã Thêm Phiếu Nhập Thành Công");
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mact = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string ma = txtMa.Text;
                string masp = txtMasp.Text;
                string sl = txtSoluong.Text;
                string gia = txtGia.Text;

                string query = "UPDATE CHITIETPHIEUNHAP SET MAPHIEUNHAP = N'" + ma + "', MASANPHAM = N'" + masp + "', SOLUONG = N'" + sl + "', GIA = N'" + gia + "' WHERE MACHITIET = N'" + mact + "'";

                ketnoi.ExecuteNonQuery(query);
                loaddata();
                MessageBox.Show("Đã Cập Nhật Phiếu Nhập Thành Công");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để được cập nhật!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mact = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE FROM CHITIETPHIEUNHAP WHERE MACHITIET = N'" + mact + "'";
                ketnoi.ExecuteNonQuery(query);
                loaddata();
                MessageBox.Show("Đã Xóa Phiếu Nhập Thành Công");
             
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để được xóa!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ma = txtTim.Text;
            string query = $"SELECT * FROM CHITIETPHIEUNHAP WHERE MAPHIEUNHAP LIKE '%{ma}%'";
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
