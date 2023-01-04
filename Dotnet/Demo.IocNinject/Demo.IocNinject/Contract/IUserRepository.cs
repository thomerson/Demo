using Demo.IocNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IocNinject.Contract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Add(User item);
        bool Update(User item);
        bool Delete(int id);
    }
}
