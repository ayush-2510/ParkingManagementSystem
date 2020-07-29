using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary2lab4.UserService)))
            {
                using (ServiceHost host1 = new ServiceHost(typeof(WcfServiceLibrary2lab4.SlotService)))
                {
                    host1.Open();
                    Console.WriteLine("host1 started @" + DateTime.Now.ToString());
                    host.Open();
                    Console.WriteLine("host2 started @" + DateTime.Now.ToString());
                    Console.ReadLine();
                }

            }
            /*
            using (ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary2lab4.UserService)))
            {
                host.Open();
                Console.WriteLine("host started @" + DateTime.Now.ToString());
                Console.ReadLine();
            }*/
        }
    }
}
