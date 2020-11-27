using Maxi.Util.ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MaxiEntregas
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Configuration configuration = new Configuration();
            //configuration.Configure();
            //ApplicationCore.Instance.SessionFactory = configuration.BuildSessionFactory();
        }
    }
}
