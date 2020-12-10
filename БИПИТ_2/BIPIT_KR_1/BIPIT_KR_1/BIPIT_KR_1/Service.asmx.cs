using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace BIPIT_KR_1
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
        string path = "workstation id=Maintenance.mssql.somee.com;packet size=4096;user id=ismakova_SQLLogin_1;pwd=prad8etyk3;data source=Maintenance.mssql.somee.com;persist security info=False;initial catalog=Maintenance";

        [WebMethod]
        public DataTable GetData()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(path);

            SqlCommand command;

            string query = "select t1.id as 'Код',t1.datetime as 'Дата и время', t1.author as 'Автор', t1.problemDesc as 'Описание проблемы' from t1";
            command = new SqlCommand(query, con);

            con.Open();

            SqlDataAdapter sqlData1 = new SqlDataAdapter(command);
            sqlData1.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        [WebMethod]
        public void NewRec(string date, string author, string problem)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand command = new SqlCommand($"insert into t1 (datetime, author, problemDesc) values(@date, @author, @problem)", con);
            command.Parameters.AddWithValue("@problem", problem);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
            command.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand command = new SqlCommand($"delete from t1 where t1.id = @id", con);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void Update(int id, string date, string author, string problem)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand command = new SqlCommand($"update t1 set datetime = @date, author=@author, problemDesc=@problem where id = @id", con);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@problem", problem);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
            command.ExecuteNonQuery();
            con.Close();
        }

    }
}
