﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThePeopleSearch.Data.Helpers;
using ThePeopleSearch.ErrorLogging;

namespace ThePeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Host = ConfigurationManager.AppSettings["WebAPIUrl"];
            return View();
        }

        public ActionResult Error()
        {
            throw new Exception("Test Error");
        }

        public ActionResult ErrorPage()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!
            ErrorHelper eh = new ErrorHelper();
            eh.Log("The People Search MVC", filterContext.Exception.Message, filterContext.Exception.StackTrace, DateTime.Now);

            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("ErrorPage", "Home");
        }

        [HttpPost]
        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/User_Images/"), fileName);
                    file.SaveAs(path);
                }
            }

            return RedirectToAction("Index");
        }
    }
}