using DemoRedis.seckill.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRedis.seckill
{
    /// <summary>
    /// 商品秒杀
    /// </summary>
    internal class ProductSkill
    {
        private List<Stock> Stocks = new List<Stock>() { };

        public ProductSkill()
        {
            Stocks.Add(new Stock() { Id = 1, Count = 100 });
            Stocks.Add(new Stock() { Id = 2, Count = 100 });
        }

        public void Skill()
        {
            // 单进程处理 加lock
            //lock (this)
            //{

            //}


            // 多进程
            var redisLcok = new RedisLock();
            redisLcok.Lock();

            // 获取商品库存
            var stock = getProductStocks();

            if (stock.Count == 0)
            {
                //秒杀失败
                Console.WriteLine($"线程{Thread.CurrentThread.ManagedThreadId}：库存不足，秒杀失败，库存数：{stock.Count}");

                redisLcok.Unlock();
                return;
            }

            // 秒杀成功
            Console.WriteLine($"线程{Thread.CurrentThread.ManagedThreadId}：秒杀成功，库存数：{stock.Count}");

            // 扣除库存
            SubtractProductStock();

            redisLcok.Unlock();
        }

        private Stock getProductStocks()
        {
            // DB 读取
            var stock = this.Stocks.First(f => f.Id == 1);
            return stock;
        }

        /// <summary>
        /// 扣减商品库存
        /// </summary>
        private void SubtractProductStock()
        {
            var stock = this.Stocks.First(f => f.Id == 1);

            stock.Count = stock.Count - 1;


            Console.WriteLine($"扣除库存成功：{stock.Count}");

            //UpdateDB savechanges

        }
    }
}
