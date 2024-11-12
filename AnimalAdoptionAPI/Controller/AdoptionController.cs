using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.Models;  // Ensure this is added
using AnimalAdoptionAPI.Services;

namespace AnimalAdoptionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionController : ControllerBase
    {
        private readonly AdoptionService _adoptionService;

        // Constructor that injects the AdoptionService
        public AdoptionController(AdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        // GET: api/adoption/animal/{id}
        [HttpGet("animal/{id}")]
        public ActionResult<Animals> GetAnimal(int id)
        {
            var animal = _adoptionService.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();  // Return 404 if not found
            }
            return Ok(animal);  // Return the animal with 200 OK status
        }
    }
}