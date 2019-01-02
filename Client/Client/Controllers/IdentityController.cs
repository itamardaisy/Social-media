using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Info()
        {
            var userIdentity = new UserIdentity
            {
                Email = "ggg@g.com",
                FirstName = "sanad",
                LastName = "san",
                Age = 23,
                Address = "dsffd",
                WorkAddress = "fsfg"
            };
            return View(userIdentity);
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Identity/Edit/5
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
