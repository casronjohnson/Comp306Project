using Microsoft.AspNetCore.Mvc;

namespace Comp306GroupProject.Controllers
{
    public class JobController : Controller
    {
        [HttpGet]
        public IActionResult Jobs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}
