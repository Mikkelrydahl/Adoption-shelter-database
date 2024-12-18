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
    public class MySQLController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public MySQLController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Example: Get all employees

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // Add a new employee
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] AddEmployeesDto employeeDto)
        {
            var newEmployee = _employeeService.AddEmployee(employeeDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.employee_id }, newEmployee);
        }

        // Example: Get an employee by ID
        [HttpGet("GetEmployee/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("No Employee with id " + id);
            }
            return Ok(employee);
        }

        // Update an employee
        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeesDto updateEmployee)
        {
            // Call the service to update the employee
            var updatedEmployee = _employeeService.UpdateEmployee(id, updateEmployee);

            // If the employee is not found
            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee); // Successfully updated, no content to return
        }

        // Delete an employee
        [HttpDelete("DeleteEmployee/{id}")]
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