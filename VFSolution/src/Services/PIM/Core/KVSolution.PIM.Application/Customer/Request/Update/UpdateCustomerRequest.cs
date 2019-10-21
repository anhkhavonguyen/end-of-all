using KVSolution.PIM.Application.Extentions;

namespace KVSolution.PIM.Application.Customer.Request.Update
{
    public class UpdateCustomerRequest : CommonRequest
    {
        public CustomerModel CustomerModel { get; set; }
    }
}
