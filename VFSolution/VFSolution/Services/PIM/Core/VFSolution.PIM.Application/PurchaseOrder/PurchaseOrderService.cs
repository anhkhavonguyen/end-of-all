using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Base;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Application.PurchaseOrder.Request;
using VFSolution.PIM.Application.PurchaseOrder.Request.Create;
using VFSolution.PIM.Application.PurchaseOrder.Request.Delete;
using VFSolution.PIM.Application.PurchaseOrder.Request.Update;
using VFSolution.PIM.Common.Enum;
using VFSolution.PIM.Domain.Entities;
using VFSolution.PIM.Persistence;

namespace VFSolution.PIM.Application.PurchaseOrder
{
    public class PurchaseOrderService : BaseService<POModel>, IPurchaseOrderService
    {
        private readonly VFDbContext _dbContext;
        public PurchaseOrderService(VFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(CreatePORequest request)
        {
            var entity = new Domain.Entities.PurchaseOrder()
            {
                TotalAmount = request.POModel.TotalAmount,
                CustomerId = request.POModel.CustomerId,
                Status = PurchaseOrderStatus.New
            };

            entity.PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
            entity.PurchaseOrderItems = request.POItems.Select(x => new PurchaseOrderItem()
            {
                ProductId = new Guid(x.ProductId),
                Quantity = x.Quantity,
                Amount = x.Amount
            }).ToList();

            await _dbContext.PurchaseOrders.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<string> DeleteAsync(DeletePORequest request)
        {
            var po = await _dbContext.PurchaseOrders.Include(p => p.Invoices).FirstOrDefaultAsync(p => p.Id == new Guid(request.Id));

            if (po == null || po.Invoices.Any())
            {
                throw new Exception("Invalid delete PO");
            }

            po.IsDelete = true;

            await _dbContext.SaveChangesAsync();

            return po.Id.ToString();
        }

        public PagedResult<POModel> Get(CommonRequest request)
        {
            var query = _dbContext.PurchaseOrders.AsNoTracking().Where(a => !a.IsDelete).AsQueryable();
            var result = PagingExtensions.GetPaged<Domain.Entities.PurchaseOrder, POModel>(query, request.PageIndex, request.PageSize);
            return this.ComposeResponse(result);
        }

        public async Task<string> UpdateAsync(UpdatePORequest request)
        {
            var po = await _dbContext.PurchaseOrders.Include(p=>p.PurchaseOrderItems).FirstOrDefaultAsync(p => p.Id == request.POModel.Id && !p.IsDelete);

            if(po == null)
            {
                throw new Exception("PO not found");
            }

            po.Status = request.POModel.Status;
            po.TotalAmount = request.POModel.TotalAmount;
            po.Status = request.POModel.Status;
            po.CustomerId = request.POModel.CustomerId;
            po.UpdatedDate = DateTime.UtcNow;
            po.UpdatedBy = new Guid(request.UserId);
            
            foreach(var poItemD in po.PurchaseOrderItems)
            {
                foreach (var itemR in request.POItems)
                {
                    if(poItemD.Id == itemR.Id)
                    {
                        poItemD.Quantity = itemR.Quantity;
                        poItemD.Amount = itemR.Amount;
                        poItemD.UpdatedDate = DateTime.UtcNow;
                        poItemD.UpdatedBy = new Guid(request.UserId);
                    }
                    continue;
                }
            }

            await _dbContext.SaveChangesAsync();

            return po.Id.ToString();
        }
    }
}
