using Demo.ConsulDiscovery.Discovery;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ConsulDiscovery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : ControllerBase
    {
        private readonly ServiceDiscovery ServiceDiscovery;
        public AggregateController(ServiceDiscovery serviceDiscovery)
        {
            ServiceDiscovery = serviceDiscovery;
        }
        [HttpGet]
        public JsonResult GetAggre()
        {
            var nodes = ServiceDiscovery.Discovery("ProductService"); // 集群会有多个

            // 建立连接
            var productChannel = GrpcChannel.ForAddress(nodes[0].Url);

            // 客户端创建
            //var client = new IProductService.IProductServiceClient(productChannel);

            // 参考gRPCdemo处理

            return new JsonResult("OK");

        }
    }
}
