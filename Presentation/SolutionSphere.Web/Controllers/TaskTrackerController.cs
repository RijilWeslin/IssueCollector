using Microsoft.AspNetCore.Mvc;

namespace SolutionSphere.Web.Controllers
{
    public class TaskTrackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
