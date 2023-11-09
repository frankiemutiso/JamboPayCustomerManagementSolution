using System;
using CustomerManagementAPI.Models;

namespace CustomerManagementAPI.DTOs
{
	public class BusinessUpdateDTO  
	{
		public BusinessUpdateDTO()
		{
		}

        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CategoryId { get; set; }
        public int OwnerId { get; set; }
    }
}

