using System;
using CustomerManagementAPI.Models;

namespace CustomerManagementAPI.DTOs
{
	public class BusinessLocationReadDTO:BusinessLocationCreateDTO
	{
		public BusinessLocationReadDTO(BusinessLocation location)
		{
			Id = location.Id;
			County = location.County;
			SubCounty = location.SubCounty;
			Ward = location.Ward;
			BuildingName = location.BuildingName;
			Floor = location.Floor;
			ShopNumber = location.ShopNumber;
		}

		public int Id { get; set; }
    }
}

