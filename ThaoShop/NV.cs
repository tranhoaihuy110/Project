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
    public partial class NV : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();
        public NV()
        {
            InitializeComponent();
        }

        private void NV_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT * FROM NHANVIEN";
            dataGridView1.DataSource = ketnoi.Execute(query);
        }
    }
}
