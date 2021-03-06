﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeCamper.Web;
using CodeCamper.WebApi.App_Start;

namespace CodeCamper.WebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            IocConfig.RegusterIoc(GlobalConfiguration.Configuration);

            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            
            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);
        }
    }
}