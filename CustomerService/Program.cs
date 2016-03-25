using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace CustomerService
{
    class Program
    {
#if !DEBUG
        private const string BaseAddress = "http://*:5002";
#else
        private const string BaseAddress = "http://localhost:5002";
#endif

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("Customer Service started...");
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
