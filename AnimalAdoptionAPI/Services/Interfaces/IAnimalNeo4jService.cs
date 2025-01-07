using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Neo4jDtos;


namespace AnimalAdoptionAPI.Interfaces
{
    public interface IAnimalNeo4jService
    {
        Task<List<Animals>> GetAllAnimals();
        Task<Animals> GetAnimalById(int id);
        Task AddAnimal(AddAnimalNodeDto animal);
        Task<Animals> UpdateAnimal(int id, Animals updatedAnimal);
        Task DeleteAnimal(int id);
    }
}