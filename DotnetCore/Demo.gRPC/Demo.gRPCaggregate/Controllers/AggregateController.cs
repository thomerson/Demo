using Demo.gRPCaggregate.Client.Discovery;
using Demo.gRPCaggregate.Client.Discovery.Model;
using Demo.gRPCService.ProductProto;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.gRPCaggregate.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : ControllerBase
    {
        private readonly IProductService.IProductServiceClient _productServiceClient;
        private readonly ServiceDiscovery ServiceDiscovery;
        private readonly ServiceDiscoveryOptions ServiceDiscoveryOptions;
        public AggregateController(
            IProductService.IProductServiceClient productServiceClient,
            ServiceDiscovery serviceDiscovery,
           IOptions<ServiceDiscoveryOptions> options)
        {
            this._productServiceClient = productServiceClient;
            this.ServiceDiscovery = serviceDiscovery;
            this.ServiceDiscoveryOptions = options.Value;
        }

        [HttpGet]
        [Route("GetById")]
        public JsonResult GetById()
        {

            // 其他服务同样使用
            var response = _productServiceClient.GetProducts(new ProductRequest()
            {
                Id = 1,
                Name = ""
            });

            Console.WriteLine($"response:{response.Status},{response.Message}");

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("GetList")]
        public JsonResult GetList()
        {
            var nodes = ServiceDiscovery.Discovery("ProductService"); // 集群会有多个

            // 集群的情况需要做负载均衡算法找到对应的地址
            // 负载均衡

            // 为了防止请求失败，可以加入重试机制，Polly
            // 健康检测也可以防止请求的服务器宕机

            // 建立连接
            var productChannel = GrpcChannel.ForAddress(nodes[0].Url);

            // 通过consul找到服务地址调用gRPC
            var client = new IProductService.IProductServiceClient(productChannel);
            // 其他服务同样使用
            var response = client.GetProducts(new ProductRequest()
            {
                Id = 1,
                Name = ""
            });

            Console.WriteLine($"response:{response.Status},{response.Message}");

            return new JsonResult(response);
        }
    }
}
