using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Services;
using AnimalAdoptionAPI.Interfaces;

namespace AnimalAdoptionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Example: Get all employees

        [HttpGet("employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // Example: Get an employee by ID
        [HttpGet("employees/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // Add a new employee
        [HttpPost("employees")]
        public IActionResult AddEmployee([FromBody] Employees employee)
        {
            var newEmployee = _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.EmployeeId }, newEmployee);
        }

        // Update an employee
        [HttpPut("employees")]
        public IActionResult UpdateEmployee([FromBody] Employees employee)
        {
            var updatedEmployee = _employeeService.UpdateEmployee(employee);
            return Ok(updatedEmployee);
        }

        // Delete an employee
        [HttpDelete("employees/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return NoContent();
        }

    }
}