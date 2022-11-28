using Consul;
using Demo.gRPCaggregate.Client.Discovery.Model;
using System;
using System.Collections.Generic;
using System.Net;

namespace Demo.gRPCaggregate.Client.Discovery
{
    public class ServiceDiscovery
    {
        public List<ServiceNode> Discovery(string serviceName)
        {
            CatalogService[] queryResult = RemoteDiscovery(serviceName);
            var list = new List<ServiceNode>();

            foreach (var service in queryResult)
            {
                list.Add(new ServiceNode()
                {
                    Url = service.Address + ":" + service.ServicePort
                });
            }
            return list;
        }

        private CatalogService[] RemoteDiscovery(string serviceName)
        {
            // 1. 建立Consul连接
            var consulClient = new ConsulClient(c =>
            {
                //consul地址
                c.Address = new Uri("http://localhost:8500");
            });

            // 2. consul根据名称查询服务
            var queryResult = consulClient.Catalog.Service(serviceName).Result;

            // 3. 判断请求是否失败
            if (!queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                throw new Exception($"consul连接失败:{queryResult.StatusCode}");
            }

            return queryResult.Response;

        }
    }
}
