using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AnimalAdoptionAPI.Models;

public class Products
{
    [Key]
    public int id { get; set; }

    public string product_name { get; set; }

    public decimal price { get; set; }

    public int category { get; set; }
    public string description { get; set; }

}