﻿using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace MovieService
{
    class Program
    {
        //#if !DEBUG
        //        private const string BaseAddress = "http://*:5006";
        //#else
        //        private const string BaseAddress = "http://localhost:5006";
        //#endif

        static void Main(string[] args)
        {
            string BaseAddress = args[0].ToString();
            Config.Service_Registery_Url = args[1].ToString();
            Config.Service_Url = args[2].ToString();

            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("Movie Service started...");
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
