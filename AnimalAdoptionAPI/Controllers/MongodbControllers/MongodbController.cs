using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.MongodbServices;
using AnimalAdoptionAPI.Models;


[ApiController]
[Route("api/[controller]")]
public class MongodbController : ControllerBase
{
    private readonly MongodbService _mongodbService;

    public MongodbController(MongodbService mongodbService)
    {
        _mongodbService = mongodbService;
    }

    [HttpGet("GetAllEmployees")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var result = _mongodbService.GetAllEmployees();

        return Ok(result);
    }
}




