using Demo.IocNinject.Contract;
using Demo.IocNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.IocNinject.Controllers
{
    public class ValuesController : ApiController
    {

        //private readonly IUserRepository repository;

        //public ValuesController(IUserRepository repository)
        //{
        //    this.repository = repository;
        //}

        // GET api/values
        public IEnumerable<User> Get()
        {
            //var data = repository.GetAll();
            var data = new List<User>() { };
            data.Add(new User() { Id = 1, Name = "Tom" });
            data.Add(new User() { Id = 2, Name = "Jerry" });
            data.Add(new User() { Id = 3, Name = "Kim" });


            return data;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
