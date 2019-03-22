using System;
using System.IO;
using log4net;
using log4net.Repository;

namespace ToolLibrary.Common
{
    /* 日志帮助类 */
    public static class LogHelper
    {
        private static ILoggerRepository loggerRepository;
        public static ILoggerRepository LoggerRepository
        {
            get;
            private set;
        }

        public static ILog Log
        {
            get;
            private set;
        }

        static LogHelper()
        {
            loggerRepository = CreateLoggerRepository();
            LoadLog4NetConfig();
        }
        
        public static void LoadLogger(string repositoryName = "defaultRepository",string log4netConfigName = "log4net.config")
        {
            loggerRepository = CreateLoggerRepository(repositoryName);
            LoadLog4NetConfig(log4netConfigName);
        }

        private static ILoggerRepository CreateLoggerRepository(string repositoryName = "defaultRepository")
        {
            loggerRepository = loggerRepository ?? LogManager.CreateRepository(repositoryName);
            return loggerRepository;
        }

        private static void LoadLog4NetConfig(string log4netConfigName = "log4net.config")
        {
            string curProjPath = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = string.Format(@"ConfigFile\{0}",log4netConfigName);
            string fullPath = curProjPath + configPath;
            log4net.Config.XmlConfigurator.ConfigureAndWatch(loggerRepository,new FileInfo(fullPath));
            Log = LogManager.GetLogger(loggerRepository.Name, AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
