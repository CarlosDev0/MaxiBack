﻿using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Maxi.Util.ConexionBD
{
    public class NHIbernateHttpModule : IHttpModule
    {

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(BeginEventhandler);
            context.EndRequest += new EventHandler(EndEventhandler);
        }

        private void BeginEventhandler(object o, EventArgs e)
        {
            var session = ApplicationCore.Instance.SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        private void EndEventhandler(object o, EventArgs e)
        {
            CurrentSessionContext.Unbind(ApplicationCore.Instance.SessionFactory);
        }
    }
}
