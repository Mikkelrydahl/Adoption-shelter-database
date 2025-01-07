using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.MongodbServices;
using AnimalAdoptionAPI.Models;


namespace AnimalAdoptionAPI.Dtos.MongoDbDtos;

[ApiController]
[Route("api/MongoDB")]
public class MongoDBAnimalsController : ControllerBase
{
    private readonly MongodbAnimalService _mongodbAnimalService;

    public MongoDBAnimalsController(MongodbAnimalService mongodbAnimalService)
    {
        _mongodbAnimalService = mongodbAnimalService;
    }

    [HttpGet("Animals")]
    public IActionResult GetAllAnimals()
    {
        var result = _mongodbAnimalService.GetAllAnimals();

        return Ok(result);
    }
    [HttpGet("Animals/{id}")]
    public IActionResult GetAnimalById(int id)
    {
        var result = _mongodbAnimalService.GetAnimalById(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("Animals")]
    public IActionResult AddAnimal([FromBody] AddAnimalDto animal)
    {
        _mongodbAnimalService.AddAnimal(animal);
        return Ok();
    }
}
