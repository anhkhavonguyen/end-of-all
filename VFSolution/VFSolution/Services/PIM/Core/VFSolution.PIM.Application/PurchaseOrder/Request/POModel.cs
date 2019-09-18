using System;
using VFSolution.PIM.Common.Enum;

namespace VFSolution.PIM.Application.PurchaseOrder.Request
{
    public class POModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public PurchaseOrderStatus Status { get; set; }
    }
}
