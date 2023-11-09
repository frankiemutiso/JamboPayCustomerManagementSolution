using System;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Services
{
	public interface IBusinessLocationService
    {
        Task<BusinessLocationReadDTO?> GetLocation(int id);
        Task<List<BusinessLocationReadDTO>> GetAllLocations();
        List<BusinessLocationReadDTO> FilterLocations(BusinessLocationFilterDTO filterDTO);
        Task CreateLocation(BusinessLocationCreateDTO dto);
        Task<BusinessLocationReadDTO?> UpdateLocation(int id, BusinessLocationUpdateDTO dto);
        Task<bool?> DeleteLocation(int id);
    }
}

