using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Models
{
	[Table("businesses")]
	public class Business
	{
		public Business(BusinessCreateDTO dto)
		{
            Name = dto.Name;
            CategoryId = dto.CategoryId;
            LocationId = dto.LocationId;
            OwnerId = dto.OwnerId;
            RegistrationDate = dto.RegistrationDate;
		}

        public Business()
        {

        }

        [Column("id"), Key]
		public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("location_id")]
        public int LocationId { get; set; }

        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        [Column("date_created")]
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        [Column("date_updated")]
        public DateTimeOffset? DateUpdated { get; set; }

        [Column("date_deleted")]
        public DateTimeOffset? DateDeleted { get; set; }

        public BusinessCategory Category { get; set; }
		public BusinessLocation Location { get; set; }
		public Customer Owner { get; set; }
	}
}

