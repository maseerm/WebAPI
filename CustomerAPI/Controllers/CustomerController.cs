
using CustomerData.Models;
using CustomerData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
           
                try
                {
                    var custId = await _customerService.AddCustomer(customer);
                    if (custId > 0)
                    {
                        return Ok(custId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

        }

        [HttpGet]
        [Route("GetCustomer")]
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
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
                int result = 0;

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
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int? customerId)
        {
            int result = 0;

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
