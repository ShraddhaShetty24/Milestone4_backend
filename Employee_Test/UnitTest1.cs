using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Milestone4_CrudEmployee_MongoDB_Mar21.Controllers;
using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;
using Milestone4_CrudEmployee_MongoDB_Mar21.Queries;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Employee_Test
{
    [TestClass]
    public class UnitTest1
    {
        
            private Mock<IMediator> _mediatorMock;
            private EmployeeController _controller;

            [TestInitialize]
            public void Initialize()
            {
                _mediatorMock = new Mock<IMediator>();
                _controller = new EmployeeController(_mediatorMock.Object);
            }

        [TestMethod]
        public async Task GetAllProducts_ShouldReturnOkWithProductsList()
        {
            // Arrange
            var employees = new List<EmployeeTable>
        {
            new EmployeeTable { id = "abc111", EmployeeName = "AAA", EmployeeAge=28, EmployeeSalary=25000,  EmployeeDesignation="Analyst", EmployeeDepartment="Sales"  },
            new EmployeeTable { id = "def122", EmployeeName = "BBB",EmployeeAge=22,  EmployeeSalary=25000, EmployeeDesignation="Analyst", EmployeeDepartment="Sales"  }
        };
           
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllEmployeesQuery>(),default)).ReturnsAsync(employees);

            // Act
            var result = await _controller.GetEmployees();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            Assert.AreEqual(200, okResult.StatusCode);
            var resultValue = okResult.Value as List<EmployeeTable>;
            Assert.IsNotNull(resultValue);
            CollectionAssert.AreEqual(employees, resultValue);
            //Assert.Equals(employees, resultValue);
        }
        }
}