using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Core.Entities
{
    public class MasterData
    {
        public Guid Id { get; set; }
        public int ItemType { get; set;}
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set;}
    }
}
