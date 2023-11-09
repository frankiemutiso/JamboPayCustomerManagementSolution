using System;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Services
{
	public interface IBusinessCategoryService
    {
        Task<BusinessCategoryReadDTO?> GetBusinessCategory(int id);
        Task<List<BusinessCategoryReadDTO>> GetAllBusinessCategories();
        Task<bool?> CreateBusinessCategory(BusinessCategoryCreateDTO dto);
        Task<BusinessCategoryReadDTO?> UpdateBusinessCategory(int id, BusinessCategoryUpdateDTO dto);
        Task<bool?> DeleteBusinessCategory(int id);
    }
}

