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
    public partial class SP : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();
        public SP()
        {
            InitializeComponent();
        }

        private void SP_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT * FROM SANPHAM";
            dataGridView1.DataSource = ketnoi.Execute(query);
        }
    }
}
