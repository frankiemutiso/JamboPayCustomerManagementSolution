using System;
using CustomerManagementAPI.Models;

namespace CustomerManagementAPI.DTOs
{
	public class BusinessReadDTO
	{
		public BusinessReadDTO()
		{
		}

        public BusinessReadDTO(Business business)
        {
            Id = business.Id;
            Name = business.Name;
            AgeOfBusiness = CalculateBusinessAge(business.RegistrationDate);
            CategoryId = business.CategoryId;
            LocationId = business.LocationId;
            OwnerId = business.OwnerId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AgeOfBusiness { get; set; } 
        public int OwnerId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }

        public static int CalculateBusinessAge(DateTime registrationDate)
        {
            DateTime now = DateTime.Now;
            int difference = now.Year - registrationDate.Year;

            if (now.Month < registrationDate.Month || (now.Month == registrationDate.Month && now.Day < registrationDate.Day))
            {
                difference--;
            }

            return difference;
        }
    }
}

