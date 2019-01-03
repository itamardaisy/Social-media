using Client.Models;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main(string email)
        {
            var identity = _client.GetAsync($"api/identity/{email}").Result;
            var viewModel = new UserIdentityViewModel
            {
                Identity = new UserIdentity
                {
                    Email = "ggg@g.com",
                    FirstName = "sanad",
                    LastName = "san",
                    Age = 23,
                    Address = "dsffd",
                    WorkAddress = "fsfg"
                }
            };

            return View(viewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}