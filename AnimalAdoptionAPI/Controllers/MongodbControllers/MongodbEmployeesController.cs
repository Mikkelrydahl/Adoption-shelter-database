using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.MongodbServices;
using AnimalAdoptionAPI.MongodbModels;


[ApiController]
[Route("api/[controller]")]
public class MongoDBEmployeesController : ControllerBase
{
    private readonly MongodbService _mongodbService;

    public MongoDBEmployeesController(MongodbService mongodbService)
    {
        _mongodbService = mongodbService;
    }

    [HttpGet("GetAllEmployees")]
    public IActionResult GetAllEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpPost("AddEmployee")]
    public IActionResult AddEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpGet("GetEmployee/{id}")]
    public IActionResult GetEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpPut("UpdateEmployee/{id}")]
    public IActionResult UpdateEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }

    [HttpDelete("DeleteEmployee/{id}")]
    public IActionResult DeleteEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }
}




