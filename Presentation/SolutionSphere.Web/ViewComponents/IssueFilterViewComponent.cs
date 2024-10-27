using Microsoft.AspNetCore.Mvc;

namespace SolutionSphere.Web.ViewComponents
{
    public class IssueFilterViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("IssueFilter");
        }
    }
}
