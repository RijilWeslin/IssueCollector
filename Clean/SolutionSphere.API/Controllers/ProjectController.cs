using Microsoft.AspNetCore.Mvc;
using SolutionSphere.Application.IServices;
using SolutionSphere.Core.Entities;

namespace SolutionSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService) { 
            _projectService = projectService;
        }

        [HttpGet("Get")]
        public List<Project> Get()
        {
           return _projectService.GetAll();
        }

        [HttpPost("Add")]
        public void Add(Project project)
        {
            _projectService.Add(project);
        }

        [HttpPut("Update")]
        public void Update(Project project)
        {
            _projectService.Update(project);
        }

        [HttpGet("Delete")]
        public void Delete(Guid id)
        {
            var project = _projectService.GetAll().FirstOrDefault(p => p.ProjectId == id);
            _projectService.Delete(project);
        }
    }
}
