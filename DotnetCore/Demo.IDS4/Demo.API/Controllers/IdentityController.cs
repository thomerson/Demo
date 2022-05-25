using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo.API.Controllers
{
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public JsonResult Index()
        {
            var result = from c in User.Claims select new { c.Type, c.Value };
            return new JsonResult(result);
        }
    }
}
