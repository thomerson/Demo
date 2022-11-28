using Demo.gRPCaggregate.Client;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.gRPCaggregate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region 查询商品微服务

            //// 1. 建立连接
            //using (var grpcChannel = GrpcChannel.ForAddress("https://localhost:44350"))
            //{
            //    // 2. 创建client
            //    var client = new ProductService.ProductServiceClient(grpcChannel);

            //    // 3. 开始调用
            //    var response = client.GetProducts(new ProductRequest()
            //    {
            //        Id = 1,
            //        Name = ""
            //    });

            //    // 业务
            //    Console.WriteLine($"response:{response.Status},{response.Message}");
            //}

            #endregion


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
