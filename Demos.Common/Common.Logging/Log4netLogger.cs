using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Common.Logging
{
    public class Log4netLogger : ILog
    {
        private readonly log4net.ILog _logger;

        public Log4netLogger()
            : this(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
        {

        }

        public Log4netLogger(Type type)
            : this(type, string.Empty)
        {
        }

        public Log4netLogger(Type type, string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
            {
                log4net.Config.XmlConfigurator.Configure();
            }
            else
            {
                log4net.Config.XmlConfigurator.Configure(new FileInfo(configPath));
            }

            _logger = LogManager.GetLogger(type);
        }



        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Exception(Exception exception)
        {
            _logger.Error("出现异常:", exception);
        }

    }
}
