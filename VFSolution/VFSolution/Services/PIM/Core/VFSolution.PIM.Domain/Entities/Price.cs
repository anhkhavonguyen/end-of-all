using System;

namespace VFSolution.PIM.Domain.Entities
{
    public class Price : EntityBase
    {
        public decimal Value { get; set; }
        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
