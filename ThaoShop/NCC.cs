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
    public partial class NCC : Form
    {
        ketnoicsdl ketnoi = new ketnoicsdl();
        public NCC()
        {
            InitializeComponent();
        }

        private void NCC_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT * FROM NHACUNGCAP";
            dataGridView1.DataSource = ketnoi.Execute(query);
        }
    }
}
