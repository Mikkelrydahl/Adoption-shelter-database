using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AnimalAdoptionAPI.Models;

public class Animals
{
    [Key]
    public int id { get; set; }

    public string pet_name { get; set; }

    public string breed { get; set; }

    public int species { get; set; }

    public int age { get; set; }

}