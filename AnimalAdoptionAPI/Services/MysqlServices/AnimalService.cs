using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoptionAPI.Services.Mysql
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalAdoptionDbContext _dbContext;

        public AnimalService(AnimalAdoptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private List<Animals> _animal = new();

        public async Task<List<Animals>> GetAllAnimals()
        {
            try
            {
                // Assuming _context is your DbContext (e.g., AnimalDbContext)
                return await _dbContext.Animals.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving animals: {ex.Message}");
            }

        }

        public Animals GetAnimalById(int id)
        {
            // Code to get an animal by ID
            return _animal.FirstOrDefault(a => a.id == id);
        }

        public Animals AddAnimal(Animals animal)
        {
            animal.id = _animal.Count > 0 ? _animal.Max(a => a.id) + 1 : 1;
            _animal.Add(animal);
            return animal;
        }

        public Animals UpdateAnimal(int id, Animals updatedAnimal)
        {
            var Animal = _animal.FirstOrDefault(a => a.id == id);
            if (Animal != null)
            {
                Animal.pet_name = updatedAnimal.pet_name;
                Animal.breed = updatedAnimal.breed;
                Animal.age = updatedAnimal.age;
            }

            return updatedAnimal;
        }

        public void DeleteAnimal(int id)
        {
            var animal = _animal.FirstOrDefault(a => a.id == id);
            if (animal != null)
            {
                _animal.Remove(animal);
            }

        }
    }
}