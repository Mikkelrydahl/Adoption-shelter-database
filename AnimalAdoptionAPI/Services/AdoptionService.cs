using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;
using System.Collections.Generic;

namespace AnimalAdoptionAPI.Services
{
    public class AdoptionService : IAdoptionService
    {

        private List<Animals> _animal = new();

        public List<Animals> GetAllAnimals()
        {
            // Code to get all animals
            return new List<Animals>();
        }

        public Animals GetAnimalById(int id)
        {
            // Code to get an animal by ID
            return _animal.FirstOrDefault(a => a.AnimalId == id);
        }

        public Animals AddAnimal(Animals animal)
        {
            animal.AnimalId = _animal.Count > 0 ? _animal.Max(a => a.AnimalId) + 1 : 1;
            _animal.Add(animal);
            return animal;
        }

        public Animals UpdateAnimal(int id, Animals updatedAnimal)
        {
            var Animal = _animal.FirstOrDefault(a => a.AnimalId == id);
            if (Animal != null)
            {
                Animal.Name = updatedAnimal.Name;
                Animal.Breed = updatedAnimal.Breed;
                Animal.Age = updatedAnimal.Age;
                Animal.Description = updatedAnimal.Description;
            }

            return updatedAnimal;
        }

        public void DeleteAnimal(int id)
        {
            var animal = _animal.FirstOrDefault(a => a.AnimalId == id);
            if (animal != null)
            {
                _animal.Remove(animal);
            }

        }
    }
}