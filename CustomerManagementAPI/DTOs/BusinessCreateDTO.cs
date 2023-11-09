using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.DTOs
{
	public class BusinessCreateDTO
    {
		public BusinessCreateDTO()
		{
		}

		[Required]
		public string Name { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int LocationId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int OwnerId { get; set; }
	}
}

