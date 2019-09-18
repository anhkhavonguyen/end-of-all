using System;
using System.Collections.Generic;
using System.Text;

namespace VFSolution.PIM.Domain.Entities
{
    public class Store : EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
