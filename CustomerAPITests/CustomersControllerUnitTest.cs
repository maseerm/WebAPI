using CustomerAPI.Controllers;
using CustomerData.Models;
using CustomerData.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace CustomerAPITests
{
    public class CustomersControllerUnitTest
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly CustomersController _customersController;
        public CustomersControllerUnitTest()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _customersController = new CustomersController(_mockCustomerService.Object);
        }

        [Fact]
        public async void Test_AddCustomer_ReturnsResult_ReturnValue()
        {
            //Arrange
            var newCustomer = new Customer
            {
                FirstName = "John",
                LastName = "Smith",
                DateOfBirth = DateTime.Parse("25/01/1990")
            };
            _mockCustomerService.Setup(x => x.AddCustomer(newCustomer)).ReturnsAsync(1);
            
            //Act
            var response = await _customersController.AddCustomer(newCustomer);

            //Assert
            //Expected 1, Actual result.Value
            var result = Assert.IsType<CreatedAtActionResult>(response);
            Assert.Equal(1, result.Value);
        }

        [Fact]
        public async void Test_AddCustomer_ReturnsResult_StatusCode()
        {
            //Arrange
            var newCustomer = new Customer
            {
                FirstName = "Brett",
                LastName = "Lee",
                DateOfBirth = DateTime.Parse("25/01/1991")
            };
            _mockCustomerService.Setup(x => x.AddCustomer(newCustomer)).ReturnsAsync(1);

            //Act            
            var response = await _customersController.AddCustomer(newCustomer);

            //Assert
            //Expected 201, Actual result.StatusCode
            var result = Assert.IsType<CreatedAtActionResult>(response);
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async void Test_AddCustomer_ReturnsResult_BadRequest()
        {
            //Arrange
            var newCustomer = new Customer
            {
                //No First Name
                LastName = "Smith",
                DateOfBirth = DateTime.Parse("25/01/1990")
            };          

            //Act            
            var response = await _customersController.AddCustomer(newCustomer);

            //Assert
            //Expected BadRequestResult, Actual <BadRequestResult>response
            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public async void Test_GetCustomerByName_Return_StatusCode()
        {
            //Arrange      
            var customerName = "Mark";
            _mockCustomerService.Setup(x => x.GetCustomer(customerName)).Returns(Task.FromResult(new Customer
            {
                CustomerId = 1,
                LastName = "Monogios",
                FirstName = "Mark",
                DateOfBirth= DateTime.Parse("25/01/1990")
            })); 

            //Act
            var response = await _customersController.GetCustomer(customerName);

            //Assert
            //Expected 200, Actual result.StatusCode
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void Test_GetCustomerByName_Return_NotFound()
        {     
            //Arrange      
            var customerName = "Miano";
           
            //Act
            var response = await _customersController.GetCustomer(customerName);

            //Assert
            //Expected NotFoundResult, Actual <NotFoundResult>response
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async void Test_UpdateCustomer_Return_StatusCode()
        {
            //Arrange
            var existingCustomer = new Customer
            {
                CustomerId = 2,
                FirstName = "Rogger",
                LastName = "Harp",
                DateOfBirth = DateTime.Parse("25/01/1991")
            };
            _mockCustomerService.Setup(x => x.UpdateCustomer(existingCustomer)).ReturnsAsync(1);
           
            //Act
            var response = await _customersController.UpdateCustomer(existingCustomer);

            //Assert
            //Expected 200, Actual result.StatusCode
            var result = Assert.IsType<OkResult>(response);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void Test_UpdateCustomer_Return_NotFount()
        {
            //Arrange
            var newCustomer = new Customer
            {
                CustomerId = 3,
                FirstName = "Karl",
                LastName = "Shaw",
                DateOfBirth = DateTime.Parse("25/01/1985")
            };

            //Act
            var response = await _customersController.UpdateCustomer(newCustomer);

            //Assert
            //Expected NotFoundResult, Actual <NotFoundResult>response
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async void Test_DaleteCustomer_Return_StatusCode()
        {
            //Arrange
            var customerId = 1;
            _mockCustomerService.Setup(x => x.DeleteCustomer(customerId)).ReturnsAsync(1);

            //Act
            var response = await _customersController.DeleteCustomer(customerId);

            //Assert
            //Expected 200, Actual result.StatusCode
            var result = Assert.IsType<OkResult>(response);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void Test_DaleteCustomer_Return_NotFound()
        {
            //Arrange
            var customerId = 10;
           
            //Act
            var response = await _customersController.DeleteCustomer(customerId);

            //Assert
            //Expected NotFoundResult, Actual <NotFoundResult>response
            Assert.IsType<NotFoundResult>(response);
        }

    }
}
