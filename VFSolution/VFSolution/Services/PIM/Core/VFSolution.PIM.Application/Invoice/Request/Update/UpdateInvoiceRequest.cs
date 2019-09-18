using System.Collections.Generic;
using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Invoice.Request.Update
{
    public class UpdateInvoiceRequest: CommonRequest
    {
        public InvoiceModel InvoiceModel { get; set; }
        public List<InvoiceItemModel> InvoiceItemModels { get; set; }
    }
}
