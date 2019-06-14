using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThePeopleSearch.Data.Helpers;

namespace ThePeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Error()
        {
            throw new Exception("Test Error");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!
            ErrorHelper eh = new ErrorHelper();
            eh.Log(filterContext.Exception.Message, filterContext.Exception.StackTrace, DateTime.Now);

            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "Home");
        }
    }
}