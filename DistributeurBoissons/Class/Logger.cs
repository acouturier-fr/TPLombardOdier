using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Class
{
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        //public static Logger Instance { get; private set; }

        public Logger() { }

        public enum Logtype
        {
            info,
            error
        }

        public void Log(Logtype logtype, string message)
        {
            string messageModel = "{0} - {1}";
            switch (logtype)
            {
                case Logtype.info:
                    log.Info(string.Format(messageModel, DateTime.Now.ToString(), message));
                    break;
                case Logtype.error:
                    log.Error(string.Format(messageModel, DateTime.Now.ToString(), message));
                    break;
            }
        }
    }
}
