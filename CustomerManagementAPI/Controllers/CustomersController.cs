using System;
using CustomerManagementAPI.DTOs;
using CustomerManagementAPI.Models;
using CustomerManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        public readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseTypeAttribute(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseTypeAttribute(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomerAsync([FromRoute] int id)
        {
            var customer = await _customerService.GetCustomer(id);

            if(customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateCustomer(CustomerCreateDTO createDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _customerService.CreateCustomer(createDto);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, CustomerUpdateDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _customerService.UpdateCustomer(id, updateDto);

            if(response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            var response = await _customerService.DeleteCustomer(id);

            if (response is null)
            {
                return NotFound();
            }

            return Ok("The record has been deleted successfully");
        }
    }
}

