using Client.Models;
using Client.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class IdentityController : Controller
    {
        HttpClient _client;
        public IdentityController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:39265/");
        }
        // GET: Identity
        public ActionResult Info(UserIdentity userIdentity)
        {
            //var result = _client.GetAsync($"api/Identity/GetUserIdentity?email={userIdentity.Email}").Result;
            //if (!result.IsSuccessStatusCode)
            //{
            //    throw new Exception(result.Content.ReadAsStringAsync().Result);
            //}

            //string response = result.Content.ReadAsStringAsync().Result;
            //var identity = JsonConvert.DeserializeObject<UserIdentity>(response);

            var identityViewModel = new UserIdentityViewModel
            {
                Identity = userIdentity
            };

            return View(identityViewModel);
        }

        // POST: Identity/Edit/5
        //[HttpPost]
        public ActionResult Edit(UserIdentity identity)
        {
            try
            {
                var result = _client.GetAsync($"api/Identity/UpdateUserIdentity?userIdentity={identity}").Result;
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception(result.Content.ReadAsStringAsync().Result);
                }
                return RedirectToAction("Main", routeValues: new { email = identity.Email, });
            }
            catch
            {
                return View();
            }
        }

        // GET: Identity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Identity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Identity/Create
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

        // GET: Identity/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}


        // GET: Identity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Identity/Delete/5
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
