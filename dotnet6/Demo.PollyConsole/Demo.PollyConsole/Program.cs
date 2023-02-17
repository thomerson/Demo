// See https://aka.ms/new-console-template for more information
using Polly;
using System.Net;
using Polly.Fallback;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Caching.Memory;
using Polly.Caching.Memory;
using Microsoft.Extensions.Logging;
using Polly.Caching;

Console.WriteLine("Hello, World!");

#region Polly


Console.WriteLine($"重试策略");

Policy
        // 1. 指定要处理什么异常
        .Handle<HttpRequestException>()
        //    或者指定需要处理什么样的错误返回
        .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.BadGateway)
        // 2. 指定重试次数和重试策略
        .Retry(3, (exception, retryCount, context) =>
        {
            Console.WriteLine($"开始第 {retryCount} 次重试：");
        })
        // 3. 执行具体任务
        .Execute(ExecuteMockRequest);

Console.WriteLine($"断路策略");

Policy.Handle<HttpRequestException>()
    .CircuitBreaker(2, TimeSpan.FromMinutes(1)) //策略是，当系统出现两次某个异常时，就停下来，等待 1 分钟后再继续
    .Execute(ExecuteMockRequest);


Console.WriteLine($"超时策略");
Policy.Timeout(30, onTimeout: (context, timespan, task) => //30s超时
{
    // do something
}).Execute(ExecuteMockRequest);



Console.WriteLine($"隔离策略");
Policy.Bulkhead(12, context => // 最多允许 12 个线程并发执行，如果执行被拒绝，则执行回调
{
    // do something
}).Execute(ExecuteMockRequest);




Console.WriteLine($"回退策略");
Policy.Handle<Exception>()
   .Fallback(() =>
   {
       // do something
   })
   .Execute(ExecuteMockRequest);


Console.WriteLine($"缓存策略");


var memoryCache = new MemoryCache(new MemoryCacheOptions());
var memoryCacheProvider = new MemoryCacheProvider(memoryCache);
var cachePolicy = Policy.Cache(memoryCacheProvider, TimeSpan.FromMinutes(5));

//var cachePolicy = Policy.Cache(memoryCacheProvider, new AbsoluteTtl(DateTimeOffset.Now.Date.AddDays(1));

// Define a cache policy with sliding expiration: items remain valid for another 5 minutes each time the cache item is used.
//var cachePolicy = Policy.Cache(memoryCacheProvider, new SlidingTtl(TimeSpan.FromMinutes(5));

// Define a cache Policy, and catch any cache provider errors for logging.
//var cachePolicy = Policy.Cache(memoryCacheProvider, TimeSpan.FromMinutes(5),
//(context, key, ex) => {
//       Console.WriteLine($"Cache provider, for key {key}, threw exception: {ex}."); // (for example)
//   }
//);

static HttpResponseMessage ExecuteMockRequest()
{
    // 模拟网络请求
    Console.WriteLine("正在执行网络请求...");
    Thread.Sleep(3000);
    // 模拟网络错误
    return new HttpResponseMessage(HttpStatusCode.BadGateway);
}

#endregion

Console.WriteLine("程序结束，按任意键退出。");
Console.ReadKey();