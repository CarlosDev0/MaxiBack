using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Util.Log
{
    public static class Nlog
    {
        public static Logger logger = LogManager.GetLogger("myAppLogRules");
        public static void setLogger(string mensaje) {
            logger.Info(mensaje);
        }
    }
}
