using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BIPIT_3
{
    public partial class Default : System.Web.UI.MasterPage
    {
        Table table1;
        Label head;
        DataSet dataSet1 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            table1 = content.FindControl("Table1") as Table;
            head = content.FindControl("Header") as Label;

            string path = "workstation id=gallery.mssql.somee.com;packet size=4096;user id=ismakova_SQLLogin_1;pwd=prad8etyk3;data source=gallery.mssql.somee.com;persist security info=False;initial catalog=gallery";
            string query_1 = "select * from Exhibits";
            string query_2 = "select * from Halls";
            string query_3 = "select Moving.id, Exhibits.exhibit, Exhibits.name, Exhibits.author, Halls.museum, Year(GETDATE())-Exhibits.year as 'возраст работы', format(Moving.date_start,'dd.MM.yyyy г.') as 'дата поступления работы'" +
                "from Exhibits, Halls, Moving where Moving.exhibit_fk = Exhibits.id_exhibit and Moving.halls_fk = Halls.id_hall";


            using (SqlConnection con = new SqlConnection(path))
            {
               SqlDataAdapter sqlData1 = new SqlDataAdapter(query_1, con);
               sqlData1.Fill(dataSet1, "Exhibits");

                SqlDataAdapter sqlData2 = new SqlDataAdapter(query_2, con);
                sqlData2.Fill(dataSet1, "Halls");

                SqlDataAdapter sqlData3 = new SqlDataAdapter(query_3, con);
                sqlData3.Fill(dataSet1, "Moving");

            }

        }

        protected void ShowTable_1(object sender, EventArgs e)
        {
            head.Text = "Экспонаты";
            var table = dataSet1.Tables["Exhibits"];
            List<string> headers = new List<string>() { "ID", "Экспонат", "Автор", "Название", "Материал", "Год" };
            CreateTable(table, headers);
        }
        protected void ShowTable_2(object sender, EventArgs e)
        {
            head.Text = "Залы";
            var table = dataSet1.Tables["Halls"];
            List<string> headers = new List<string>() { "ID", "Название зала", "Этаж", "Музей", "Город"};
            CreateTable(table, headers);
        }
        protected void ShowTable_3(object sender, EventArgs e)
        {
            head.Text = "Перемещения";
            var table = dataSet1.Tables["Moving"];
            List<string> headers = new List<string>() { "ID", "Экспонат", "Название", "Автор","Музей", "Возраст работы", "Дата поступления работы"};
            CreateTable(table, headers);         
        }

        public void CreateTable(DataTable table, List<string> headers)
        {
            TableRow rr = new TableRow();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                table.Columns[i].ColumnName = headers[i];
                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(table.Columns[i].ColumnName.ToString()));
                rr.Cells.Add(c);
            }
            table.Rows.Add(rr);
            foreach (DataRow row in table.Rows)
            {
                TableRow r = new TableRow();
                foreach (DataColumn column in table.Columns)
                {
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl(row[column].ToString()));
                    r.Cells.Add(c);
                }
                table.Rows.Add(r);

            }
        }
    }
}