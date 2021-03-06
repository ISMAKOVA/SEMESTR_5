﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPIT_3
{
    public partial class Table : System.Web.UI.Page
    {

        
        DataSet dataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowTable(sender, e);
            }
        }

        protected void ShowTable(object sender, EventArgs e)
        {
            Service service = new Service();
            var c_from = from.Text;
            var c_to = to.Text;
            dataSet = service.GetData(c_from, c_to);
            var table = dataSet.Tables["Moving"];
            Table1.DataSource = table;
            Table1.DataBind();
            tableHead.Text = "";
        }

        protected void Delete(object sender, EventArgs e)
        {
            Service service = new Service();
            for (int i = 0; i < Table1.Rows.Count; i++)
            {
                var checkbox = (CheckBox)Table1.Rows[i].FindControl("ch");
                if (checkbox.Checked)
                {
                    var id = Convert.ToInt32(Table1.Rows[i].Cells[1].Text);
                    service.DeleteRec(id);

                }
            }
            ShowTable(sender, e);


        }

    }
}