using System;

namespace VFSolution.PIM.Domain.Entities
{
    public class InvoiceItem : EntityBase
    {
        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Weight { get; set; }
        public string ProductType { get; set; }
        public decimal UnitPrice { get; set; }
        public string Amount { get; set; }
    }
}
