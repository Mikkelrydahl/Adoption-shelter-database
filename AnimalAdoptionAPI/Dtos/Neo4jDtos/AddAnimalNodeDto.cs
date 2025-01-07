using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AnimalAdoptionAPI.Neo4jDtos;

public class AddAnimalNodeDto
{

    public string pet_name { get; set; }
    public int age { get; set; }

}