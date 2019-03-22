using System;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Repository;

namespace LoggingSink
{
    public class InternalLoggingSink:MarshalByRefObject
    {
        public InternalLoggingSink()
        {
            #region 1.log4net记录日志
            
            ILoggerRepository repository = LogManager.CreateRepository("InternalRepository");log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"ConfigFile\log4net_internal.config"));
            
            ILog log = LogManager.GetLogger(repository.Name,"NETCorelog4net");

            log.Info("NETCorelog4net log");
            log.Info("test log");
            log.Error("error");
            log.Info("linezero");

            #endregion
        }
    }
}
