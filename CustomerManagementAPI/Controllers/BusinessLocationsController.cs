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
    public class BusinessLocationsController : Controller
    {
        private readonly IBusinessLocationService _businessLocationService;

        public BusinessLocationsController(IBusinessLocationService businessLocationService)
        {
            _businessLocationService = businessLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocationsAsync()
        {
            var locations = await _businessLocationService.GetAllLocations();

            return Ok(locations);
        }

        [HttpGet("filter")]
        public IActionResult FilterLocationsAsync([FromQuery] BusinessLocationFilterDTO filter)
        {
            if(filter is null)
            {
                return BadRequest("Provide county, subcounty or ward values as query parameters");
            }

            var locations = _businessLocationService.FilterLocations(filter);

            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationAsync([FromRoute] int id)
        {
            var location = await _businessLocationService.GetLocation(id);

            if(location is null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocationAsync(BusinessLocationCreateDTO createDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _businessLocationService.CreateLocation(createDTO);

            return Ok("The location has been created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocationAsync([FromRoute] int id, BusinessLocationUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _businessLocationService.UpdateLocation(id, updateDTO);

            if(response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationAsync([FromRoute] int id)
        {
            var response = await _businessLocationService.DeleteLocation(id);

            if (response is null)
            {
                return NotFound();
            }

            return Ok("The location has been deleted successfully");
        }
    }
}

