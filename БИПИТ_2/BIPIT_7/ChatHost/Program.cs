using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;
namespace ChatHost
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(WCF_CHAT.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Хост работает");
                var res = ShowMsg("Lili");
                foreach (var r in res)
                    Console.WriteLine(r);
                Console.ReadLine();
            }
        }
        public static List<string> ShowMsg(string name)
        {
            string con = "Data Source=DESKTOP-LVBRSER;Initial Catalog=chat;Integrated Security=True";
            List<string> history = new List<string>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(con);

            string query = $"select format(date,'hh:mm') as date, name, message from Messages where name ='" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataAdapter sqlData1 = new SqlDataAdapter(command);
            sqlData1.Fill(dataTable);
            connection.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                history.Add(String.Format("{0} | {1}: {2}", row["date"], row["name"], row["message"]));
            }
            return history;
        }
    }
}
