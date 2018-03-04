using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WooliesxAssignment.Filters;

namespace WooliesxAssignment
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configuration.Filters.Add(new GlobalExceptionHandlingFiler());
        }
    }
}
