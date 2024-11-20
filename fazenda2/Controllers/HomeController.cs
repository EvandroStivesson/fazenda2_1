using fazenda2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fazenda2.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet("[action]")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpGet("[action]")]
        public IActionResult SaibaMais()
        {
            return View();
        }
    }
}
