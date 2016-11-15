using MyTracking.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WF = System.Web.ModelBinding;

namespace MyTracking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Add my MVC Provider
            ModelBinderProviders.BinderProviders.Add(new EFModelBinderProviderMvc());

            //I could register a spceific type, without a provider...
            //WF.ModelBinderProviders.Providers.RegisterBinderForType(typeof(DbGeography), new DbGeographyModelBinder());

            //Or just put my provider first as it's pretty specific
            WF.ModelBinderProviders.Providers.Insert(0, new EFModelBinderProviderWebForms());
        }
    }
}
