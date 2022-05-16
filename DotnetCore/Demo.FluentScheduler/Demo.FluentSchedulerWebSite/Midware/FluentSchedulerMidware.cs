using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Demo.FluentSchedulerWebSite.Midware
{
    public static class FluentSchedulerMidware
    {
        public static void AddFluentSchedulerMidware(this IServiceCollection services)
        {
            //扫描当前程序集中实现了Registry的类
            var registrys = Assembly.GetExecutingAssembly().GetTypes()
                                   .Where(t => !t.IsInterface && !t.IsSealed && !t.IsAbstract && typeof(Registry).IsAssignableFrom(t))
                                   .Select(s => s.Assembly.CreateInstance(s.FullName) as Registry)?.ToArray();

            // 注册同步服务
            JobManager.Initialize(registrys);
        }
    }
}
