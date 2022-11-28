using Demo.gRPCService.ProductProto;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.gRPCServer.ProductService.Services
{
    /// <summary>
    /// 商品服务实现
    /// </summary>
    public class ProductServiceImpl : IProductService.IProductServiceBase
    {
        public override Task<ProductResponse> GetProducts(ProductRequest request, ServerCallContext context)
        {
            // 入参
            Console.WriteLine($"request:{request.Id},{request.Name}");

            // 业务逻辑

            // 出参
            var response = new ProductResponse() { Message = "请求成功", Status = 0 };

            return Task.FromResult<ProductResponse>(response); // 同步转异步
            //return base.GetProducts(request, context);
        }

        public override Task<ProductsResponse> GetProductById(ProductRequest request, ServerCallContext context)
        {
            // 入参
            Console.WriteLine($"request:{request.Id},{request.Name}");

            // 业务逻辑

            // 集合出参
            var response = new ProductsResponse() { };

            response.Product.Add(new ProductResponse() { Message = "请求成功", Status = 0 });

            return Task.FromResult<ProductsResponse>(response); // 同步转异步
        }

        public override Task GetProductsStream(ProductRequest request, IServerStreamWriter<ProductResponse> responseStream, ServerCallContext context)
        {
            responseStream.WriteAsync(new ProductResponse());

            //context.WriteOptions
            // 设置流的大小
            responseStream.WriteOptions=new WriteOptions() { 
            
            };

            return base.GetProductsStream(request, responseStream, context);
        }
    }
}
