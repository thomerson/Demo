using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Unity
{
    class ApplePhone : IPhone
    {
        public void Call()
        {
            Console.WriteLine("ApplePhone Call");
        }
    }
}
