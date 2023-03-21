using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Test
{
    public static class MockRepository
    {
        public static Mock<IEmployee> EmployeeMockRepository()
        {

            //create fake database
            var employees = new List<EmployeeTable>
            {
                new EmployeeTable
                {
                    id="11",
                    EmployeeName="Shraddha",
                    EmployeeAge=22,
                    EmployeeSalary=20000,
                    EmployeeDesignation="Manager",
                    EmployeeDepartment="Marketing"
                },
                 new EmployeeTable
                {
                    id="12",
                    EmployeeName="Sanjana",
                    EmployeeAge=26,
                    EmployeeSalary=20000,
                    EmployeeDesignation="Manager",
                    EmployeeDepartment="Marketing"
                },
                  new EmployeeTable
                {
                    id="13",
                    EmployeeName="Samanvay",
                    EmployeeAge=28,
                    EmployeeSalary=20000,
                    EmployeeDesignation="Manager",
                    EmployeeDepartment="Marketing"
                }
            };

            //mock the repository(interface)

            var mockRepo = new Mock<IEmployee>();

            //mock the instance (like fake instance)

            //get all employees
            mockRepo.Setup(r => r.GetAllEmployees()).Returns(employees);

            //add employee
            //mockRepo.Setup(r => r.CreateAsync(It.IsAny<EmployeeTable>())).Returns((EmployeeTable employee) =>
            //{
            //    employees.Add(employee);
            //    return employees;

            //});
            return mockRepo;

        }
    }
}
