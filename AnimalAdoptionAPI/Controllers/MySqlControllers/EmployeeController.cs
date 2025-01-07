using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;

namespace AnimalAdoptionAPI.Controllers
{
    [ApiController]
    [Route("api/MySQL")]
    public class MySQLEmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public MySQLEmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("Employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost("Employees")]
        public IActionResult AddEmployee([FromBody] AddEmployeesDto employeeDto)
        {
            var newEmployee = _employeeService.AddEmployee(employeeDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.employee_id }, newEmployee);
        }

        [HttpGet("Employees/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("No Employee with id " + id);
            }
            return Ok(employee);
        }

        [HttpPut("Employees/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeesDto updateEmployee)
        {
            var updatedEmployee = _employeeService.UpdateEmployee(id, updateEmployee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("Employees/{id}")]
        public IActionResult DeleteEmployee(int id)
        {

            var isDeleted = _employeeService.DeleteEmployee(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}