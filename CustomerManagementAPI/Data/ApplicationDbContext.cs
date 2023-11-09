using System;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}

		public DbSet<Business> Businesses { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<BusinessCategory> BusinessCategories { get; set; }
		public DbSet<BusinessLocation> BusinessLocations { get; set; }
	}
}

