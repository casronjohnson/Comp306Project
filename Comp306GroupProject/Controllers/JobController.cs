using Microsoft.AspNetCore.Mvc;

namespace Comp306GroupProject.Controllers
{
    public class JobController : Controller
    {
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Jobs()
        {
            return View();
        }
    }
}
