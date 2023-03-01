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
    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true) //reloadOnChange:����ʱ���¼��� JSON ����
    .AddJsonFile("ocelot.json")
    .AddEnvironmentVariables();//���ֻ���
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
    //        config.WithAllowAdmin().WithPassword("redisPsd")//Redis ���� ����
    //        .WithDatabase(0)  //���ݿ�
    //        .WithEndpoint("localhost",6379); //Redis �����ַ �˿�


    //    })
    //    .WithRedisCacheHandle("redis",true);  //using CacheManager.Core;

    //    x.WithJsonSerializer(); //�������л���ʽ

    //    //x.WithDictionaryHandle(); //ocelot��CacheManager  �ֵ䷽ʽ����
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
