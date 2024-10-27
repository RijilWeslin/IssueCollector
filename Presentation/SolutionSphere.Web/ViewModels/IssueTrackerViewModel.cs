using SolutionSphere.Core.Entities;

namespace SolutionSphere.Web.ViewModels
{
    public class IssueTrackerViewModel
    {
        public Pagination<IssueData> Issue { get; set; }
        public List<Project> Projects { get; set; }
    }
}
