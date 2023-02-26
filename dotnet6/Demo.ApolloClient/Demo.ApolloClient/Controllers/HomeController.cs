using Microsoft.AspNetCore.Mvc;

namespace Demo.ApolloClient.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            var data = _config["Key"];
            return View();
        }
    }
}
