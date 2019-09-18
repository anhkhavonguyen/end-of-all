using System;

namespace VFSolution.PIM.Domain.Entities
{
    public class PurchaseOrderItem: EntityBase
    {
        public Guid PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }

    }
}
