using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Application.Store.request;

namespace VFSolution.PIM.Application.Store
{
    public interface IStoreService
    {
        PagedResult<StoreModel> Get(GetStoreRequest request);
        Task<Boolean> CreateAsync(StoreModel request);
    }
}

