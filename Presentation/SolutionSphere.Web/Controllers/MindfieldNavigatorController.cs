using Microsoft.AspNetCore.Mvc;

//Creates a sense of tackling challenges effectively
namespace SolutionSphere.Web.Controllers
{
    public class MindfieldNavigatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
