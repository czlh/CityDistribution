using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Taocz.CVS.Common.Context;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var path = Server.MapPath("~/log4net.xml");
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(path));

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CDDbContext, CDDbMigrationsConfiguration>());

            //IUnityContainer unityContainer = new UnityContainer();
            //UnityConfigurationSection unityConfig = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            //unityConfig.Configure(unityContainer);
        }

    }
}
