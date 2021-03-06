﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RecipeBookAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.Request.HttpMethod == "OPTIONS")
            {
                if (Context.Request.Headers["Origin"] != null)
                    Context.Response.AddHeader("Access-Control-Allow-Origin", Context.Request.Headers["Origin"]);

                Context.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, MaxDataServiceVersion");
                Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");

                Response.End();
            }
        }
    }
}
