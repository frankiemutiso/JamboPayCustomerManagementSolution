using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementAPI.DTOs;
using CustomerManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessesController : Controller
    {
        private readonly IBusinessService _businessService;

        public BusinessesController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllBusinessesAsync()
        {
            var businesses = await _businessService.GetAllBusinesses();

            return Ok(businesses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBusinessAsync(int id)
        {
            var business = await _businessService.GetBusiness(id);

            if(business is null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessAsync(BusinessCreateDTO createDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _businessService.CreateBusiness(createDTO);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusinessBusinessAsync([FromRoute] int id, BusinessUpdateDTO updateDTO)
        {
            if(updateDTO is null)
            {
                return BadRequest();
            }

            var response = await _businessService.UpdateBusiness(id,updateDTO);

            if(response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessAsync([FromRoute] int id)
        {
            var response = await _businessService.DeleteBusiness(id);

            if (response is null)
            {
                return NotFound();
            }

            return Ok("The record has been deleted successfully");
        }
    }
}

