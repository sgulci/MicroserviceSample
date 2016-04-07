using System;
using System.Net;

namespace MovieService
{
    public static class ServiceCall
    {
        public static string RestService(string url)
        {
            
            Console.WriteLine("CallRestService url :" + url);

            string content = "";

            try
            {
                var syncClient = new WebClient();
                content = syncClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("rest call url :" + url + " exception ex :" + ex.Message);

            }

            return content;
        }
    }
}
