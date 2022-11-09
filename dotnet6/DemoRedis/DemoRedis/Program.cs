using StackExchange.Redis;
using Newtonsoft.Json;

namespace DemoRedis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection = "127.0.0.1:6379";
            var redisClient = ConnectionMultiplexer.Connect(connection);
            var db = redisClient.GetDatabase();

            #region string
            db.StringSet("userName", "admin");

            var test = db.StringGet("userName");

            Console.WriteLine($"test:{test}");

            //var val = db.StringGetDelete("userName", CommandFlags.None); // 不支持

            //Console.WriteLine($"userName:{val}");

            #endregion

            #region hash

            db.HashSet("hash", "hash-key", "value");
            db.HashSet("hash", "hash-name", "name");
            db.HashSet("hash", "hash-id", 1);
            db.HashSet("hash", "hash-time", DateTime.Now.ToString());

            var hash = db.HashGetAll("hash");

            Console.WriteLine($"hash:{JsonConvert.SerializeObject(hash)}");

            var hash_time = db.HashGet("hash", "hash-time");
            Console.WriteLine($"hash_time:{hash_time}");

            #endregion


            #region list
            db.ListLeftPush("list", "redis");
            db.ListLeftPush("list", "mongodb");
            db.ListLeftPush("list", "mysql");
            db.ListLeftPush("list", "redis");

            var list = db.ListRange("list", 0);

            foreach (var item in list)
            {
                Console.WriteLine($"item:{item}");
            }

            #endregion


            #region set

            db.SetAdd("set", "redis");
            db.SetAdd("set", "mongodb");
            db.SetAdd("set", "mysql");
            db.SetAdd("set", "redis");

            var set = db.SetMembers("set");

            foreach (var item in set)
            {
                Console.WriteLine($"set:{item}");
            }

            #endregion

            #region zset

            db.SortedSetAdd("zset", "redis", 0.5);
            db.SortedSetAdd("zset", "mongodb", 0.2);
            db.SortedSetAdd("zset", "mysql", 0.3);

            var zsort = db.SortedSetRangeByScore("zset");

            foreach (var item in zsort)
            {
                Console.WriteLine($"zset:{item}");
            }

            #endregion


            Console.WriteLine("Hello, World!");
        }
    }
}