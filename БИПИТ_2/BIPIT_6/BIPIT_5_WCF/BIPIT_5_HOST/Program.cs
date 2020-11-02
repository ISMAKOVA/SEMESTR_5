using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using BIPIT_5_HOST;

namespace BIPIT_5_HOST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------WCF хост----------------------");
            using (ServiceHost serviceH = new ServiceHost(typeof(Service)))
            {
                serviceH.Open();
                Console.WriteLine("Сервис запущен");
                Console.WriteLine("Нажать Enter для остановки");
                Console.ReadKey();
                serviceH.Close();
            }
        }

        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
