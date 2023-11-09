using System;
namespace CustomerManagementAPI.DTOs
{
	public class BusinessLocationFilterDTO
	{
		public BusinessLocationFilterDTO()
		{
		}

		public string? County { get; set; }
		public string? SubCounty { get; set; }
		public string? Ward { get; set; }
	}
}

