using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IocUnity
{
    interface IDbInterface
    {
        string Insert();
        string Delete();
        string Update();
        string Query();
    }
}
