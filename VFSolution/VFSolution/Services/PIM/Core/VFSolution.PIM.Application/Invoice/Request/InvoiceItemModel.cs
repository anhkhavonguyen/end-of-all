using System;

namespace VFSolution.PIM.Application.Invoice.Request
{
    public class InvoiceItemModel
    {
        public Guid InvoiceId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Weight { get; set; }
        public string ProductType { get; set; }
        public decimal UnitPrice { get; set; }
        public string Amount { get; set; }
    }
}
