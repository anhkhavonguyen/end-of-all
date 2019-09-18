using System;
using System.Collections.Generic;
using VFSolution.PIM.Common.Enum;

namespace VFSolution.PIM.Domain.Entities
{
    public class PurchaseOrder: EntityBase
    {
        public PurchaseOrder()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
        }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public PurchaseOrderStatus Status { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
