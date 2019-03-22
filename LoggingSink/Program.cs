using System;
using System.IO;
using log4net;
using log4net.Repository;
using log4net.Config;
using ToolLibrary.Common;

namespace LoggingSink
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.默认简单配置，输出至控制台

            // ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            // // 默认简单配置，输出至控制台
            // BasicConfigurator.Configure(repository);
            // ILog log = LogManager.GetLogger(repository.Name,"NETCorelog4net");

            // log.Info("NETCorelog4net log");
            // log.Info("test log");
            // log.Error("error");
            // log.Info("linezero");
            // Console.ReadKey();

            // Console.WriteLine("Hello World!");

            #endregion

            #region 2.log4net记录日志(本地)

            // ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            // log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"ConfigFile\log4net_internal.config"));
            // ILog log = LogManager.GetLogger(repository.Name,"NETCorelog4net");

            // log.Info("NETCorelog4net log");
            // log.Info("test log");
            // log.Error("error");
            // log.Info("linezero");

            #endregion

            #region 3.log4net记录日志（类库）
           
            LogHelper.Log.Info("基础信息");
            LogHelper.LoadLogger("Internal","log4net_internal.config");
            LogHelper.Log.Info("内部信息");

            #endregion
            
            Console.ReadKey();
        }
    }
}
