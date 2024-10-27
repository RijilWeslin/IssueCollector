using Microsoft.AspNetCore.Mvc;
using SolutionSphere.Business.Manager;
using SolutionSphere.Business.Services;
using SolutionSphere.Core.Entities;
using SolutionSphere.Web.ViewModels;

namespace SolutionSphere.Web.Controllers
{
    public class IssueTrackerController : Controller
    {
        private readonly IIssueDataService _issueDataService;
        private readonly IProjectsService _projectsService;
        public IssueTrackerController(IIssueDataService issueDataService, IProjectsService projectsService)
        {
            _issueDataService = issueDataService;
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateIssue()
        {
            var model = new IssueTrackerViewModel()
            {
                Projects = await _projectsService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue(IssueData issueData, List<SolutionData> solutionData)
        {
            await _issueDataService.Add(issueData);
            return RedirectToAction("AllIssues");
        }

        [HttpGet]
        public async Task<IActionResult> AllIssues(int page = 1, int pageSize = 8)
        {
            var issues = await _issueDataService.GetAllUnDeleted(page, pageSize);
            var projects = await _projectsService.GetAll();
            var model = new IssueTrackerViewModel()
            {
                Issue = issues,
                Projects = projects
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int issueId)
        {
            await _issueDataService.Delete(issueId);
            return RedirectToAction("AllIssues");
        }
    }
}
