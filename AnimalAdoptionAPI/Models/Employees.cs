using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionAPI.Models;



    public class Employees
    {  
        [Key]
        public int employee_id { get; set; }

        public string first_name { get; set; }

        public string? last_name { get; set; }

        public string email { get; set; }

       /* public override string ToString()
        {
            return $"id: {employee_id}, name: {first_name}, last name: {last_nadddddddddme}, email: {email}";
        }*/
        
    }
