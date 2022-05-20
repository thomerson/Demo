using Microsoft.AspNetCore.Http;
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
            return new JsonResult(new List<string>() { "Fish", "Milk" });
        }
    }
}
