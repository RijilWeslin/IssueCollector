using Microsoft.EntityFrameworkCore;
using SolutionSphere.Application.Extensions;
using SolutionSphere.Application.IRepository;
using SolutionSphere.Application.IServices;
using SolutionSphere.Core.Entities;

namespace SolutionSphere.Application.Services
{
    public class IssueDataService : IIssueDataService
    {
        private readonly IRepository<IssueData> _repo;
        public IssueDataService(IRepository<IssueData> repo) 
        { 
            _repo = repo;
        }
        
        public IQueryable<IssueData> GetBase()
        {
            return _repo.Query().Include(t=>t.Solution);
        }

        public IQueryable<IssueData> GetBaseUnDeleted()
        {
            return _repo.Query()
                    .Include(t => t.Solution)
                    .Include(t=> t.Project)
                    .Where(i=>i.DeleteFlag == false);
        }

        public Pagination<IssueData> GetAll(int page = 1, int pageSize = 8)
        {
            return GetBase().AsEnumerable().Pagination(page, pageSize);            
        }

        public Pagination<IssueData> GetAllUnDeleted(int page = 1 , int pageSize = 8)
        {
            return GetBaseUnDeleted().Pagination(page, pageSize);
        }

        public List<IssueData> GetByUserId(int UserId)
        {
            return GetBaseUnDeleted().Where(i => i.UserId == UserId).ToList();
        }

        public void Add(IssueData issue)
        {
            _repo.Add(issue);
        }

        public void Update(IssueData issue)
        {
            _repo.Update(issue);
        }

        public void Delete(int id) 
        {            
            _repo.Delete(_repo.GetAll().FirstOrDefault(x => x.Id == id));
        }
        
        public void SoftDelete(int id)
        {
            var issue = GetBase().FirstOrDefault(i=>i.Id == id);
            issue.DeleteFlag = true;
            _repo.Update(issue);
        }
    }
}
