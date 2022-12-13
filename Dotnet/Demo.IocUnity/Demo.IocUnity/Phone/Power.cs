using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IocUnity.Phone
{
    class Power : IPower
    {
        public Power()
        {
            Console.WriteLine("Power 被构造");
        }
    }
}
