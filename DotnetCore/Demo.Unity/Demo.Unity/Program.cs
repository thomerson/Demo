using System;
using Unity;

namespace Demo.Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、定义一个空容器
            var container = new UnityContainer();

            //2、注册类型
            container.RegisterType<IAccountService, AccountService>();
            var service = container.Resolve<IAccountService>();

            service.Register("", "");

            // 3、注册实例
            container.RegisterInstance<IAccountService>(new AccountService());


        }
    }
}
