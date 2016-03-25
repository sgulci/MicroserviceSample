using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace ProductService
{
    class Program
    {
#if !DEBUG
        private const string BaseAddress = "http://*:5004";
#else
        private const string BaseAddress = "http://localhost:5004";
#endif

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("Product Service started...");
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
