using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace CustomerService
{
    class Program
    {
        private const string BaseAddress = "http://*:5002";
        private const string BaseAddress_Test = "http://localhost:5002";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseAddress_Test))
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
