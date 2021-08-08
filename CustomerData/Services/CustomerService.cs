using CustomerData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CustomerData.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IServiceScope _scope;
        private readonly CustomerContext _databaseContext;

        public CustomerService(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _databaseContext = _scope.ServiceProvider.GetRequiredService<CustomerContext>();
        }

        public async Task<int> AddCustomer(Customer costomer)
        {
            if (_databaseContext != null)
            {
                await _databaseContext.Customers.AddAsync(costomer);
                await _databaseContext.SaveChangesAsync();

                return costomer.CustomerId;
            }

            return 0;
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            int result = 0;
            if (_databaseContext != null)
            {
                var updatedCustomer = await _databaseContext.Customers.FirstOrDefaultAsync(c => (c.CustomerId == customer.CustomerId));
                if (updatedCustomer != null)
                {
                    updatedCustomer.FirstName = customer.FirstName;
                    updatedCustomer.LastName = customer.LastName;
                    updatedCustomer.DateOfBirth = customer.DateOfBirth;
                    _databaseContext.Customers.Update(updatedCustomer);

                    result = await _databaseContext.SaveChangesAsync();
                }
               
            }
            return result;
        }

        public async Task<int> DeleteCustomer(int? customerId)
        {
            int result = 0;

            if (_databaseContext != null)
            {
                
                var customer = await _databaseContext.Customers.FirstOrDefaultAsync(c => (c.CustomerId == customerId));

                if (customer != null)
                {
                    
                    _databaseContext.Customers.Remove(customer);

                    result = await _databaseContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<Customer> GetCustomer(string custName)
        {
            if (_databaseContext != null)
            {
                var customer = await _databaseContext.Customers.FirstOrDefaultAsync(c => c.FirstName.ToLower().Contains(custName.ToLower()) || c.LastName.ToLower().Contains(custName.ToLower()));
                return customer;
            }
            return null;
        }

    }
}
