using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lets.WebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)         
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseHttpSys(options =>
                    //{
                    //    options.Authentication.AllowAnonymous = true;
                    //});
                    webBuilder.UseStartup<Startup>();
                });
    }
}
