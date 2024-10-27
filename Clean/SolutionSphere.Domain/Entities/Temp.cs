using SolutionSphere.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Core.Entities
{
    public class Temp:Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
    }
}
