using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Core.Entities.BaseEntities
{
    public class Base
    {
        public bool DeleteFlag { get;set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set;}
        public string Data { get; set; }
    }
}
