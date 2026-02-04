using Emart_DotNet.Models;
using Emart_DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emart_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Customer>> GetCustomerByUserId(int userId)
        {
            var customer = await _customerService.GetCustomerByUserIdAsync(userId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
