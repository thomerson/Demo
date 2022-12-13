using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IocUnity.Phone
{
    class Headphone : IHeadphone
    {
        public Headphone()
        {
            Console.WriteLine("Headphone 被构造");
        }
    }
}
