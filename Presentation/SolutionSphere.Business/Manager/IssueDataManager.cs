using SolutionSphere.Business.Services;

namespace SolutionSphere.Business.Manager
{
    public interface IIssueDataManager
    {
 
    }

    public class IssueDataManager:IIssueDataManager
    {
        private readonly IIssueDataService _issueDataService;
        public IssueDataManager(IIssueDataService issueDataService) 
        { 
            _issueDataService = issueDataService;
        }
    }
}
