using StackExchange.Redis;

namespace DemoRedis
{
    internal class RedisLock
    {
        private ConnectionMultiplexer ConnectionMultiplexer;

        private IDatabase Database;

        public RedisLock()
        {
            ConnectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            Database = ConnectionMultiplexer.GetDatabase();
        }

        public void Lock()
        {
            // 防止加锁失败
            while (true)
            {
                // lock name
                // lock value :用当前线程id【一般秒杀用商品库存id】
                // 超时时间: 防止死锁

                var flag = Database.LockTake("lock.name", Thread.CurrentThread.ManagedThreadId, TimeSpan.FromMinutes(1));

                // 加锁成功
                if (flag)
                {
                    break;
                }


                // 线程休眠，防止死循环造成系统宕机
                Thread.Sleep(500);
            }

        }

        public void Unlock()
        {
            // lock name
            // lock value :防止锁被其他线程释放【一般秒杀用商品库存id】
            Database.LockRelease("lock.name", Thread.CurrentThread.ManagedThreadId);

            ConnectionMultiplexer.Dispose();

        }
    }
}
