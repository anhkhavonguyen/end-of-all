using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Base;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Application.Store.request;
using VFSolution.PIM.Persistence;

namespace VFSolution.PIM.Application.Store
{
    public class StoreService : BaseService<StoreModel>, IStoreService
    {
        private readonly VFDbContext _dbContext;

        public StoreService(VFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PagedResult<StoreModel> Get(GetStoreRequest request)
        {
            var query = _dbContext.Stores.AsNoTracking().Include(a => a.Customer).Where(a => !a.IsDelete).AsQueryable(); ;
            if (request.CustomerId != Guid.Empty)
            {
                query = query.Where(a => a.CustomerId == request.CustomerId).AsQueryable();
            }
            
            var result = PagingExtensions.GetPaged<Domain.Entities.Store, StoreModel>(query, request.PageIndex, request.PageSize);
            return this.ComposeResponse(result);
        }

        public async Task<Boolean> CreateAsync(StoreModel request)
        {
            var entity = new Domain.Entities.Store()
            {
                Name = request.Name,
                Phone = request.Phone,
                Address = request.Address,
                Email = request.Email,
                Code = request.Code,
                CustomerId = request.Customer.Id
            };

            await _dbContext.Stores.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
