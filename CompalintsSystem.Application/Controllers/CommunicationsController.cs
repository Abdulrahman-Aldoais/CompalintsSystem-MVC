using Microsoft.AspNetCore.Mvc;

namespace CompalintsSystem.Application.Controllers
{
    public class CommunicationsController : Controller
    {
        [Area("Beneficiarie")]
        public IActionResult AllCommunication()
        {
            return View();
        }
        public IActionResult AddCommunication()
        {
            return View();
        }
    }
}
