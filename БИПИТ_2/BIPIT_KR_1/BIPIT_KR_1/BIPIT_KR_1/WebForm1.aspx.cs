using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace BIPIT_KR_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
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
            dataTable = service.GetData();
            Table1.DataSource = dataTable;
            Table1.DataBind();
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
                    service.Delete(id);

                }
            }
            ShowTable(sender, e);
        }
        protected void Update(object sender, EventArgs e)
        {
            Service service = new Service();
            for (int i = 0; i < Table1.Rows.Count; i++)
            {
                var checkbox = (CheckBox)Table1.Rows[i].FindControl("ch");
                if (checkbox.Checked)
                {
                    var id = Convert.ToInt32(Table1.Rows[i].Cells[1].Text);
                    if (date.Text != "" && author.Text != "" && problem.Text != "")
                        service.Update(id, date.Text, author.Text, problem.Text);
                    else
                    {
                        error.Text = "Поля не должны быть пустыми";
                        return;
                    }

                }
            }
            ShowTable(sender, e);
            error.Text = "";
        }
        protected void NewRec(object sender, EventArgs e)
        {
            Service service = new Service();
            string s = author.Text;
            if (date.Text != "" && author.Text != "" && problem.Text != "")
                service.NewRec(date.Text, author.Text, problem.Text);
            else
            {
                error.Text = "Поля не должны быть пустыми";
                return;
            }
            ShowTable(sender, e);
            error.Text = "";
        }
    }
}