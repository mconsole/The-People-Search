using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThePeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Host = ConfigurationManager.AppSettings["WebAPIUrl"];

            return View();
        }
    }
}