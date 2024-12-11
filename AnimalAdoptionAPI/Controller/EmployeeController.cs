/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AnimalAdoptionAPI.Services;
using AnimalAdoptionAPI.Interfaces;

namespace AnimalAdoptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AnimalAdoptionDbContext _context;
        private readonly IEmployeeService _employeeService;

        public TestController(AnimalAdoptionDbContext context)
        {
            _context = context;
        }

        // GET: api/test
         [HttpGet("employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }
    }
}
*/
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
        public IActionResult AddEmployee([FromBody] AddEmployeesDto employeeDto)
        {
            // var employee = new Employees
            // {
            //     first_name = employeeDto.first_name,
            //     last_name = employeeDto.last_name,
            //     email = employeeDto.email
            // };
            var newEmployee = _employeeService.AddEmployee(employeeDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.employee_id }, newEmployee);
        }

        // Update an employee
        [HttpPut("employees/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeesDto updateEmployee)
        {
            // Call the service to update the employee
            var updatedEmployee = _employeeService.UpdateEmployee(id, updateEmployee);

            // If the employee is not found
            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return NoContent(); // Successfully updated, no content to return
        }

        // Delete an employee
        [HttpDelete("employees/{id}")]
        public IActionResult DeleteEmployee(int id)
        {

            var isDeleted = _employeeService.DeleteEmployee(id);

            if (isDeleted)
            {
                return Ok(); // 200 No Content
            }
            else
            {
                return NotFound(); // 404 Not Found
            }
        }

    }
}