
using CustomerData.Models;
using CustomerData.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
   
    [ApiController, Route("api/v1/[controller]")]
    [Consumes("application/json")]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
  
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {         
                try
                {
                    var customerId = await _customerService.AddCustomer(customer);
                    if (customerId > 0)
                    {
                    
                    return CreatedAtAction("AddCustomer", customerId);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(string customerName)
        {
            try
            {
                var customer = await _customerService.GetCustomer(customerName);
                if (customer == null)
                {
                    return NotFound();
                }
                    return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
                int result;
                try
                {
                    result= await _customerService.UpdateCustomer(customer);
                    if (result == 0)
                    {
                        return NotFound();
                    }
                    return Ok();

                }
                catch (Exception)
                {
                   return BadRequest();
                }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int? customerId)
        {
            int result;
            try
            {
                result = await _customerService.DeleteCustomer(customerId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
