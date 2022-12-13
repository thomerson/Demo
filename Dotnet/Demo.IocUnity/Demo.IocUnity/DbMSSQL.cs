using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IocUnity
{
    class DbMSSQL : IDbInterface
    {
        public string Delete()
        {
            return "MSSQL执行删除";
        }

        public string Insert()
        {
            return "MSSQL执行插入";
        }

        public string Query()
        {
            return "MSSQL执行查询";
        }

        public string Update()
        {
            return "MSSQL执行更新";
        }
    }
}
