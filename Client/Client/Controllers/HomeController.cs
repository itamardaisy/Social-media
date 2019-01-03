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
    public class HomeController : Controller
    {
        HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:39265/");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main(string email)
        {
            var result = _client.GetAsync($"api/Identity/GetUserIdentity?email={email}").Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.Content.ReadAsStringAsync().Result);
            }

            string response = result.Content.ReadAsStringAsync().Result;
            var identity = JsonConvert.DeserializeObject<UserIdentity>(response);
            var viewModel = new UserIdentityViewModel
            {
                Identity = identity
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