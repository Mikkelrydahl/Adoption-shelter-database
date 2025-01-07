using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.MongodbServices;
using AnimalAdoptionAPI.Models;


[ApiController]
[Route("api/MongoDB")]
public class MongoDBEmployeesController : ControllerBase
{
    private readonly MongodbService _mongodbService;

    public MongoDBEmployeesController(MongodbService mongodbService)
    {
        _mongodbService = mongodbService;
    }

    [HttpGet("Employees")]
    public IActionResult GetAllEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpPost("Employees")]
    public IActionResult AddEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpGet("Employees/{id}")]
    public IActionResult GetEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpPut("Employees/{id}")]
    public IActionResult UpdateEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpDelete("Employees/{id}")]
    public IActionResult DeleteEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }
}




