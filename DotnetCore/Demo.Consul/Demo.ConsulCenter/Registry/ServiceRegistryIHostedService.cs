using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ConsulCenter.Registry
{
    public class ServiceRegistryIHostedService : IHostedService
    {
        private readonly IConfiguration _configuration;

        public ServiceRegistryIHostedService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consulClient = new ConsulClient(c =>
            {
                //consul地址
                c.Address = new Uri(_configuration["ConsulSetting:ConsulAddress"]);
            });

            var registration = new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(),//服务实例唯一标识
                Name = _configuration["ConsulSetting:ServiceName"],//服务名
                Address = _configuration["ConsulSetting:ServiceIP"], //服务IP
                Port = int.Parse(_configuration["ConsulSetting:ServicePort"]),//服务端口 因为要运行多个实例，端口不能在appsettings.json里配置，在docker容器运行时传入
                Check = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                    Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔
                    HTTP = $"http://{_configuration["ConsulSetting:ServiceIP"]}:{_configuration["ConsulSetting:ServicePort"]}{_configuration["ConsulSetting:ServiceHealthCheck"]}",//健康检查地址
                    Timeout = TimeSpan.FromSeconds(5)//超时时间
                }
            };

            //服务注册
            consulClient.Agent.ServiceRegister(registration).Wait();

            //服务关闭
            consulClient.Dispose();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
