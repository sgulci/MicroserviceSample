using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace ProductService
{
    class Program
    {
        private const string BaseAddress = "http://*:5004";

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
