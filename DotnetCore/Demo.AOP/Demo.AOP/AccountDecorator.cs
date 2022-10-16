using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AOP
{
    public class AccountDecorator : IAccountService
    {
        private IAccountService AccountService;
        public AccountDecorator(IAccountService accountService)
        {
            this.AccountService = accountService;
        }

        public void Register(string userId, string pwd)
        {
            this.Before();
            this.AccountService.Register(userId, pwd);
            this.After();
        }

        public void Before()
        {
            Console.WriteLine("AccountDecorator Before");
        }

        public void After()
        {
            Console.WriteLine("AccountDecorator After");
        }
    }
}
