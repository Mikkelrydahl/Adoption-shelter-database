using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Services;
using AnimalAdoptionAPI.Interfaces;

namespace AnimalAdoptionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _adoptionService;

        public AnimalController(IAnimalService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        // Example: Get all animals
        [HttpGet("animals")]
        public IActionResult GetAllAnimals()
        {
            var animals = _adoptionService.GetAllAnimals();
            return Ok(animals);
        }

        // Example: Get an animal by ID
        [HttpGet("animals/{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = _adoptionService.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        // Example: Add a new animal (optional)
        [HttpPost("animals")]
        public IActionResult AddAnimal([FromBody] Animals animal)
        {
            var newAnimal = _adoptionService.AddAnimal(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = newAnimal.id }, newAnimal);
        }
    }
}