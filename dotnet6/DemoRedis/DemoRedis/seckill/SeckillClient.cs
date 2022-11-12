using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRedis.seckill
{
    internal class SeckillClient
    {
        /// <summary>
        /// 秒杀客户端
        /// </summary>
        /// <param name="threadCount">线程数</param>
        public static void Skill(int threadCount)
        {
            var productSkill = new ProductSkill();
            for (int i = 0; i < threadCount; i++)
            {
                var thread = new Thread(() =>
                {
                    productSkill.Skill();
                });
                thread.Start();
            }
        }
    }
}
