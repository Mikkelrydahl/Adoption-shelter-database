using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;
using System.Collections.Generic;

namespace AnimalAdoptionAPI.Services
{
    public class AdoptionService : IAnimalService
    {

        private List<Animals> _animal = new();

        public Task<List<Animals>> GetAllAnimals()
        {
            // Code to get all animals
            return Task.FromResult(_animal);
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