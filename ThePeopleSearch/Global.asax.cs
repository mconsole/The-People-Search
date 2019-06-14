using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ThePeopleSearch.Data.Helpers;

namespace ThePeopleSearch
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ErrorHelper eh = new ErrorHelper();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
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
                    eh.Log(ex.Message, ex.StackTrace, DateTime.Now);
                }

            }


        }
    }
}
