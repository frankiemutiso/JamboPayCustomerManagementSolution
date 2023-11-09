using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.DTOs
{
	public class BusinessCategoryCreateDTO
	{
		public BusinessCategoryCreateDTO()
		{
		}

		[Required]
		public string Name { get; set; }
	}
}

