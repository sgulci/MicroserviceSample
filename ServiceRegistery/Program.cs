using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace ServiceRegistery
{
    class Program
    {
        private const string BaseAddress = "http://localhost:5000";

        static void Main(string[] args)
        {
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
