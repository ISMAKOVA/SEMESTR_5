using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDown1.Value;
            int M = (int)numericUpDown2.Value;
            var service = new ServiceReference2.WebSoapClient();
            double result = service.Calculate(N, M);
            label3.Text = string.Format("Результат: {0:F4}",result);
        }
    }
}
