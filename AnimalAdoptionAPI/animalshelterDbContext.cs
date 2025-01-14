using Microsoft.EntityFrameworkCore;
using AnimalAdoptionAPI.Models;

namespace AnimalAdoptionAPI   // MYSQL
{
    public class AnimalAdoptionDbContext : DbContext
    {
        public AnimalAdoptionDbContext(DbContextOptions<AnimalAdoptionDbContext> options)
            : base(options)
        {
        }

        public required DbSet<Employees> Employees { get; set; }
        public required DbSet<Products> Products { get; set; }
        public required DbSet<Animals> Animals { get; set; }


    }
}