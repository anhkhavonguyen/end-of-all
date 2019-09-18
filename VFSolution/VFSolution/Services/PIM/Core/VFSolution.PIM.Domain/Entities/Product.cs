using System;
using System.Collections.Generic;

namespace VFSolution.PIM.Domain.Entities
{
    public class Product: EntityBase
    {
        public string Name { get; set; }
        public decimal Unit { get; set; }
        public string Barcode { get; set; }
        public decimal Weight { get; set; }
        public long PriceDefault { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
