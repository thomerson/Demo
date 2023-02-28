using SkyApm.Utilities.DependencyInjection;

namespace Demo.SkywalkingAgent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "SkyAPM.Agent.AspNetCore");
            Environment.SetEnvironmentVariable("SKYWALKING__SERVICENAME", "Service1");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSkyApmExtensions(); //ÃÌº”Skywalkingœ‡πÿ≈‰÷√

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}