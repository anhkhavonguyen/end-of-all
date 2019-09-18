using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Customer.Request.Update
{
    public class UpdateCustomerRequest : CommonRequest
    {
        public CustomerModel CustomerModel { get; set; }
    }
}
