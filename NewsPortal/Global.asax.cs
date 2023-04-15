using Autofac;
using Autofac.Integration.Mvc;
using NewsPortal.BLL.Interfaces;
using NewsPortal.BLL.Services;
using NewsPortal.Controllers;
using NewsPortal.DAL.Interfaces;
using NewsPortal.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Injection;

namespace NewsPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

           
            BundleConfig.RegisterBundles(BundleTable.Bundles); 
            //AutoFacConfiguration();
        }

        //private void AutoFacConfiguration()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterControllers(typeof(MvcApplication).Assembly);
        //    builder.RegisterType<NewsService>().As<INewsService>().InstancePerRequest();

        //    builder.RegisterType<NewsRepository>().As<INewsRepository>().InstancePerRequest();
        //    builder.RegisterModelBinders(typeof(MvcApplication).Assembly);

        //    builder.RegisterType<HomeController>().InstancePerRequest();
        //    builder.RegisterType<UserController>().InstancePerRequest();





        //    //builder.RegisterType<AccountController>(new InjectionConstructor());

        //    builder.RegisterModelBinderProvider();
        //    var container = builder.Build();


        //}
    }
}
