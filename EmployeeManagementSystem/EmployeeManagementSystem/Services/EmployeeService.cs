using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeManagementSystem
{
    public class EmployeeService
    {
        private readonly string filePath;

        // Constructor accepting a file path parameter with a default value
        public EmployeeService(string filePath = "employees.json")
        {
            this.filePath = filePath;
        }

        public void SaveEmployees(List<Employee> employees)
        {
            string jsonString = JsonConvert.SerializeObject(employees, Formatting.Indented);

            // Ensure the file is created if it does not exist
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }

            File.WriteAllText(filePath, jsonString);
        }

        public List<Employee> LoadEmployees()
        {
            if (!File.Exists(filePath))
            {
                return new List<Employee>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Employee>>(jsonString);
        }

        public void AddEmployee(Employee employee)
        {
            var employees = LoadEmployees();
            employees.Add(employee);
            SaveEmployees(employees);
        }

        public void ViewEmployees()
        {
            var employees = LoadEmployees();
            foreach (var employee in employees)
            {
                employee.PrintEmployeeDetails();
            }
        }

        public void UpdateEmployee(string email, string newFirstName, string newLastName, double newSalary, double? newHourlyRate, DateTime newBirthDay, string newDepartment)
        {
            var employees = LoadEmployees();
            var employee = employees.Find(e => e.EmailAddress == email);
            if (employee != null)
            {
                employee.FirstName = newFirstName;
                employee.LastName = newLastName;
                employee.Salary = newSalary;
                employee.HourlyRate = newHourlyRate;
                employee.BirthDay = newBirthDay;
                employee.Department = newDepartment;
                SaveEmployees(employees);
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void DeleteEmployee(string email)
        {
            var employees = LoadEmployees();
            var employee = employees.Find(e => e.EmailAddress == email);
            if (employee != null)
            {
                employees.Remove(employee);
                SaveEmployees(employees);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
