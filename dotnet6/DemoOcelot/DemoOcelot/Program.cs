using DemoOcelot.Aggregate;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Kubernetes;

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
    .AddKubernetes();
    //.AddSingletonDefinedAggregator<FooAggregator>();
    //.AddConsul() //Consul
    //.AddConfigStoredInConsul();
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
