using System;

namespace VFSolution.PIM.Application.Customer.Request
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string POCode { get; set; }
        public string Address { get; set; }
    }
}
