using Microsoft.AspNetCore.Mvc;

namespace Demo.IDS4.MvcClient.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
