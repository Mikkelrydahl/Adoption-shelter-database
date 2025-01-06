using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionAPI.Models;


public class UpdateEmployeesDto
{  
    public string first_name { get; set; }

    public string? last_name { get; set; }

    public string email { get; set; }

}
