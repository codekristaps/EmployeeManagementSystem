using System;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public double Salary { get; set; }
        public double? HourlyRate { get; set; }
        public DateTime BirthDay { get; set; }

        // Constructor
        public Employee(string firstName, string lastName, string email, double salary, double? hourlyRate, DateTime birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            Salary = salary;
            HourlyRate = hourlyRate;
            BirthDay = birthDay;
        }

        public void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Email Address: {EmailAddress}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Hourly Rate: {HourlyRate}");
            Console.WriteLine($"Birth Day: {BirthDay.ToShortDateString()}");
        }
    }
}
