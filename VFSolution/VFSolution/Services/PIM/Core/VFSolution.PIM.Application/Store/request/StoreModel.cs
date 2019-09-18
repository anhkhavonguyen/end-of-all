using System;
using System.Collections.Generic;
using System.Text;
using VFSolution.PIM.Application.Customer.Request;

namespace VFSolution.PIM.Application.Store.request
{
    public class StoreModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
