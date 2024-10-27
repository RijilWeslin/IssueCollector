using SolutionSphere.Core.Entities;
using X.PagedList;

namespace SolutionSphere.Application.Extensions
{
    public static class PagedListExtension
    {
        public static Pagination<TEntity> Pagination<TEntity>(this IEnumerable<TEntity> enumerable, int page, int pageSize, TEntity temp = null) where TEntity : class
        {
            var pagedList = enumerable.ToPagedList<TEntity>(page, pageSize);
            return new Core.Entities.Pagination<TEntity>()
            {
                PageCount = pagedList.PageCount,
                TotalItemCount = pagedList.TotalItemCount,
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                HasPreviousPage = pagedList.HasPreviousPage,
                HasNextPage = pagedList.HasNextPage,
                IsFirstPage = pagedList.IsFirstPage,
                IsLastPage = pagedList.IsLastPage,
                FirstItemOnPage = pagedList.FirstItemOnPage,
                LastItemOnPage = pagedList.LastItemOnPage,
                Count = pagedList.Count,
                Subset = pagedList.ToList()
            };
        }

    }
}
