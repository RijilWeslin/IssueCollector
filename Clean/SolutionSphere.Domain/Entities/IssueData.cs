using SolutionSphere.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Core.Entities
{
    public class IssueData:Base
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        /*public Guid IssueType { get; set; }*/
        public Guid ProjectCode { get; set; }
        public bool SolutionAvailable { get; set; }
        public bool VisibleToEveryone { get; set; }
        public virtual List<SolutionData>? Solution { get; set; }        
        public virtual Project Project { get; set; }
    }
}
