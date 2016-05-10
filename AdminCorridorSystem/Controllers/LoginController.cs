using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;

namespace AdminCorridorSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public async void GetToken(string username, string password)
        {
            var values = new Dictionary<string, string>();
            values.Add("UserName", username);
            values.Add("Password", password);
            values.Add("Grant_Type", "password");
            var content = new FormUrlEncodedContent(values);

            string result = await SendRequests.RunRequest("POST", "TEST", content);
            //Dictionary<string, string> body = new Dictionary<string, string>();
            //body.Add("UserName","PelleS1111");
            //body.Add(){
            
            //};
            //body.Add("")
            //Task<string> result = SendRequests.RunRequest("POST", "TEST", body);
            //var finalres = result.Result;
            //Debug.WriteLine("Test: " + finalres);
            //Debug.WriteLine("Testte");
            //return true;
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
