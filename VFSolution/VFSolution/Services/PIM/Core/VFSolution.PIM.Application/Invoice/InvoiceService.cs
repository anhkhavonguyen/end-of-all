using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Base;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Application.Invoice.Request;
using VFSolution.PIM.Application.Invoice.Request.Create;
using VFSolution.PIM.Application.Invoice.Request.Update;
using VFSolution.PIM.Domain.Entities;
using VFSolution.PIM.Persistence;

namespace VFSolution.PIM.Application.Invoice
{
    public class InvoiceService : BaseService<InvoiceModel>, IInvoiceService
    {
        private readonly VFDbContext _dbContext;
        public InvoiceService(VFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateAsync(CreateInvoiceRequest request)
        {
            var entity = new Domain.Entities.Invoice()
            {
                CreatedBy = new Guid(request.UserId),
                CreatedDate = DateTime.UtcNow,
                DeliveryDate = request.InvoiceModel.DeliveryDate,
                GrandTotal = request.InvoiceModel.GrandTotal,
                Quantity = request.InvoiceModel.Quantity,
                Status = Common.Enum.InvoiceStatus.New,
                PurchaseOrderId = request.InvoiceModel.PurchaseOrderId
            };

            entity.InvoiceItems = new HashSet<InvoiceItem>();
            entity.InvoiceItems = request.InvoiceItemModels.Select(x => new InvoiceItem()
            {
                CreatedBy = new Guid(request.UserId),
                CreatedDate = DateTime.UtcNow,
                ProductName = x.ProductName,
                ProductType = x.ProductType,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Weight = x.Weight,
                Quantity = x.Quantity,
                Amount = x.Amount
            }).ToList();

            await _dbContext.Invoices.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public PagedResult<InvoiceModel> Get(CommonRequest request)
        {
            var query = _dbContext.Invoices.AsNoTracking().Where(a => !a.IsDelete).AsQueryable();
            var result = PagingExtensions.GetPaged<Domain.Entities.Invoice, InvoiceModel>(query, request.PageIndex, request.PageSize);
            return this.ComposeResponse(result);
        }

        public async Task<string> UpdateAsync(UpdateInvoiceRequest request)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(p => p.Id == new Guid(request.InvoiceModel.Id) && !p.IsDelete);

            if (invoice == null)
            {
                throw new Exception("PO not found");
            }

            invoice.GrandTotal = request.InvoiceModel.GrandTotal;
            invoice.Status = request.InvoiceModel.Status;
            invoice.UpdatedDate = DateTime.UtcNow;
            invoice.UpdatedBy = new Guid(request.UserId);
            invoice.DeliveryDate = request.InvoiceModel.DeliveryDate;
            invoice.Quantity = request.InvoiceModel.Quantity;

            await _dbContext.SaveChangesAsync();
            return invoice.Id.ToString();
        }
    }
}
