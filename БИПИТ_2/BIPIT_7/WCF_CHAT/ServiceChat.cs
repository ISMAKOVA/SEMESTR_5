using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_CHAT
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
     public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;
        public int Connect(string name)
        {
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
            foreach(var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString()+" | ";
                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += user.Name + ": ";
                }
                answer += msg;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }

        public  List<string> ShowMsg(string name)
        {
            
            List<string> history = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Даяна Исмакова\Desktop\универ\SEMESTR_5\БИПИТ_2\BIPIT_7\history.txt", Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var l = line.Split(new char[] { '#' });
                        if (l[0] == name)
                        {
                            for(int i = 1; i< l.Length; i++)
                            {
                                history.Add(l[i]);
                            }

                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
            catch(Exception e)
            {
                history.Add(e.Message);
            }
            return history;
        }
        public void SaveMsg(string name, string messages)
        {
            string path = @"C:\Users\Даяна Исмакова\Desktop\универ\SEMESTR_5\БИПИТ_2\BIPIT_7\history.txt";
            List<string> history = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        history.Add(line);
                    }

                }
                foreach(var line in history)
                {
                    var l = line.Split(new char[] { '#' });
                    if (l[0] == name)
                    {
                        history.Remove(line);
                    }
                }
                history.Add(messages);
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    foreach (var line in history)
                    {
                        sw.WriteLine(line);
                    }
                        
                }
            }
            catch
            {

            }
        }
    }
}
