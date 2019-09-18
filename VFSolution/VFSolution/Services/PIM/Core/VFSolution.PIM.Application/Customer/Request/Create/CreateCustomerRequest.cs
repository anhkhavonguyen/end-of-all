using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Customer.Request.Create
{
    public class CreateCustomerRequest: CommonRequest
    {
        public CustomerModel CustomerModel { get; set; }
    }
}
