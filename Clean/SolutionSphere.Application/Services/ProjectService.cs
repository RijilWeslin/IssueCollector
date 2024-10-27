using SolutionSphere.Application.IRepository;
using SolutionSphere.Application.IServices;
using SolutionSphere.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _project;
        public ProjectService(IRepository<Project> project) 
        {
            _project = project;
        }

        public List<Project> GetAll()
        {
            var projects = _project.GetAll();
            return projects.ToList();
        }

        public void Add(Project project)
        {
            _project.Add(project);
        }

        public void Delete(Project project)
        {
            _project.Delete(project);
        }

        public void Update(Project project)
        {
            _project.Update(project);
        }
    }
}
