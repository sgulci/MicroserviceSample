using System;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace OrderService
{ 
    class Program
    {
#if !DEBUG
        private const string BaseAddress = "http://*:5003";
#else
        private const string BaseAddress = "http://localhost:5003";
#endif

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("Order started...");
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
