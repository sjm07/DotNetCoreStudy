using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ToolLibrary.Common
{
    public static class ConfigHelper
    {
        private static IConfiguration _configuration;

        static ConfigHelper()
        {
            // var fileName = "appsettings.json";
            // var directory = AppContext.BaseDirectory;
            // directory = directory.Replace("\\","/");
            // var filePath = $"{directory}/{fileName}";
            // if(!File.Exists(filePath))
            // {
            //     var length = directory.IndexOf("/bin");
            //     filePath = $"{directory.Substring(0,length)}/{fileName}";
            // }

            // var builder = new ConfigurationBuilder().AddJsonFile(filePath, false, true);

            // _configuration = builder.Build();
        }

        public static T GetAppSettings<T>(string fileName, string key) where T : class, new()
        {
            // 获取bin目录路径
            var directory = AppContext.BaseDirectory;
            directory = directory.Replace("\\", "/");

            var filePath = $"{directory}/{fileName}";
            if (!File.Exists(filePath))
            {
                var length = directory.IndexOf("/bin");
                filePath = $"{directory.Substring(0, length)}/{fileName}";
            }

            var builder = new ConfigurationBuilder();
            
            builder.AddJsonFile(filePath, false, true);
            _configuration = builder.Build();

            var appconfig = new ServiceCollection()
                .AddOptions()
                //.Configure<T>(_configuration)
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;

            return appconfig;
        }

        public static string GetSectionValue(string key)
        {
            return "sj";
            // var data = _configuration["Data"];
            // var defaultcon = _configuration.GetConnectionString("DefaultConnection");
            // var devcon = _configuration["ConnectionStrings:DevConnection"];
            // var s = _configuration.GetConnectionString("t");
            // return s;
            //return _configuration.GetSection(key).Value;
        }
    }
}
