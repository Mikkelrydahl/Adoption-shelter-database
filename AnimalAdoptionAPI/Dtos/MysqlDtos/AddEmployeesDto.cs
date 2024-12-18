using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionAPI.Models;

public class AddEmployeesDto
{  
    public string first_name { get; set; }

    public string? last_name { get; set; }

    public string email { get; set; }
}
