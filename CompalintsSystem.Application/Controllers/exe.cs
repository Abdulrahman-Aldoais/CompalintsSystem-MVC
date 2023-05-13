using Microsoft.AspNetCore.Mvc;

namespace CompalintsSystem.Application.Controllers
{
    public class exe : Controller
    {
        public IActionResult mainpage()
        {
            return View();
        }
    }
}
