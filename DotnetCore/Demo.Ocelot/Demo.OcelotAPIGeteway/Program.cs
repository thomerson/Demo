using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.OcelotAPIGeteway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config
                .SetBasePath(context.HostingEnvironment.ContentRootPath)
                .AddJsonFile("Ocelot.json");
            })
             .ConfigureServices(s =>
             {
                 s.AddOcelot();
                 s.AddSingletonDefinedAggregator<FakeDefinedAggregator>();
                 s.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
             })
             .Configure(a =>
             {
                 a.UseOcelot().Wait();
             });
        //.ConfigureWebHostDefaults(webBuilder =>
        //{
        //    webBuilder.UseStartup<Startup>();
        //});
    }
}
