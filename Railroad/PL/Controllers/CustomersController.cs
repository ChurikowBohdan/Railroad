using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDTO>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerReadDTO>>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET: api/customers/byTrainId/1
        [HttpGet("byTrainId/{id}")]
        public async Task<ActionResult<IEnumerable<CustomerReadDTO>>> GetCustomersByTrainId(int id)
        {
            var customers = await _customerService.GetCustomersByTrainIdAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // PUT: api/customers
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CustomerWriteDTO value)
        {
            if (ValidationCustomerModel(value))
            {
                return BadRequest(value);
            }

            await _customerService.AddAsync(value);
            return Ok();
        }

        // PUT: api/customers/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] CustomerWriteDTO value)
        {
            if (ValidationCustomerModel(value))
            {
                return BadRequest(value);
            }

            await _customerService.UpdateAsync(Id, value);
            var updatedCustomer = await _customerService.GetByIdAsync(Id);
            return Ok(updatedCustomer);
        }

        // DELETE: api/customers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return Ok();
        }

        private static bool ValidationCustomerModel(CustomerWriteDTO model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Surname))
            {
                return true;
            }

            if (model.BirthDate.Year <= 1899 || model.BirthDate >= DateTime.UtcNow)
            {
                return true;
            }

            if (model.DiscountValue < 0)
            {
                return true;
            }

            return false;
        }
    }
}
