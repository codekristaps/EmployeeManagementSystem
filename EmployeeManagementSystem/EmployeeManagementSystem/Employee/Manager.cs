using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class Manager : Employee
    {
        public double Bonus { get; set; }

        public Manager(string firstName, string lastName, string email, double salary, double? hourlyRate, DateTime birthDay, string department, double bonus)
            : base(firstName, lastName, email, salary, hourlyRate, birthDay, department)
        {
            Bonus = bonus;
        }
    }
}
