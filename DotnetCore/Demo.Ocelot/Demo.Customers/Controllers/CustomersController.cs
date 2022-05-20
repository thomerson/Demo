using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new string[] { "Catcher Wong", "James Li" });
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Catcher Wong - {id}";
        }
    }
}
