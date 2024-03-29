﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ThePeopleSearch.Data.Helpers;
using ThePeopleSearch.ErrorLogging;

namespace ThePeopleSearch.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        ErrorHelper eh = new ErrorHelper();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server != null)
            {
                Exception ex = Server.GetLastError();

                if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
                {
                    return;
                }
                else
                {
                    eh.Log("The People Search API", ex.Message, ex.StackTrace, DateTime.Now);
                }

            }
        }
    }
}
