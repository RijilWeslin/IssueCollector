using Microsoft.AspNetCore.Mvc;

namespace SolutionSphere.Web.Controllers
{
    public class FocusBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
