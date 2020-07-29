using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace ServiceHostApplication
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
        }
    }
}
//,new Uri("http://localhost:8081/WcfServiceLibrary2lab4/Service1/")
//,new Uri("http://localhost:8080/WcfServiceLibrary2lab4/Service1/")
/*<system.serviceModel>
    <services>
      <service name="WcfServiceLibrary2lab4.UserService" behaviorConfiguration="myservicetypebehaviours">
        <endpoint address="user" binding="basicHttpBinding" contract="WcfServiceLibrary2lab4.IUserService">
          
        </endpoint>
        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
        <host>
          <baseAddresses>
            <add baseAddress="http://localhost:8081/WcfServiceLibrary2lab4/Service1/" />
          </baseAddresses>
        </host>
      </service>
      <service name="WcfServiceLibrary2lab4.SlotService" behaviorConfiguration="myservicetypebehaviours">
        <endpoint address="slot" binding="basicHttpBinding" contract="WcfServiceLibrary2lab4.ISlotService">
          
        </endpoint>
        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
        <host>
          <baseAddresses>
            <add baseAddress="http://localhost:8080/WcfServiceLibrary2lab4/Service1/" />
          </baseAddresses>
        </host>
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name ="myservicetypebehaviours">
          <!-- To avoid disclosing metadata information, 
          set the values below to false before deployment -->
          <serviceMetadata httpGetEnabled="True" httpsGetEnabled="True"/>
          <!-- To receive exception details in faults for debugging purposes, 
          set the value below to true.  Set to false before deployment 
          to avoid disclosing exception information -->
          <serviceDebug includeExceptionDetailInFaults="False" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
  </system.serviceModel>
*/