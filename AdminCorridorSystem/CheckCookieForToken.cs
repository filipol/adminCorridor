using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AdminCorridorSystem.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace AdminCorridorSystem
{
    public class CheckCookieForToken
    {
        static void Main()
        {

        }


        public static string GetCookie(string cookie)
        {

            if (HttpContext.Current.Request.Cookies[cookie].Value != null)
            {
                var id = HttpContext.Current.Request.Cookies[cookie].Value;
                return id;
            }
            else
            {
                return "No Cookie";
            }
        }

    }
}