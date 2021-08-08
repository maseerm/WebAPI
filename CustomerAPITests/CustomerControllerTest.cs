using CustomerAPI.Controllers;
using CustomerData.Models;
using CustomerData.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerAPITests
{
    public class CustomerControllerTest
    {
        CustomerController _controller;
        ICustomerService _service;
        private readonly IServiceScope _scope;
        private readonly CustomerContext _databaseContext;

       
        List<Customer> testCustomers = new List<Customer>()
            {
                new Customer(){FirstName="Brett",LastName="Lee",DateOfBirth=DateTime.Parse("25/01/1990")},
                new Customer(){FirstName="Rob",LastName="Jeff",DateOfBirth=DateTime.Parse("05/02/1992")},
                new Customer(){FirstName="Alan",LastName="To",DateOfBirth=DateTime.Parse("20/03/1993")},
                new Customer(){FirstName="Mark",LastName="Law",DateOfBirth=DateTime.Parse("15/04/1994")},
                new Customer(){FirstName="Rogger",LastName="Harp",DateOfBirth=DateTime.Parse("10/05/1995")},
            };

        
        public CustomerControllerTest(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _databaseContext = _scope.ServiceProvider.GetRequiredService<CustomerContext>();
            _service = new CustomerService(services);
            _controller = new CustomerController(_service);

           
        }


        [Fact]
        public async void AddCustomr_CustomerPassed_ReturnValue()
        {
            // Arrange
            var newCustomer = testCustomers[0];
            // Act
            var returnValue = await  _controller.AddCustomer(newCustomer);
            // Assert
            //Assert.IsType<Customer>(okResult.Value);
            Assert.IsType<OkObjectResult>(returnValue);
        }
    }
}
