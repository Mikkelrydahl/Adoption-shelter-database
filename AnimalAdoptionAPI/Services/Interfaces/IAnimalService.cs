using AnimalAdoptionAPI.Models;


namespace AnimalAdoptionAPI.Interfaces
{
    public interface IAnimalService
    {
        Task<List<Animals>> GetAllAnimals();
        Animals GetAnimalById(int id);
        Animals AddAnimal(Animals animal);
        Animals UpdateAnimal(int id, Animals updatedAnimal);
        void DeleteAnimal(int id);
    }
}