using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


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
            // Code to get an employee by ID
            return new Employees();
        }

        public Employees AddEmployee(Employees employee)
    {
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();
        
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