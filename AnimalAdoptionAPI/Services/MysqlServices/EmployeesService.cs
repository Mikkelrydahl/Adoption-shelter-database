using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using AnimalAdoptionAPI.Controllers;


namespace AnimalAdoptionAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AnimalAdoptionDbContext _dbContext;

        public EmployeeService(AnimalAdoptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employees> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();

        }

        public Employees GetEmployeeById(int employee_id)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.employee_id == employee_id);
        }

        public Employees AddEmployee(AddEmployeesDto employeeDto)
        {
            var employee = new Employees
            {
                first_name = employeeDto.first_name,
                last_name = employeeDto.last_name,
                email = employeeDto.email
            };
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return employee;
        }

        public Employees UpdateEmployee(int id, UpdateEmployeesDto updateEmployeeDto)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.employee_id == id);

            if (employee == null)
            {
                return null;
            }

            employee.first_name = updateEmployeeDto.first_name;
            employee.last_name = updateEmployeeDto.last_name;
            employee.email = updateEmployeeDto.email;


            _dbContext.SaveChanges();

            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.employee_id == id);

            if (employee != null)
            {
                _dbContext.Employees.Remove(employee); // Remove the employee from the database
                _dbContext.SaveChanges(); // Save changes to persist the deletion
                return true; // Return true to indicate successful deletion
            }

            return false;
        }
    }
}