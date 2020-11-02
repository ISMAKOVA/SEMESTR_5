using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BIPIT_6_WEB_CLIENT
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new ServiceReference1.ServiceClient();
            var exhibits = service.GetDataExhibits().Tables["Exhibits"];
            var halls = service.GetDataHalls().Tables["Halls"];
            Table1.DataSource = service.GetData().Tables["Moving"];
            Table1.DataBind();
            if (!IsPostBack)
            {
                FillDropList(exhibits, exhibit_list);
                FillDropList(halls, halls_list);
            }
        }
        protected void Add(object sender, EventArgs e)
        {
            var c_from = from.Text;
            var c_to = to.Text;
            if (c_from != "" || c_to != "")
            {
                if (Convert.ToDateTime(c_from) > Convert.ToDateTime(c_to))
                {
                    error.Text = "Вторая дата не должна быть меньше первой";
                    return;
                }
                var service = new ServiceReference1.ServiceClient();
                var exhibit_id = exhibit_list.Text.Split(new char[] { '-' })[0];
                var hall_id = halls_list.Text.Split(new char[] { '-' })[0];

                service.NewRec(exhibit_id, hall_id, c_from, c_to);
                Page_Load(sender, e);
            }
            else
            {
                error.Text = "Выберите даты";
                return;
            }
        }
        protected void FillDropList(DataTable dataTable, DropDownList list)
        {
            list.Items.Clear();
            DataTable data = dataTable;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                list.Items.Add(string.Join("-", data.Rows[i].ItemArray));
            }
            list.DataBind();
        }
    }
}