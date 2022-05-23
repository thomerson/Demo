using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo.IDS4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public JsonResult Get()
        {
            var result = User.Claims.Select(s => new { s.Type, char.MinValue });

            return new JsonResult(result);
        }
    }
}
