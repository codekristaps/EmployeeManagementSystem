using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main()
        {
            var employeeService = new EmployeeService();

            while (true)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee(employeeService);
                        break;
                    case 2:
                        employeeService.ViewEmployees();
                        break;
                    case 3:
                        UpdateEmployee(employeeService);
                        break;
                    case 4:
                        DeleteEmployee(employeeService);
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid choice.");
                        break;
                }
            }
        }

        static void AddEmployee(EmployeeService employeeService)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Email Address: ");
            string emailAddress = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Hourly Rate (or press Enter to skip): ");
            string hourlyRateInput = Console.ReadLine();
            double? hourlyRate = string.IsNullOrEmpty(hourlyRateInput) ? (double?)null : Convert.ToDouble(hourlyRateInput);

            Console.Write("Enter Birth Day (YYYY-MM-DD): ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Department Name: ");
            string department = Console.ReadLine();

            var employee = new Employee(firstName, lastName, emailAddress, salary, hourlyRate, birthDay, department);
            employeeService.AddEmployee(employee);
            Console.WriteLine("Employee added successfully.");
        }

        static void UpdateEmployee(EmployeeService employeeService)
        {
            Console.Write("Enter Email Address of the Employee to update: ");
            string email = Console.ReadLine();

            Console.Write("Enter new First Name: ");
            string newFirstName = Console.ReadLine();

            Console.Write("Enter new Last Name: ");
            string newLastName = Console.ReadLine();

            Console.Write("Enter new Salary: ");
            double newSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter new Hourly Rate (or press Enter to skip): ");
            string hourlyRateInput = Console.ReadLine();
            double? newHourlyRate = string.IsNullOrEmpty(hourlyRateInput) ? (double?)null : Convert.ToDouble(hourlyRateInput);

            Console.Write("Enter new Birth Day (YYYY-MM-DD): ");
            DateTime newBirthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter New Department Name: ");
            string department = Console.ReadLine();

            employeeService.UpdateEmployee(email, newFirstName, newLastName, newSalary, newHourlyRate, newBirthDay, department);
        }

        static void DeleteEmployee(EmployeeService employeeService)
        {
            Console.Write("Enter Email Address of the Employee to delete: ");
            string email = Console.ReadLine();

            employeeService.DeleteEmployee(email);
        }
    }
}
