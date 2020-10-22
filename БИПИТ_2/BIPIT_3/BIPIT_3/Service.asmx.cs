using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace BIPIT_3
{
    /// <summary>
    /// Сводное описание для Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        string path = "workstation id=gallery.mssql.somee.com;packet size=4096;user id=ismakova_SQLLogin_1;pwd=prad8etyk3;data source=gallery.mssql.somee.com;persist security info=False;initial catalog=gallery";
        

        [WebMethod]
        public DataSet GetData(string date_start, string date_end)
        {
            DataSet dataSet = new DataSet();
            SqlConnection con = new SqlConnection(path);
            
            SqlCommand command;

            string query = "select Moving.id as 'ID', Exhibits.exhibit as 'Экспонат', Exhibits.name as 'Название', Exhibits.author as 'Автор', Halls.museum as 'Музей', Year(GETDATE())-Exhibits.year as 'Возраст работы', format(Moving.date_start,'dd.MM.yyyy г.') as 'Дата поступления работы' from Exhibits, Halls, Moving where Moving.exhibit_fk = Exhibits.id_exhibit and Moving.halls_fk = Halls.id_hall and Moving.date_start between  @date_start and @date_end";
            command = new SqlCommand(query, con);    
            command.Parameters.AddWithValue("@date_start",Convert.ToDateTime(date_start));
            command.Parameters.AddWithValue("@date_end", Convert.ToDateTime(date_end));

            con.Open();

            SqlDataAdapter sqlData1 = new SqlDataAdapter(command);
            sqlData1.Fill(dataSet, "Moving");
            con.Close();
            return dataSet;
        }

        [WebMethod]
        public void NewRec(string exh_fk, string halls_fk,string date_start, string date_end)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand command = new SqlCommand($"insert into Moving (exhibit_fk, halls_fk, date_start,date_end) values(@exh_fk, @halls_fk, @date_start, @date_end)",con);
            command.Parameters.AddWithValue("@exh_fk", exh_fk);
            command.Parameters.AddWithValue("@halls_fk", halls_fk);
            command.Parameters.AddWithValue("@date_start", Convert.ToDateTime(date_start));
            command.Parameters.AddWithValue("@date_end", Convert.ToDateTime(date_end));
            command.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void DeleteRec(int id)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand command = new SqlCommand($"delete from Moving where Moving.id = @id",con);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public DataSet Show(string tableName)
        {
            DataSet dataSet = new DataSet();
            SqlConnection con = new SqlConnection(path);

            string query = $"select * from " +tableName;
            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            SqlDataAdapter sqlData1 = new SqlDataAdapter(command);
            sqlData1.Fill(dataSet, tableName);

            con.Close();
            return dataSet;

        }

    }
}
