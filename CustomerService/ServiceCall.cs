using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    public static class ServiceCall
    {
        public static string RestService(string url)
        {
            
            Console.WriteLine("CallRestService url :" + url);

            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);


            return content;
        }
    }
}
