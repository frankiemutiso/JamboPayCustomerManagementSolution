using System;
using CustomerManagementAPI.Models;

namespace CustomerManagementAPI.DTOs
{
	public class BusinessCategoryReadDTO
	{
		public BusinessCategoryReadDTO(BusinessCategory category)
		{
			Id = category.Id;
			Name = category.Name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
    }
}

