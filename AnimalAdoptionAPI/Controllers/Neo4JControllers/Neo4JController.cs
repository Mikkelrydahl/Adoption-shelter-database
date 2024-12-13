using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Neo4JServices;
using AnimalAdoptionAPI.Interfaces;

namespace AnimalAdoptionAPI.Neo4JControllers
{
    [ApiController]
    [Route("api/[controller]asdfasdfasdfasfas")]
    public class Neo4JController : ControllerBase
    {
        private readonly Neo4jService _neo4jService;

        public Neo4JController(Neo4jService neo4JService)
        {
            _neo4jService = neo4JService;
        }
        
        
        [HttpGet("NEO4J!!!!!!!!!!!!!!!!!!!")]
        public async Task<IActionResult> GetAllNodes()
        {
            var nodes = await _neo4jService.GetAllNodesAsync();
            return Ok();
        }
    }
}