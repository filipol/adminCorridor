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


        public static bool CheckCookie(string something)
        {
            using (var client = new HttpClient())
            {
                
                if (HttpContext.Current.Request.Cookies["AccessToken"].Value != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }  
}