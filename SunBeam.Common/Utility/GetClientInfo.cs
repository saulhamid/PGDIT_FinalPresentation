using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;

namespace SunBeam.Common.Utility
{
  public static class  GetClientInfo
    {
     

        public static string ClientPCIPAddress { get; set; }
        public static string ClientBrowserInfo { get; set; }
        public static string ClientMacAddress { get; set; }
        public static string ClientPCUserName { get; set; }

       
        public static void ClientUserInfo()
        {
           

            //Get IP          
            IPAddress[] IPS = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in IPS) if (ip.AddressFamily == AddressFamily.InterNetwork) ClientPCIPAddress = ip.ToString();

            HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            ClientBrowserInfo = browser.Browser + " " + browser.Version;

            //Get All Aics: MAC
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            ClientMacAddress = nics[0].GetPhysicalAddress().ToString();

            ClientPCUserName = ClientPCIPAddress + "~" + GetHostName(ClientPCIPAddress);
        }

        public static string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
       
        }
}
