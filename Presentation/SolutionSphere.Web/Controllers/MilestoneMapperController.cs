using Microsoft.AspNetCore.Mvc;
//Emphasizes tracking progress towards goals
namespace SolutionSphere.Web.Controllers
{
    public class MilestoneMapperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
