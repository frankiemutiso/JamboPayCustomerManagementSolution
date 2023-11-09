using System;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Services
{
	public interface IBusinessService
    {
        Task<BusinessReadDTO?> GetBusiness(int id);
        Task<List<BusinessReadDTO>> GetAllBusinesses();
        Task CreateBusiness(BusinessCreateDTO dto);
        Task<BusinessReadDTO?> UpdateBusiness(int id, BusinessUpdateDTO dto);
        Task<bool?> DeleteBusiness(int id);
    }
}

