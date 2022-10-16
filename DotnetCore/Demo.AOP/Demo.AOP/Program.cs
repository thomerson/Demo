using System;

namespace Demo.AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // 装饰器
            var accountService = new AccountService();
            var decorator = new AccountDecorator(accountService);
            decorator.Register("", "");

            // 代理
            var proxy = new AccountProxy();
            proxy.Register("", "");

            Console.WriteLine("end");
        }
    }
}
