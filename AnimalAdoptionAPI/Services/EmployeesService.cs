using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;
using System.Collections.Generic;

namespace AnimalAdoptionAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employees> GetAllEmployees()
        {
            // Code to get all employees
            return new List<Employees>();
        }

        public Employees GetEmployeeById(int id)
        {
            // Code to get an employee by ID
            return new Employees();
        }

        public Employees AddEmployee(Employees employee)
        {
            // Code to add a new employee
            return employee;
        }

        public Employees UpdateEmployee(Employees employee)
        {
            // Code to update an employee
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            // Code to delete an employee
            
        }
    }
}