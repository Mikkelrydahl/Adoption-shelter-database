using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.MongodbServices;



[ApiController]
[Route("api/[controller]")]
public class MongoDBAnimalController : ControllerBase
{
    private readonly MongodbAnimalService _mongodbAnimalService;

    public MongoDBAnimalController(MongodbAnimalService mongodbAnimalService)
    {
        _mongodbAnimalService = mongodbAnimalService;
    }

    [HttpGet("Animals")]
    public async Task<IActionResult> GetAllAnimals()
    {
       // var result = await _mongodbAnimalService.GetAllAnimals();

        return Ok("result");
    }
}