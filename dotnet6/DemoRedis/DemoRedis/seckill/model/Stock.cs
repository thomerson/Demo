﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRedis.seckill.model
{
    internal class Stock
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
    }
}
