using Empire;
using Empire.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BackEnd
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<EmpireDBContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}