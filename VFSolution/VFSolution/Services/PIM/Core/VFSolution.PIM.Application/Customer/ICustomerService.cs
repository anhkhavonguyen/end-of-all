using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Customer.Request;
using VFSolution.PIM.Application.Customer.Request.Create;
using VFSolution.PIM.Application.Customer.Request.Delete;
using VFSolution.PIM.Application.Customer.Request.Update;
using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Customer
{
    public interface ICustomerService
    {
        Task<bool> CreateAsync(CreateCustomerRequest request);

        Task<string> UpdateAsync(UpdateCustomerRequest request);

        PagedResult<CustomerModel> Get(CommonRequest request);
        Task<CustomerModel> GetById(Guid id);

        Task<string> DeleteAsync(DeleteCustomerRequest request);

        Task<IEnumerable<CustomerModel>> GetCustomersWithoutPaging();
    }
}
