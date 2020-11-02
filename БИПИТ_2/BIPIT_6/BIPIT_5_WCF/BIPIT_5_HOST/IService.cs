using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Data;


namespace BIPIT_5_HOST
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        DataSet GetData();

        [OperationContract]
        void NewRec(string exh_fk, string halls_fk, string date_start, string date_end);

        [OperationContract]
        DataSet GetDataExhibits();

        [OperationContract]
        DataSet GetDataHalls();
        
        [OperationContract]
        void HostInfo(int x);
    }
}
