using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Models
{
	[Table("business_locations")]
	public class BusinessLocation
	{
		public BusinessLocation(BusinessLocationCreateDTO dto)
		{
            County = dto.County;
            SubCounty = dto.SubCounty;
            Ward = dto.Ward;
            BuildingName = dto.BuildingName;
            Floor = dto.Floor;
            ShopNumber = dto.ShopNumber;
		}

        public BusinessLocation()
        {

        }

        [Column("id"), Key]
        public int Id { get; set; }

        [Column("county")]
        public string County { get; set; }

        [Column("subcounty")]
        public string SubCounty { get; set; }

        [Column("ward")]
        public string Ward { get; set; }

        [Column("building_name")]
        public string BuildingName { get; set; }

        [Column("floor")]
        public int Floor { get; set; }

        [Column("shop_number")]
        public string ShopNumber { get; set; }

        [Column("date_created")]
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        [Column("date_updated")]
        public DateTimeOffset? DateUpdated { get; set; }

        [Column("date_deleted")]
        public DateTimeOffset? DateDeleted { get; set; }
    }
}

