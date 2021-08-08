using CustomerData.Models;
using System.Threading.Tasks;

namespace CustomerData.Services
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(Customer customer);
        Task<Customer> GetCustomer(string custName);
        Task<int> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int? customerId);
        
    }
}
