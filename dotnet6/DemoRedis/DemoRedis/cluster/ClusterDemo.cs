using StackExchange.Redis;

namespace DemoRedis.cluster
{
    internal class ClusterDemo
    {

        public void Test()
        {
            // reids集群,逗号分隔服务器
            var redisClient = ConnectionMultiplexer.Connect("127.0.0.1:6379,127.0.0.1:6380,127.0.0.1:6381,127.0.0.1:6382");

            var db = redisClient.GetDatabase();

            // 参考RedisDemo操作
        }
    }
}
