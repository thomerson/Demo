using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Unity
{
    interface IAccountService
    {
        void Register(string userId, string pwd);
    }
}
