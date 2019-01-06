using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(string email, string password)
        {

        }
    }
}