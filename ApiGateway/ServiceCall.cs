using System;
using System.Net;
using System.Net.Http;

namespace ApiGateway
{
    public static class ServiceCall
    {
        public static string RestService(string url)
        {
            
            Console.WriteLine("CallRestService url :" + url);

            string content ;

            try
            {
                var syncClient = new WebClient();
                content = syncClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("rest call url :"+ url + " exception ex :" + ex.Message);
                content = "";

            }

            return content;
        }

        public static HttpResponseMessage RestServiceHttpGetResponse(string url)
        {

            Console.WriteLine("CallRestService url :" + url);

            HttpResponseMessage content = new HttpResponseMessage() ;

            try
            {
                HttpClient client = new HttpClient();
                content = client.GetAsync(url).Result;
                //var syncClient = new WebClient();
                //content = syncClient.h(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("rest call url :" + url + " exception ex :" + ex.Message);

            }

            return content;
        }
    }
}
