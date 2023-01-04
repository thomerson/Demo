using Demo.IocNinject.Contract;
using Demo.IocNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.IocNinject.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Add(User item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var list = new List<User>() { };
            list.Add(new User() { Id = 1, Name = "Tom" });
            list.Add(new User() { Id = 2, Name = "Jerry" });
            list.Add(new User() { Id = 3, Name = "Kim" });
            return list;
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}