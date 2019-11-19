using KVSolution.PIM.Application.Extentions;

namespace KVSolution.PIM.Application.Base
{
    /// <summary>
    /// Application layer for business purpose
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> where T : class
    {
        public BaseService()
        {

        }

        public virtual PagedResult<T> ComposeResponse(PagedResult<T> result)
        {
            var pagedResultBase = new PagedResult<T>()
            {
                IsSuccess = result.IsSuccess,
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                Results = result.Results,
                TotalItem = result.TotalItem
            };

            return pagedResultBase;
        }
    }
}