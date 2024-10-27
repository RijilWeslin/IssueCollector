using SolutionSphere.Core.Entities.BaseEntities;

namespace SolutionSphere.Core.Entities
{
    public class Project : Base
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ProjectManager { get; set; }                
        public bool DeleteFlag { get; set; }
    }
}
