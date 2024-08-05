using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using EmployeeManagementSystem;

namespace EmployeeManagementSystem.Tests
{
    public class EmployeeServiceTests : IDisposable
    {
        private readonly EmployeeService _employeeService;
        private readonly string _testFilePath = "test_employees.json";

        public EmployeeServiceTests()
        {
            _employeeService = new EmployeeService(_testFilePath);
        }

        [Fact]
        public void AddEmployee_ShouldAddEmployee()
        {
            // Arrange
            var employee = new Employee("John", "Doe", "john.doe@example.com", 50000, null, new DateTime(1985, 10, 20), "HR");

            // Act
            _employeeService.AddEmployee(employee);
            var employees = _employeeService.LoadEmployees();

            // Assert
            Assert.Single(employees);
            Assert.Equal("John", employees[0].FirstName);
            Assert.Equal("Doe", employees[0].LastName);
            Assert.Equal("john.doe@example.com", employees[0].EmailAddress);
            Assert.Equal(50000, employees[0].Salary);
            Assert.Null(employees[0].HourlyRate);
            Assert.Equal(new DateTime(1985, 10, 20), employees[0].BirthDay);
            Assert.Equal("HR", employees[0].Department);
        }

        public void Dispose()
        {
            // We clean up the test file after each test run
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}
