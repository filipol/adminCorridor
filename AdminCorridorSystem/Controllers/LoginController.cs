using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AdminCorridorSystem.Controllers
{
    public class LoginController : AsyncController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        

        public async Task<ActionResult> GetToken(FormCollection form)
        {
            var values = new Dictionary<string, string>();
            values.Add("Password", form["password"].ToString());
            values.Add("UserName", form["username"].ToString().ToLower());
            values.Add("Grant_Type", "password");           
            var content = new FormUrlEncodedContent(values);

            string result = await SendRequests.RunRequest("POST", "Token", content);

            if(result != "ERROR")
            {
                string res = await SendRequests.RunRequest("GET", "User", null);
                if(res != "ERROR")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
                
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
