using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BIPIT_4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataSet dataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ShowTable(object sender, EventArgs e)
        {
            var service = new ServiceReference1.ServiceSoapClient();
            var c_from = from.SelectedDate.ToShortDateString();
            var c_to = to.SelectedDate.ToShortDateString();
            if (c_from != "01.01.0001" || c_to != "01.01.0001")
            {
               
                dataSet = service.GetData(c_from, c_to);
                var table = dataSet.Tables["Moving"];
                Table1.DataSource = table;
                Table1.DataBind();
                tableHead.Text = "";
            }
            else
            {
                tableHead.Text = "Вы ничего не выбрали";
            }


        }

    }
}