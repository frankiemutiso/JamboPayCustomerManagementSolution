using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.DTOs
{
	public class BusinessLocationCreateDTO
	{
		public BusinessLocationCreateDTO()
		{
		}

		[Required]
		public string County { get; set; }
        [Required]
        public string SubCounty { get; set; }
        [Required]
        public string Ward { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public string ShopNumber { get; set; }
	}
}

