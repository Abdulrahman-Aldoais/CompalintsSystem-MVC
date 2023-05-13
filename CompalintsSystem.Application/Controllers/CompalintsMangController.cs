using Microsoft.AspNetCore.Mvc;

namespace CompalintsSystem.Application.Controllers
{
    public class CompalintsMangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
