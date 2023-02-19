using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Demo.IDS4.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddIdentityServer()
            //    .AddInMemoryApiScopes(IdentityServerConfig.Scopes)
            //    .AddInMemoryClients(IdentityServerConfig.Clients)

            //    .AddDeveloperSigningCredential();  

            // 使用内存存储，密钥，客户端和资源来配置身份服务器。
            services.AddIdentityServer()
                .AddInMemoryApiScopes(IdentityServerConfig.Scopes)
                .AddInMemoryClients(IdentityServerConfig.Clients)
                .AddTestUsers(IdentityServerConfig.Users.ToList());


            #region sql 持久化
            //// 将内存模式改为从数据库中读取
            //var strConn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IdentityServer4DB;
            //        Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
            //        ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
          
            //services.AddIdentityServer()
            //    // 配置ConfigurationDBContext上下文  针对配置数据，比如客户端(Client)、资Y源(Resources)等
            //    .AddConfigurationStore(options =>
            //    {
            //        options.ConfigureDbContext = dbBuilder =>
            //        {
            //            dbBuilder.UseSqlServer(strConn, t_builder => t_builder.MigrationsAssembly(migrationsAssembly));
            //        };
            //    })
            //    // 配置PersistedGrantDbContext上下文 针对用户授权操作时的数据和临时数据，比如同意授权的数据、Token等
            //    .AddOperationalStore(options =>
            //    {
            //        options.ConfigureDbContext = dbBuilder =>
            //        {
            //            dbBuilder.UseSqlServer(strConn, t_builder => t_builder.MigrationsAssembly(migrationsAssembly));
            //        };
            //    })
            //    ;
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
