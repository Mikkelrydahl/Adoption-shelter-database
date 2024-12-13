using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionAPI.Neo4jDtos;

public class AddNodeDto
{
    public string? label { get; set; }
    public string? name { get; set; }
}
