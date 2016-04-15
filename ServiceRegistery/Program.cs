using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace ServiceRegistery
{
    class Program
    {

//#if !DEBUG
//        private const string BaseAddress = "http://*:5000";
//#else
//        private const string BaseAddress = "http://localhost:5000";
//#endif

        static void Main(string[] args)
        {
            string BaseAddress = args[0].ToString();

            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("Registery service started...");
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
