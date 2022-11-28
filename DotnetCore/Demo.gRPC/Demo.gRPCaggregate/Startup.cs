using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.gRPCaggregate.Client;
using Grpc.Net.Client;
using Demo.gRPCService.ProductProto;
using Demo.gRPCaggregate.Client.Discovery;
using Demo.gRPCaggregate.Client.Discovery.Model;
using Microsoft.Extensions.Configuration;

namespace Demo.gRPCaggregate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpcClient<IProductService.IProductServiceClient>(options =>
            {
                options.Address = new Uri("https://localhost:44350");
            });

            // 注册config
            services.Configure<ServiceDiscoveryOptions>(Configuration.GetSection("ConsulSetting"));

            // 添加服务发现
            services.AddSingleton<ServiceDiscovery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
