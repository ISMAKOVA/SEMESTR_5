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
            var exhibits = service.GetDataExhibits().Tables["Exhibits"];
            var halls = service.GetDataHalls().Tables["Halls"];
            dataGridView1.DataSource = service.GetData().Tables["Moving"];
            FillComboBox(comboBox1, exhibits);
            FillComboBox(comboBox2, halls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new ServiceReference1.ServiceClient();
            try
            {
                var from = dateTimePicker1.Value;
                var to = dateTimePicker2.Value;
                var exhibit = comboBox1.SelectedItem;
                var hall = comboBox2.SelectedItem;
                if (from < to && exhibit != null && hall != null)
                {
                    var exhibitId = exhibit.ToString().Split(new char[] { '-' })[0];
                    var hallId = hall.ToString().Split(new char[] { '-' })[0];
                    service.NewRec(exhibitId, hallId, from.ToShortDateString(), to.ToShortDateString());
                    Form1_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Проверьте правильность выбранных данных");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сервис не доступен\n"+ex.Message);
            }
        }
        protected void FillComboBox(ComboBox list, DataTable dataTable)
        {
            list.Items.Clear();
            DataTable data = dataTable;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                list.Items.Add(string.Join("-", data.Rows[i].ItemArray));
            }
        }
    }
}
