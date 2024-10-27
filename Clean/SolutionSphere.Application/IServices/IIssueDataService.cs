using SolutionSphere.Core.Entities;
using X.PagedList;

namespace SolutionSphere.Application.IServices
{
    public interface IIssueDataService
    {
        public Pagination<IssueData> GetAll(int page = 1, int pageSize = 8);
        public Pagination<IssueData> GetAllUnDeleted(int page = 1, int pageSize = 8);
        public List<IssueData> GetByUserId(int UserId);
        public void Add(IssueData issue);
        public void Update(IssueData issue);
        public void Delete(int id);
        public void SoftDelete(int id);
    }
}
