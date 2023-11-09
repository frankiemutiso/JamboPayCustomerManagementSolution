using System;
using CustomerManagementAPI.Models;

namespace CustomerManagementAPI.DTOs
{
	public class CustomerReadDTO
	{
		public CustomerReadDTO()
		{
		}

        public CustomerReadDTO(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            Phone = customer.Phone;
            Nationality = customer.Nationality;
            DateOfBirth = customer.DateOfBirth;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

