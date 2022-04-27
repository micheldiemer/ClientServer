namespace Commun
{

    using System.Net;
    using System.Net.Sockets;


   
    public class UtilIP
    {

        public const UInt16 DEFAULT_PORT_SERVER = 33000;
        public const UInt16 DEFAULT_PORT_CLIENT = 33001;
        public static IPAddress GetAdrIpLocaleV4()
        {
            string hote = Dns.GetHostName();
            IPHostEntry ipLocales = Dns.GetHostEntry(hote);
            foreach (IPAddress ip in ipLocales.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            return IPAddress.Parse("127.0.0.1");
            
        }
   

        public static IPAddress IPMulticast()
        {
            return IPAddress.Parse("224.168.100.2");
        }

    }

}
