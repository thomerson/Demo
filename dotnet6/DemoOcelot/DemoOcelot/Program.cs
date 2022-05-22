using DemoOcelot.Aggregate;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Kubernetes;
using Ocelot.Provider.Polly;
using Ocelot.Cache.CacheManager;
using Ocelot.Cache;
using DemoOcelot.midware;

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
    s.AddOcelot()
    .AddPolly()
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    }); // ocelot��CacheManager
    //s.AddSingleton<IOcelotCache<CachedResponse>, OcelotCache<CachedResponse>>();
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
