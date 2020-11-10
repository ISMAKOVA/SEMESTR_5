using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace BIPIT_5_HOST
{
    class Program
    {
        static ServiceHost serviceH;
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------WCF хост----------------------");
            using (serviceH = new ServiceHost(typeof(Service)))
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

        public static void DisplayHostInfo(int x)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------Host info----------------------");
            Console.WriteLine("Name {0}", serviceH.Description.ConfigurationName);

            Console.WriteLine("Port {0}", serviceH.BaseAddresses[x].Port);
            Console.WriteLine("Uri {0}", serviceH.BaseAddresses[x].AbsoluteUri);
            Console.WriteLine("Scheme {0}", serviceH.BaseAddresses[x].Scheme);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

        }
    }
}
