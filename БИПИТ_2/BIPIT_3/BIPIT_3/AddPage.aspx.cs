using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPIT_3
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropList("exhibits", exhibit_list);
                FillDropList("halls", halls_list);
            }

        }

        protected void Add(object sender, EventArgs e)
        {

            var c_from = from.SelectedDate.ToShortDateString();
            var c_to = to.SelectedDate.ToShortDateString();
            if (c_from != "01.01.0001" || c_to != "01.01.0001")
            {
                if (Convert.ToDateTime(c_from) > Convert.ToDateTime(c_to))
                {
                    error.Text = "Вторая дата не должна быть меньше первой";
                    return;
                }
                var service = new ServiceReference1.ServiceSoapClient();
                var exhibit_id = exhibit_list.Text.Split(new char[] { '-' })[0];
                var hall_id = halls_list.Text.Split(new char[] { '-' })[0];

                service.NewRec(exhibit_id, hall_id, c_from, c_to);
                Server.Transfer("Table.aspx", true);
            }


        }
        protected void FillDropList(string table, DropDownList list)
        {
            list.Items.Clear();
            var service = new ServiceReference1.ServiceSoapClient();
            DataTable data = service.Show(table).Tables[table];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                list.Items.Add(string.Join("-", data.Rows[i].ItemArray));
            }
            list.DataBind();
        }

    }
}