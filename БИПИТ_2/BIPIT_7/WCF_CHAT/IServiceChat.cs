using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_CHAT

/*
 * Всем добрый день! Вчера была какая-то проблема с дискордом, чат тормозил
Сейчас будет 7 лабораторная
Если кратко:
1. Делаем по гайду https://www.youtube.com/watch?v=QohqDyTjclw&feature=emb_logo
2. У клиентов используем WinForms
3. Требование, которого нет в видео - необходимо хранить историю сообщений каждого клиента. Т.е., если я подключаюсь, то могу увидеть, что писал в прошлый сеанс
 */
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay =true)]
        void SendMsg(string msg, int id);

      /*  [OperationContract]
        void SaveMsg(int id, string msg);*/

    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay =true)]
        void MsgCallback(string msg);
    }
}
