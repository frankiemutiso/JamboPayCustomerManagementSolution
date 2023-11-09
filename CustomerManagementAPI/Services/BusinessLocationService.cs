using System;
using System.Diagnostics.Metrics;
using CustomerManagementAPI.Data;
using CustomerManagementAPI.DTOs;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Services
{
	public class BusinessLocationService:IBusinessLocationService
	{
        public readonly ApplicationDbContext _applicationDContext;

        public BusinessLocationService(ApplicationDbContext applicationDContext)
		{
            _applicationDContext = applicationDContext;
        }

        public async Task CreateLocation(BusinessLocationCreateDTO dto)
        {
            var location = new BusinessLocation(dto);

            await _applicationDContext.BusinessLocations.AddAsync(location);
            await _applicationDContext.SaveChangesAsync();
        }

        public async Task<bool?> DeleteLocation(int id)
        {
            var location = await _applicationDContext.BusinessLocations.FindAsync(id);

            if(location is null)
            {
                return null;
            }

            location.DateDeleted = DateTimeOffset.UtcNow;

            await _applicationDContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<BusinessLocationReadDTO>> GetAllLocations()
        {
            var locations = await _applicationDContext.BusinessLocations
                .Where(x => x.DateDeleted == null)
                .Select(x => new BusinessLocationReadDTO(x))
                .ToListAsync();

            return locations;
        }

        public async Task<BusinessLocationReadDTO?> GetLocation(int id)
        {
            var location = await _applicationDContext.BusinessLocations.FindAsync(id);

            if(location is null)
            {
                return null;
            }

            return new BusinessLocationReadDTO(location);
        }

        public List<BusinessLocationReadDTO> FilterLocationsAsync(BusinessLocationFilterDTO filterDTO)
        {
            var locations = _applicationDContext.BusinessLocations.Where(x => x.DateDeleted == null);

            if(filterDTO.County != null)
            {
                locations = locations.Where(x => x.County.ToLower() == filterDTO.County.ToLower());
            }

            if (filterDTO.SubCounty != null)
            {
                locations = locations.Where(x => x.County.ToLower() == filterDTO.SubCounty.ToLower());
            }

            if (filterDTO.Ward != null)
            {
                locations = locations.Where(x => x.Ward.ToLower() == filterDTO.Ward.ToLower());
            }

            return locations.Select(x => new BusinessLocationReadDTO(x)).ToList();
        }

        public async Task<BusinessLocationReadDTO?> UpdateLocation(int id, BusinessLocationUpdateDTO dto)
        {
            var location = await _applicationDContext.BusinessLocations.FindAsync(id);

            if(location is null)
            {
                return null;
            }

            location.County = dto.County;
            location.SubCounty = dto.SubCounty;
            location.Ward = dto.Ward;
            location.BuildingName = dto.BuildingName;
            location.Floor = dto.Floor;
            location.ShopNumber = dto.ShopNumber;

            await _applicationDContext.SaveChangesAsync();

            return new BusinessLocationReadDTO(location);
        }
    }
}

