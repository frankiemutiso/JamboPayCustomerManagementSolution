using System;
using CustomerManagementAPI.Data;
using CustomerManagementAPI.DTOs;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Services
{
	public class BusinessCategoryService: IBusinessCategoryService
	{

        public readonly ApplicationDbContext _applicationDContext;

        public BusinessCategoryService(ApplicationDbContext applicationDContext)
		{
            _applicationDContext = applicationDContext;
        }

        public async Task<bool?> CreateBusinessCategory(BusinessCategoryCreateDTO dto)
        {
            var category = await _applicationDContext.BusinessCategories
                .Where(x => x.Name == dto.Name)
                .FirstOrDefaultAsync();

            if(category != null)
            {
                return null;
            }

            var newCategory = new BusinessCategory(dto);

            await _applicationDContext.BusinessCategories.AddAsync(newCategory);
            await _applicationDContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> DeleteBusinessCategory(int id)
        {
            var category = await _applicationDContext.BusinessCategories.FindAsync(id);

            if(category is null)
            {
                return null;
            }

            category.DateDeleted = DateTimeOffset.UtcNow;

            await _applicationDContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<BusinessCategoryReadDTO>> GetAllBusinessCategories()
        {
            var categories = await _applicationDContext.BusinessCategories
                .Where(x => x.DateDeleted == null)
                .Select(x => new BusinessCategoryReadDTO(x))
                .ToListAsync();

            return categories;
        }

        public async Task<BusinessCategoryReadDTO?> GetBusinessCategory(int id)
        {
            var category = await _applicationDContext.BusinessCategories.FindAsync(id);

            if (category is null)
            {
                return null;
            }

            return new BusinessCategoryReadDTO(category);
        }

        public async Task<BusinessCategoryReadDTO?> UpdateBusinessCategory(int id, BusinessCategoryUpdateDTO dto)
        {
            var category = await _applicationDContext.BusinessCategories.FindAsync(id);

            if (category is null)
            {
                return null;
            }

            category.Name = dto.Name;
            category.DateUpdated = DateTimeOffset.UtcNow;

            await _applicationDContext.SaveChangesAsync();

            return new BusinessCategoryReadDTO(category);
        }
    }
}

