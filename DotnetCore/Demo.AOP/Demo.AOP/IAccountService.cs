using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AOP
{
    public interface IAccountService
    {
        void Register(string userId, string pwd);
    }
}
