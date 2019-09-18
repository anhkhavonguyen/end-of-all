using System.Collections.Generic;
using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Invoice.Request.Create
{
    public class CreateInvoiceRequest : CommonRequest
    {
        public InvoiceModel InvoiceModel { get; set; }
        public List<InvoiceItemModel> InvoiceItemModels { get; set; }
    }
}
