using AutoMapper.QueryableExtensions;
using System.Linq;

namespace KVSolution.PIM.Application.Extentions
{
    public static class PagingExtensions
    {
        public static PagedResult<U> GetPaged<T, U>(this IQueryable<T> query, int index, int pageSize) where U : class
        {
            var result = new PagedResult<U>();
            result.PageIndex = index;
            result.PageSize = pageSize;
            result.TotalItem = query.Count();

            var skip = index * pageSize;
            result.Results = query.Skip(skip)
                                  .Take(pageSize)
                                  .ProjectTo<U>()
                                  .ToList();

            result.IsSuccess = true;
            return result;
        }

        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.PageIndex = page;
            result.PageSize = pageSize;
            result.TotalItem = query.Count();

            var skip = page * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            result.IsSuccess = true;

            return result;
        }
    }
}
