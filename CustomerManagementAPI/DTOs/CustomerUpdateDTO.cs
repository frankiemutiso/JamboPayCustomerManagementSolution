using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.DTOs
{
	public class CustomerUpdateDTO
	{
		public CustomerUpdateDTO()
		{
		}

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}

