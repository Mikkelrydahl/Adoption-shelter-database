using Microsoft.EntityFrameworkCore;
using AnimalAdoptionAPI.Models;

namespace AnimalAdoptionAPI
{
    public class AnimalAdoptionDbContext : DbContext
    {
        public AnimalAdoptionDbContext(DbContextOptions<AnimalAdoptionDbContext> options)
            : base(options)
        {
        }

        public required DbSet<Employees> Employees { get; set; } 
    }
}