using System;

namespace VFSolution.PIM.Application.PurchaseOrder.Request
{
    public class POItemModel
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }
    }
}
