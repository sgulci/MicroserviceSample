using System;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace ApiGateway
{
    class Program
    {

//#if !DEBUG
//        private const string BaseAddress = "http://*:5001";
//#else
//        private const string BaseAddress = "http://localhost:5001";
//#endif

        static void Main(string[] args)
        {
            string BaseAddress = args[0].ToString();
            Config.Service_Registery_Url = args[1].ToString();

            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("ApiGateway Service started...");
                string readVal = Console.ReadLine();
                while (string.IsNullOrEmpty(readVal))
                {
                    Thread.Sleep(5000);
                    readVal = Console.ReadLine();
                }
            }
        }
    }
}
