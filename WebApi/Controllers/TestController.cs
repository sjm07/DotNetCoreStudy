using Microsoft.AspNetCore.Mvc;
using ToolLibrary.Common;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;

namespace WebApi.Controllers
{
    /*两者使用其一都可以，这个是配置Controller级别*/
    //[Route("api/test")]
    [Route("api/[controller]")]
    public class TestController:ControllerBase
    {
        //private MyOptions _options;
        private Subsection _options;
        public TestController(IOptions<Subsection> Options)
        {
            _options = Options.Value;
        }

        [HttpGet]
        [Route("WriteLogger")]
        //[Route("api/test/WriteLogger")]
        /*写日志*/
        public string WriteLogger()
        {
            LogHelper.Log.Info("通过log4net写日志!");
            return "通过log4net写日志!";
        }

        [HttpPost]
        [Route("api/test/ReadWebConfig")]
        public JObject ReadWebConfig()
        {
            JObject resultObj = new JObject();
            string Log4netConfigFile = ConfigurationManager.AppSettings["Log4netConfigFile"].ToString();
            string MasterConnString = ConfigurationManager.ConnectionStrings["MasterConnString"].ToString();
            resultObj["Log4netConfigFile"] = Log4netConfigFile;
            resultObj["MasterConnString"] = MasterConnString;
            return resultObj;
        }

        [HttpGet]
        [Route("ReadJsonConfig")]
        public string ReadJsonConfig()
        {
           //string value =  ConfigHelper.GetSectionValue("Logging:LogLevel:Default");
           return _options.suboption1;
           return "sjm";
        }
    }
}