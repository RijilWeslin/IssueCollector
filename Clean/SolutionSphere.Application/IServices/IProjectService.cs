using SolutionSphere.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Application.IServices
{
    public interface IProjectService
    {
        public List<Project> GetAll();
        public void Add(Project project);
        public void Update(Project project);
        public void Delete(Project project);
    }
}
