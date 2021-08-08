using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerData.Models;
using CustomerData.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPITests
{
    public class CustomerServiceTest : ICustomerService
    {

        private readonly List<Customer> _testCustomers;
        public CustomerServiceTest()
        {
            _testCustomers = new List<Customer>()
            {
                new Customer(){FirstName="Brett",LastName="Lee",DateOfBirth=DateTime.Parse("25/01/1990")},
                new Customer(){FirstName="Rob",LastName="Jeff",DateOfBirth=DateTime.Parse("05/02/1992")},
                new Customer(){FirstName="Alan",LastName="To",DateOfBirth=DateTime.Parse("20/03/1993")},
                new Customer(){FirstName="Mark",LastName="Law",DateOfBirth=DateTime.Parse("15/04/1994")},
                new Customer(){FirstName="Rogger",LastName="Harp",DateOfBirth=DateTime.Parse("10/05/1995")},
            };

        }


        public Task<int> DeleteCustomer(int? customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomer(string custName)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        Task<int> ICustomerService.AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
