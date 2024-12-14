using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AnimalAdoptionAPI.Models;

public class Products
{
    [JsonProperty("ProductId")]
    public int ProductId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Category { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"id: {ProductId}, name: {Name}, price: {Price}, category: {Category}, description: {Description}";
    }
}