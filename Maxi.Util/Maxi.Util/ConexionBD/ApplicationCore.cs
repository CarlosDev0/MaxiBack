﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Util.ConexionBD
{
    public sealed class ApplicationCore
    {
        private static readonly ApplicationCore mInstance = new ApplicationCore();
        private static ISessionFactory mIsessionFactory;

        public static ApplicationCore Instance
        {
            get { return mInstance; }
        }

        public ISessionFactory SessionFactory
        {
            get { return mIsessionFactory; }
            set { mIsessionFactory = value; }
        }
    }
}
