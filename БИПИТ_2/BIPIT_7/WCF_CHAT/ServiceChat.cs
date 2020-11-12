using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WCF_CHAT
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
     public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;
        string con = "Data Source=DESKTOP-LVBRSER;Initial Catalog=chat;Integrated Security=True";
        string userName;
        public int Connect(string name)
        {
            userName = name;
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextId++;
            SendMsg(user.Name + " подключился к чату!",0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg( user.Name + " покинул чат!",0);
            }

        }

        public void SendMsg(string msg, int id)
        {
            var date = DateTime.Now;
            foreach (var item in users)
            {
                string answer = date.ToShortTimeString() + " | ";
                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += user.Name + ": ";
                }
                answer += msg;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
            if (id != 0)
            {
                SaveMsg(userName, msg, date);
            }
        }

        public void SaveMsg(string name, string msg, DateTime date)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand($"insert into Messages (name, message, date) values(@name, @message, @date)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@message", msg);
            command.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<string> ShowMsg(string name)
        {
            
            List<string> history = new List<string>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(con);

            string query = $"select format(date,'hh:mm') as date, name, message from Messages where name ='" +name+"'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataAdapter sqlData1 = new SqlDataAdapter(command);
            sqlData1.Fill(dataTable);
            connection.Close();
            foreach(DataRow row in dataTable.Rows)
            {
                history.Add(String.Format("{0} | {1}: {2}", row["date"], row["name"], row["message"]));
            }
            return history;
        }
    }
}
