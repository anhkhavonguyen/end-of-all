using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Base;
using VFSolution.PIM.Application.Customer.Request;
using VFSolution.PIM.Application.Customer.Request.Create;
using VFSolution.PIM.Application.Customer.Request.Delete;
using VFSolution.PIM.Application.Customer.Request.Update;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Persistence;

namespace VFSolution.PIM.Application.Customer
{
    public class CustomerService : BaseService<CustomerModel>, ICustomerService
    {
        private readonly VFDbContext _dbContext;

        public CustomerService(VFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(CreateCustomerRequest request)
        {
            var entity = new Domain.Entities.Customer()
            {
                Address = request.CustomerModel.Address,
                Name = request.CustomerModel.Name,
                Phone = request.CustomerModel.Phone,
                POCode = request.CustomerModel.POCode
            };

            await _dbContext.Customers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<string> DeleteAsync(DeleteCustomerRequest request)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(p => p.Id == new Guid(request.Id));

            customer.IsDelete = true;

            await _dbContext.SaveChangesAsync();

            return customer.Id.ToString();
        }

        public PagedResult<CustomerModel> Get(CommonRequest request)
        {
            var query = _dbContext.Customers.AsNoTracking().Where(a => !a.IsDelete).AsQueryable();
            var result = PagingExtensions.GetPaged<Domain.Entities.Customer, CustomerModel>(query, request.PageIndex, request.PageSize);
            return this.ComposeResponse(result);
        }

        public async Task<CustomerModel> GetById(Guid id)
        {
            var query = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Domain.Entities.Customer, CustomerModel>(query);
        }
        public async Task<IEnumerable<CustomerModel>> GetCustomersWithoutPaging()
        {
            var result = await _dbContext.Customers.Select(x => new CustomerModel
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                POCode = x.POCode,
                Address = x.Address,
            }).ToListAsync();
            return result;
        }

        public async Task<string> UpdateAsync(UpdateCustomerRequest request)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(p => p.Id == request.CustomerModel.Id && !p.IsDelete);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            customer.Name = request.CustomerModel.Name;
            customer.Phone = request.CustomerModel.Phone;
            customer.Address = request.CustomerModel.Address;
            customer.UpdatedDate = DateTime.UtcNow;
            customer.UpdatedBy = new Guid(request.UserId);

            await _dbContext.SaveChangesAsync();

            return customer.Id.ToString();
        }
    }
}
