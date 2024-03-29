﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            Thread.Sleep(5000);
            return new JsonResult(new List<string>() { "Fish", "Milk" });
        }
    }
}
