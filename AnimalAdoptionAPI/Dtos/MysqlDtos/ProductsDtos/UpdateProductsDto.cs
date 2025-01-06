using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AnimalAdoptionAPI.Models;

public class UpdateProductsDto
{

    public string name { get; set; }

    public decimal price { get; set; }

    public int category { get; set; }
    public string description { get; set; }

}