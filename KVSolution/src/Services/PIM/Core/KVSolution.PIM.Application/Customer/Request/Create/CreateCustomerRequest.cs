using KVSolution.PIM.Application.Extentions;

namespace KVSolution.PIM.Application.Customer.Request.Create
{
    public class CreateCustomerRequest: CommonRequest
    {
        public CustomerModel CustomerModel { get; set; }
    }
}
