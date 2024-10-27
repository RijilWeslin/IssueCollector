using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace SolutionSphere.Core.Entities
{
    public class Pagination<TEntity> where TEntity : class
    {                
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }        
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int FirstItemOnPage { get; set; }
        public int LastItemOnPage { get; set; }
        public int PreviousItemOnPage { get; set; }
        public int NextItemOnPage { get; set; }
        public int Count { get; set; }
        public List<TEntity> Subset { get; set; }
    }
}
