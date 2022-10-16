using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AOP
{
    public class AccountService : IAccountService
    {
        public void Register(string userId, string pwd)
        {
            Console.WriteLine("AccountService Register");
        }
    }
}
