using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IocUnity.Phone
{
    class Microphone : IMicrophone
    {
        public Microphone()
        {
            Console.WriteLine("Microphone 被构造");
        }
    }
}
