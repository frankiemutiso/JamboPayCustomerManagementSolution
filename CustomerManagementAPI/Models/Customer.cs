using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Models
{
    [Table("customers")]
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(CustomerCreateDTO dto)
        {
            Name = dto.Name;
            Phone = dto.Phone;
            Email = dto.Email;
            DateOfBirth = dto.DateOfBirth;
            Nationality = dto.Nationality;
        }

        [Column("id"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("nationality")]
        public string Nationality { get; set; }

        [Column("date_created")]
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        [Column("date_updated")]
        public DateTimeOffset? DateUpdated { get; set; }

        [Column("date_deleted")]
        public DateTimeOffset? DateDeleted { get; set; }
    }
}

