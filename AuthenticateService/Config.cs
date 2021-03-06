﻿using AuthenticateService.Filter;
using System.Web.Http;

namespace AuthenticateService
{
    public class Config
    {
        //#if !DEBUG
        //        // windows içindeki docker için
        //        //static string Service_Registery_Url = "http://192.168.99.100:5000/api/registery/save/";
        //        //static string Service_Url = "192.168.99.100:5005";

        //        // Netaş cloud'a deployment için test edilecek adresler
        //        static string Service_Registery_Url = "http://217.78.97.197:5000/api/registery/save/";
        //        static string Service_Url = "217.78.97.197:5005";
        //#else
        //        static string Service_Registery_Url = "http://localhost:5000/api/registery/save/";
        //        static string Service_Url = "localhost:5005";
        //#endif

        public static string Service_Registery_Url;
        public static string Service_Url;

        public static void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            httpConfiguration.Filters.Add(new ErrorHandlingFilter());

            ServiceCall.RestService(Service_Registery_Url + "/save/" + Service_Url + ",authenticate");
        }
    }
}
