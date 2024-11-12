using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AnimalAdoptionAPI.Models;

public class Animals
{
    [JsonProperty("AnimalId")]
    public int AnimalId { get; set; }

    public string Name { get; set; }

    public string Breed { get; set; }

    public int Species { get; set; }

    public string Description { get; set; }

    public int Age { get; set; }

    public override string ToString()
    {
        return $"id: {AnimalId}, name: {Name}, breed: {Breed}, species: {Species}, description: {Description}, age: {Age}";
    }
}