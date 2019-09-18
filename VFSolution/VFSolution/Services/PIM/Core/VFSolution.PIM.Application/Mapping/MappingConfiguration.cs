using AutoMapper;
using VFSolution.PIM.Application.Customer.Request;
using VFSolution.PIM.Application.Invoice.Request;
using VFSolution.PIM.Application.PurchaseOrder.Request;

namespace VFSolution.PIM.Application.Mapping
{
    public static class MappingConfiguration
    {
        public static void Execute()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.Entities.PurchaseOrder, POModel>();
                cfg.CreateMap<Domain.Entities.PurchaseOrderItem, POItemModel>();
                cfg.CreateMap<Domain.Entities.Customer, CustomerModel>();
                cfg.CreateMap<Domain.Entities.Invoice, InvoiceModel>();
                cfg.CreateMap<Domain.Entities.InvoiceItem, InvoiceItemModel>();
            });
        }
    }
}
