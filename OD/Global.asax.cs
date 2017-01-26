using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using OD.Infrastructure;
using OD.Controllers;

namespace OD
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FluentValidationModelValidatorProvider.Configure();
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;

            Response.Clear();
            var routeData = new RouteData();

            if (httpException == null)
            {
                routeData.Values["controller"] = "Products";
                routeData.Values["action"] = "Index";
            }
            else
            {
                switch (httpException.GetHttpCode())
                {
                    case 500:
                        routeData.Values["controller"] = "Customer";
                        routeData.Values["action"] = "RequestValidationException";
                        break;

                    default:
                        break;
                }
            }

            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;

            IController errorsController = new CustomerController();
            var context = HttpContext.Current;
            context.Response.ContentType = "text/html";
            errorsController.Execute(new RequestContext(new HttpContextWrapper(context), routeData));
            
        }
    }
}
