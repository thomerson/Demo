using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Demo.IocUnity.Phone
{
    class ApplePhone : IPhone
    {
        [Dependency]//属性注入
        public IMicrophone iMicrophone { get; set; }
        public IHeadphone iHeadphone { get; set; }
        public IPower iPower { get; set; }

        [InjectionConstructor]//构造函数注入
        public ApplePhone(IHeadphone headphone)
        {
            this.iHeadphone = headphone;
            Console.WriteLine("{0}带参数构造函数", this.GetType().Name);
        }

        public void Call()
        {
            Console.WriteLine("{0}打电话", this.GetType().Name);
        }

        [InjectionMethod]//方法注入
        public void InitPower(IPower power)
        {
            this.iPower = power;
            Console.WriteLine("方法注入");
        }
    }
}
