using DemoOcelot.Aggregate;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Kubernetes;
using Ocelot.Provider.Polly;
using Ocelot.Cache.CacheManager;
using CacheManager.Redis;
using Ocelot.Cache;
using DemoOcelot.midware;
using CacheManager.Core;
using Microsoft.Extensions.DependencyInjection;
using SkyApm.Utilities.DependencyInjection;

var builder = new WebHostBuilder();

builder.UseKestrel();

builder.UseContentRoot(Directory.GetCurrentDirectory());

builder.ConfigureAppConfiguration((hostingContext, config) =>
{
    config
    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true) //reloadOnChange:更改时重新加载 JSON 配置
    .AddJsonFile("ocelot.json")
    .AddEnvironmentVariables();//多种环境
});

builder.ConfigureServices(s =>
{
    s.AddAuthentication()
    .AddJwtBearer("customer.api", option =>
    {
        option.Audience = "customer.api";
        option.Authority = "http://localhost:5146";
        option.RequireHttpsMetadata = false;
    }).AddJwtBearer("product.api", y =>
    {
        y.Audience = "product.api";
        y.Authority = "http://localhost:5026";
        y.RequireHttpsMetadata = false;
    });

    s.AddSkyApmExtensions();  //skywalking 

    s.AddOcelot()
    .AddConsul()
    .AddPolly();
    //.AddCacheManager(x =>
    //{
    //    x.WithRedisConfiguration("redis", config =>
    //    {
    //        config.WithAllowAdmin().WithPassword("redisPsd")//Redis 配置 密码
    //        .WithDatabase(0)  //数据库
    //        .WithEndpoint("localhost",6379); //Redis 服务地址 端口


    //    })
    //    .WithRedisCacheHandle("redis",true);  //using CacheManager.Core;

    //    x.WithJsonSerializer(); //数据序列化方式

    //    //x.WithDictionaryHandle(); //ocelot的CacheManager  字典方式处理
    //});

    s.AddSingleton<IOcelotCache<CachedResponse>, OcelotCache<CachedResponse>>();
    //.AddKubernetes();
    //.AddSingletonDefinedAggregator<FooAggregator>();
    //.AddConsul()//Consul
    //.AddConfigStoredInConsul();  // ConsulConfig
}).ConfigureLogging((hostingContext, logging) =>
{
    Console.WriteLine(logging);
}).UseIISIntegration()
.Configure(app =>
{
    app.UseOcelot().Wait();
})
.Build()
.Run();

//var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config
//    //.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
//    .AddJsonFile("appsettings.json", true, true)
//    //.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
//    .AddJsonFile("ocelot.json")
//    .AddEnvironmentVariables();
//});

//builder.WebHost.ConfigureServices(s =>
//{
//    s.AddOcelot();
//}).Configure(app =>
//{
//    app.UseOcelot().Wait();
//});


//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//}


//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();


//app.Run();
