﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CouchbaseWebService.Web;

namespace WebApplication1
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Bootstrapper.Initialise();
            ControllerBuilder.Current.SetControllerFactory(typeof(CustomControllerFactory)); 
        }
    }
}
