using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Neo4JServices;
using AnimalAdoptionAPI.Interfaces;
using AnimalAdoptionAPI.Neo4jDtos;

namespace AnimalAdoptionAPI.Neo4JControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Neo4JController : ControllerBase
    {
        private readonly Neo4jService _neo4jService;

        public Neo4JController(Neo4jService neo4JService)
        {
            _neo4jService = neo4JService;
        }


        [HttpGet("GetAllNodes")]
        public async Task<IActionResult> GetAllNodes()
        {
            var nodes = await _neo4jService.GetAllNodesAsync();
            return Ok(nodes);
        }

        [HttpPost("AddNode")]
        public async Task<IActionResult> AddNode([FromBody] AddNodeDto addNodeDto)
        {
            await _neo4jService.AddNodeAsync(addNodeDto.label, addNodeDto.name);

            return Ok("Node added successfully with label: " + addNodeDto.label + " and name: " + addNodeDto.name);
        }

    }
}