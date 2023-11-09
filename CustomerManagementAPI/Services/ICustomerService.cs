using System;
using CustomerManagementAPI.DTOs;

namespace CustomerManagementAPI.Services
{
	public interface ICustomerService
    {
        Task<CustomerReadDTO?> GetCustomer(int id);
        Task<List<CustomerReadDTO>> GetAllCustomers();
        Task CreateCustomer(CustomerCreateDTO dto);
        Task<CustomerReadDTO?> UpdateCustomer(int id, CustomerUpdateDTO dto);
        Task<bool?> DeleteCustomer(int id);
	}
}

