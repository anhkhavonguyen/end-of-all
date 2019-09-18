using System;
using System.Collections.Generic;
using VFSolution.PIM.Common.Enum;

namespace VFSolution.PIM.Domain.Entities
{
    public class Invoice: EntityBase
    {
        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }
        public Guid PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal GrandTotal { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
