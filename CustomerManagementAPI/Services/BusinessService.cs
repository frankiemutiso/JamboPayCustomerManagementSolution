using System;
using CustomerManagementAPI.Data;
using CustomerManagementAPI.DTOs;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Services
{
	public class BusinessService:IBusinessService
	{
        public readonly ApplicationDbContext _applicationDContext;

        public BusinessService(ApplicationDbContext applicationDContext)
		{
            _applicationDContext = applicationDContext;
        }

        public async Task CreateBusiness(BusinessCreateDTO dto)
        {
            Business business = new Business(dto);

            await _applicationDContext.Businesses.AddAsync(business);
            await _applicationDContext.SaveChangesAsync();
        }

        public async Task<bool?> DeleteBusiness(int id)
        {
            var business = await _applicationDContext.Businesses.FindAsync(id);

            if(business is null)
            {
                return null;
            }

            business.DateDeleted = DateTimeOffset.UtcNow;
            business.DateUpdated = DateTimeOffset.UtcNow;

            await _applicationDContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<BusinessReadDTO>> GetAllBusinesses()
        {
            var businesses = await _applicationDContext.Businesses
                .Where(x => x.DateDeleted == null)
                .Select(x => new BusinessReadDTO(x))
                .ToListAsync();

            return businesses;
        }

        public async Task<BusinessReadDTO?> GetBusiness(int id)
        {
            var business = await _applicationDContext.Businesses.FindAsync(id);

            if (business is null)
            {
                return null;
            }

            return new BusinessReadDTO(business);
        }

        public async Task<BusinessReadDTO?> UpdateBusiness(int id, BusinessUpdateDTO dto)
        {
            var business = await _applicationDContext.Businesses.FindAsync(id);

            if (business is null)
            {
                return null;
            }

            business.CategoryId = dto.CategoryId;
            business.OwnerId = dto.OwnerId;
            business.Name = dto.Name;
            business.RegistrationDate = dto.RegistrationDate;
            business.DateUpdated = DateTimeOffset.UtcNow;

            await _applicationDContext.SaveChangesAsync();

            return new BusinessReadDTO(business);
        }
    }
}

