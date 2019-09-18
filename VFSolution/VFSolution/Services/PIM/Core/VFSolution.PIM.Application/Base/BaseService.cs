using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Base
{
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