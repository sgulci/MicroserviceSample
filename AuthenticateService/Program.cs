using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace AuthenticateService
{
    class Program
    {
#if !DEBUG
        private const string BaseAddress = "http://*:5005";
#else
        private const string BaseAddress = "http://localhost:5005";
#endif

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("Authenticate Service started...");
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
