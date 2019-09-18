using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VFSolution.PIM.Application.Customer;
using VFSolution.PIM.Application.Customer.Request.Create;
using VFSolution.PIM.Application.Customer.Request.Delete;
using VFSolution.PIM.Application.Customer.Request.Update;
using VFSolution.PIM.Application.Extentions;

namespace VFSolution.Api.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get(CommonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _customerService.Get(request);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id is required.");
            }
            var res = await _customerService.GetById(id);
            return Ok(res);
        }


        [HttpGet("withoutPaging")]
        public async Task<ActionResult> GetAllCustomersWithoutPaging()
        {
            var res = await _customerService.GetCustomersWithoutPaging();
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _customerService.CreateAsync(request);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _customerService.UpdateAsync(request);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _customerService.DeleteAsync(request);
            return Ok(res);
        }
    }
}