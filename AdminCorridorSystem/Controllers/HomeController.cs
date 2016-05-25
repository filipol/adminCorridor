using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdminCorridorSystem.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
        public ActionResult Schedule()
        {
            return View();
        }

        
        public async Task<ActionResult> ManageUsers()
        {
            await GetUsers(1);
            return View();
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


        public async Task<ActionResult> DeleteUser(int uId)
        {
            
            string result = await SendRequests.RunRequest("DELETE", "Users/" + uId, null);

            if (result != "ERROR")
            {
                await GetUsers(1);
                return View("ManageUsers");
            }
            else
            {
                return View("ManageUsers");
            }
            
        }

        public async Task<ActionResult> EditUser(int uId, string firstname, string lastname, string email, string title)
        {
            var values = new Dictionary<string, string>();
            values.Add("Title", title);
            values.Add("FirstName", firstname);
            values.Add("LastName", lastname);
            values.Add("Email", email);
            var content = new FormUrlEncodedContent(values);

            string result = await SendRequests.RunRequest("PUT", "Users/" + uId, content);

            if (result != "ERROR")
            {
                return RedirectToAction("ManageUsers", "Home");
            }
            else
            {
                return RedirectToAction("ManageUsers", "Home");
            }
        }

        public async Task<ActionResult> RegisterUser(string username, string password, string confirmpassword, string usertype, string title, string firstname, string lastname, string email, string signature)
        {
            var values = new Dictionary<string, string>();
            values.Add("Username", username);
            values.Add("Password", password);
            values.Add("ConfirmPassword", confirmpassword);
            values.Add("Usertype", usertype);
            values.Add("Title", title);
            values.Add("FirstName", firstname);
            values.Add("LastName", lastname);
            values.Add("Email", email);
            values.Add("signature", signature);
            var content = new FormUrlEncodedContent(values);

            string result = await SendRequests.RunRequest("POST", "Account/Register", content);

            if (result != "ERROR")
            {
                return RedirectToAction("ManageUsers", "Home");
            }
            else
            {
                return RedirectToAction("ManageUsers", "Home");
            }
        }

        public async Task<ActionResult> GetUsers(int type)
        {
            string result = await SendRequests.RunRequest("GET", "User/"+ type, null);

            if (result != "ERROR")
            {
                var users = (JArray)JsonConvert.DeserializeObject(result);
                ManageUsersViewModal ManagedUsers = new ManageUsersViewModal();
                foreach (var i in users)
                {
                    Users user = new Users();
                    var test = (JObject)i;
                    user.FirstName = i.SelectToken("FirstName").Value<string>(); 
                    user.UserName = i.SelectToken("UserName").Value<string>();
                    user.LastName = i.SelectToken("LastName").Value<string>();
                    user.Email = i.SelectToken("Email").Value<string>();
                    user.Title = i.SelectToken("Title").Value<string>();
                    user.uId = i.SelectToken("Id").Value<int>();
                    user.Signature = i.SelectToken("signature").Value<string>();
                    ManagedUsers.ManageUser.Add(user);
                }
                
                
                return View("ManageUsers", ManagedUsers);  
            }
            else
            {
                return View();
            }
            
        }
    }
}