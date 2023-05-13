using CompalintsSystem.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompalintsSystem.Application.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public ILogger<HomeController> Logger => _logger;
        //public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
