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
            #region ��ѯ��Ʒ΢����

            //// 1. ��������
            //using (var grpcChannel = GrpcChannel.ForAddress("https://localhost:44350"))
            //{
            //    // 2. ����client
            //    var client = new ProductService.ProductServiceClient(grpcChannel);

            //    // 3. ��ʼ����
            //    var response = client.GetProducts(new ProductRequest()
            //    {
            //        Id = 1,
            //        Name = ""
            //    });

            //    // ҵ��
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
