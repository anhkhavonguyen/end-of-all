using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KVSolution.PIM.Application.Customer.Request;
using KVSolution.PIM.Application.Customer.Request.Create;
using KVSolution.PIM.Application.Customer.Request.Delete;
using KVSolution.PIM.Application.Customer.Request.Update;
using KVSolution.PIM.Application.Extentions;

namespace KVSolution.PIM.Application.Customer
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
