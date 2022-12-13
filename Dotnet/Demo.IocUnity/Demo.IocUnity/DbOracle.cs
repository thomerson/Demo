using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IocUnity
{
    class DbOracle : IDbInterface
    {
        public string Delete()
        {
            return "Oracle执行删除";
        }

        public string Insert()
        {
            return "Oracle执行插入";
        }

        public string Query()
        {
            return "Oracle执行查询";
        }

        public string Update()
        {
            return "Oracle执行更新";
        }
    }
}
