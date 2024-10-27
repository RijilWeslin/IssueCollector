using Microsoft.AspNetCore.Mvc;
using SolutionSphere.Application.IServices;
using SolutionSphere.Core.Entities;

namespace SolutionSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueDataController : ControllerBase
    {
        private readonly IIssueDataService _issueDataService;
        public IssueDataController(IIssueDataService issueDataService)
        {
            _issueDataService = issueDataService;
        }

        [HttpGet("GetAll/{page}/{pageSize}")]
        public Pagination<IssueData> GetAll(int page=1, int pageSize = 8)
        {
            return _issueDataService.GetAll(page, pageSize);                                               
        }

        [HttpGet("GetAllUnDeleted/{page}/{pageSize}")]
        public Pagination<IssueData> GetAllUnDeleted(int page = 1, int pageSize = 8)
        {
            return _issueDataService.GetAllUnDeleted(page, pageSize);
        }

        [HttpGet("GetByUserId/{UserId}")]
        public List<IssueData> GetByUserId(int UserId)
        {
            return _issueDataService.GetByUserId(UserId);
        }

        [HttpPost("Add")]
        public void Add([FromBody]IssueData issue)
        {
            _issueDataService.Add(issue);
        }

        [HttpPut("Update")]
        public void Update(IssueData issue)
        {
            _issueDataService.Update(issue);
        }

        [HttpGet("Delete")]
        public void Delete(int id)
        {
            _issueDataService.Delete(id);
        }

        [HttpGet("SoftDelete/{issueId}")]
        public void SoftDelete(int issueId)
        {
            _issueDataService.SoftDelete(issueId);
        }
    }
}
