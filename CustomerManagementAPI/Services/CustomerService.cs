using System;
using CustomerManagementAPI.Data;
using CustomerManagementAPI.DTOs;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Services
{
	public class CustomerService : ICustomerService
	{
        public readonly ApplicationDbContext _applicationDContext;

		public CustomerService(ApplicationDbContext applicationDContext)
		{
            _applicationDContext = applicationDContext;
        }

        public async Task CreateCustomer(CustomerCreateDTO dto)
        {
            Customer customer = new Customer(dto);

            await _applicationDContext.Customers.AddAsync(customer);
            await _applicationDContext.SaveChangesAsync();
        }

        public async Task<bool?> DeleteCustomer(int id)
        {
            var customer = await _applicationDContext.Customers.FindAsync(id);

            if(customer is null)
            {
                return null;
            }

            customer.DateDeleted = DateTimeOffset.UtcNow;
            customer.DateUpdated = DateTimeOffset.UtcNow;

            await _applicationDContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<CustomerReadDTO>> GetAllCustomers()
        {
            var customers = await _applicationDContext.Customers
                .Where(x => x.DateDeleted == null)
                .Select(x => new CustomerReadDTO(x))
                .ToListAsync();

            return customers;
        }

        public async Task<CustomerReadDTO?> GetCustomer(int id)
        {
            var customer = await _applicationDContext.Customers
                .Where(x => x.DateDeleted == null && x.Id == id)
                .FirstOrDefaultAsync();

            if(customer is null)
            {
                return null;
            }

            CustomerReadDTO customerDto = new CustomerReadDTO(customer);

            return customerDto;
        }

        public async Task<CustomerReadDTO?> UpdateCustomer(int id, CustomerUpdateDTO dto)
        {
            var customer = await _applicationDContext.Customers.FindAsync(id);

            if(customer is null)
            {
                return null;
            }

            customer.Name = dto.Name;
            customer.Phone = dto.Phone;
            customer.Nationality = dto.Nationality;
            customer.DateOfBirth = dto.DateOfBirth;
            customer.DateUpdated = DateTimeOffset.UtcNow;

            await _applicationDContext.SaveChangesAsync();

            return new CustomerReadDTO(customer);
        }
    }
}

