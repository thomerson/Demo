using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new List<string>() { "Tom", "Jerry" });
        }
    }
}
