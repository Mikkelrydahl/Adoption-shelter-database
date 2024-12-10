using AnimalAdoptionAPI.Models;


namespace AnimalAdoptionAPI.Interfaces
{
    public interface IAdoptionService
    {
        List<Animals> GetAllAnimals();
        Animals GetAnimalById(int id);
        Animals AddAnimal(Animals animal);
        Animals UpdateAnimal(int id, Animals updatedAnimal);
        void DeleteAnimal(int id);

        // Eller skal de hedde void AddAnimal(Animals animal);?
    }
}