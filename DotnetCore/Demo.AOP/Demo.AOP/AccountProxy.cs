using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AOP
{
    public class AccountProxy
    {
        private readonly IAccountService AccountService;
        public AccountProxy()
        {
            AccountService = new AccountService();
        }

        public void Register(string userId, string pwd)
        {
            this.Before();
            this.AccountService.Register(userId, pwd);
            this.After();
        }

        public void Before()
        {
            Console.WriteLine("AccountProxy Before");
        }

        public void After()
        {
            Console.WriteLine("AccountProxy After");
        }
    }
}
