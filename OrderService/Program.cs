﻿using System;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace OrderService
{ 
    class Program
    {
        private const string BaseAddress = "http://*:5003";
        private const string BaseAddress_Test = "http://localhost:5003";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseAddress_Test))
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
