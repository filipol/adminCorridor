using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdminCorridorSystem.Models;

namespace AdminCorridorSystem.Controllers
{
    public class HomeController : Controller
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5998/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/Account/UserInfo");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("{0}", res);
                }
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult ManageUsers()
        {
            GetUsers();
            ManageUsersViewModel us = new ManageUsersViewModel();
            return View(us);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> GetUsers()
        {
            string result = await SendRequests.RunRequest("GET", "Users/1", null);

            if (result != "ERROR")
            {
                Users user = new Users();
                user.FirstName = result;
                ManageUsersViewModel x = new ManageUsersViewModel();
                x.Users.Add(user);
                
                return View(x);  
            }
            else
            {
                return View();
            }
            
        }
    }
}