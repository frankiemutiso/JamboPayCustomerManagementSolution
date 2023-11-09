using System;
using CustomerManagementAPI.DTOs;
using CustomerManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
	[ApiController]
	[Route("api/business_categories")]
    public class BusinessCategoriesController : Controller
	{
		private readonly IBusinessCategoryService _businessCategoryService;

		public BusinessCategoriesController(IBusinessCategoryService businessCategoryService)
		{
			_businessCategoryService = businessCategoryService;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllBusinessCategoriesAsync()
		{
            var categories = await _businessCategoryService.GetAllBusinessCategories();

            return Ok(categories);
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessCategoryAsync([FromRoute] int id)
        {
            var category = await _businessCategoryService.GetBusinessCategory(id);

            if(category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessCategoryAsync(BusinessCategoryCreateDTO createDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _businessCategoryService.CreateBusinessCategory(createDto);

            if(response is null)
            {
                return BadRequest($"A category with the name '{createDto.Name}' already exists.");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusinessCategoryAsync([FromRoute] int id, BusinessCategoryUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _businessCategoryService.UpdateBusinessCategory(id, updateDTO);

            if(response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessCategoryAsync([FromRoute] int id)
        {
            var response = await _businessCategoryService.DeleteBusinessCategory(id);

            if (response is null)
            {
                return NotFound();
            }

            return Ok("The record has been deleted successfully");
        }
    }
}

