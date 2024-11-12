using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AnimalAdoptionAPI.Models;

public class Employees
{
    [JsonProperty("EmployeeId")]
    public int EmployeeId { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public override string ToString()
    {
        return $"id: {EmployeeId}, name: {Name}, last name: {LastName}, email: {Email}";
    }
}