using CustomerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData.Services
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(Customer customer);

        //Customer GetCustomer(string custName);
        Task<Customer> GetCustomer(string custName);
        Task<int> UpdateCustomer(Customer customer);

        Task<int> DeleteCustomer(int? customerId);
    }
}
