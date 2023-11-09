using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Models
{
    [Table("business_categories")]
    public class BusinessCategory
    {
        public BusinessCategory(BusinessCategoryCreateDTO createDTO)
        {
            Name = createDTO.Name;
        }

        public BusinessCategory()
        {
        }

        [Column("id"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("date_created")]
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        [Column("date_updated")]
        public DateTimeOffset? DateUpdated { get; set; }

        [Column("date_deleted")]
        public DateTimeOffset? DateDeleted { get; set; }
    }
}

