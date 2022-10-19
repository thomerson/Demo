using System;
using System.Collections.Generic;
using System.Text;


namespace Demo.Unity
{
    class AccountService : IAccountService
    {
        public void Register(string userId, string pwd)
        {
            Console.WriteLine("Register");
        }
    }
}
