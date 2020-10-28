using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace BIPIT_5_CLIENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var service = new ServiceReference1.ServiceClient();
            dataGridView1.DataSource = service.GetData().Tables["Moving"];
           // comboBox1.DataSource = service.GetDataExhibits().Tables["Exhibits"];
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
