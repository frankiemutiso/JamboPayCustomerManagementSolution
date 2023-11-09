using System;
namespace CustomerManagementAPI.DTOs
{
	public class BusinessFilterDTO
	{
		public BusinessFilterDTO()
		{
		}

		public string? County { get; set; }
		public string? SubCounty { get; set; }
		public string? Ward { get; set; }

		public int? CategoryId { get; set; }
		public int? OwnerId { get; set; }
	}
}

