using System;
using VFSolution.PIM.Common.Enum;

namespace VFSolution.PIM.Application.Invoice.Request
{
    public class InvoiceModel
    {
        public string Id { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
