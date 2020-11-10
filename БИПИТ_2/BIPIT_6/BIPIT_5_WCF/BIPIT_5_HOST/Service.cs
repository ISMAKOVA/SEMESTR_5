using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Data;

namespace BIPIT_5_HOST
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service : IService
    {
        string path = "workstation id=gallery.mssql.somee.com;packet size=4096;user id=ismakova_SQLLogin_1;pwd=prad8etyk3;data source=gallery.mssql.somee.com;persist security info=False;initial catalog=gallery";

        public void NewRec(string exh_fk, string halls_fk, string date_start, string date_end)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand command = new SqlCommand($"insert into Moving (exhibit_fk, halls_fk, date_start,date_end) values(@exh_fk, @halls_fk, @date_start, @date_end)", con);
            command.Parameters.AddWithValue("@exh_fk", exh_fk);
            command.Parameters.AddWithValue("@halls_fk", halls_fk);
            command.Parameters.AddWithValue("@date_start", Convert.ToDateTime(date_start));
            command.Parameters.AddWithValue("@date_end", Convert.ToDateTime(date_end));
            try
            {
                command.ExecuteNonQuery();
                Program.Print(String.Format("[{0}] - Выполнено: запись добавлена", DateTime.Now.ToShortDateString()));
            }
            catch
            {
                Program.Print(String.Format("[{0}] - Ошибка: запись не добавлена", DateTime.Now.ToShortDateString()));
            }
            con.Close();
        }

        public DataSet GetData()
        {
            string query = "select Moving.id as 'ID', Exhibits.exhibit as 'Экспонат', Exhibits.name as 'Название', Exhibits.author as 'Автор', Halls.museum as 'Музей',  format(Moving.date_start,'dd.MM.yyyy г.') as 'Дата поступления работы',format(Moving.date_end,'dd.MM.yyyy г.') as 'Дата отъезда работы' from Exhibits, Halls, Moving where Moving.exhibit_fk = Exhibits.id_exhibit and Moving.halls_fk = Halls.id_hall";
            return SqlSelectData("Moving", query);
        }

        public DataSet GetDataExhibits()
        {
            return SqlSelectData("Exhibits", "select * from Exhibits");
        }

        public DataSet GetDataHalls()
        {
            return SqlSelectData("Halls", "select * from Halls");
        }
        public void HostInfo(int x)
        {
            Program.DisplayHostInfo(x);
        }

        private DataSet SqlSelectData(string tableName, string query)
        {
            DataSet dataSet = new DataSet();
            SqlConnection con = new SqlConnection(path);
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataAdapter sqlData1 = new SqlDataAdapter(command);
                sqlData1.Fill(dataSet, tableName);
                con.Close();
                Program.Print(String.Format("[{0}] - Выполнено: данные получены | {1}", DateTime.Now.ToShortDateString(), tableName));
            }
            catch
            {
                Program.Print(String.Format("[{0}] - Ошибка: данные не получены | {1}", DateTime.Now.ToShortDateString(), tableName));
            }
            return dataSet;
        }

    }
}
