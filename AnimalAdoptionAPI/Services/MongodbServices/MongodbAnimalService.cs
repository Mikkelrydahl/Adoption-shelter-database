using AnimalAdoptionAPI.MongodbModels;
using MongoDB.Driver;
using AnimalAdoptionAPI.Dtos.MongoDbDtos;

namespace AnimalAdoptionAPI.MongodbServices;

public class MongodbAnimalService
{
    private readonly IMongoDatabase _database;


    public MongodbAnimalService(IMongoDatabase database)
    {
        _database = database;
    }

    public List<Animal> GetAllAnimals()
    {
        var employeeCollection = _database.GetCollection<Animal>("animals");
        var result = employeeCollection.Find(FilterDefinition<Animal>.Empty).ToList();

        return result;
    }

    public Animal GetAnimalById(int id)
    {
        var employeeCollection = _database.GetCollection<Animal>("animals");
        var filter = Builders<Animal>.Filter.Eq(a => a._id, id);
        var result = employeeCollection.Find(FilterDefinition<Animal>.Empty).FirstOrDefault();

        return result;
    }

    public Animal AddAnimal(AddAnimalDto addAnimalDto)
    {
        var employeeCollection = _database.GetCollection<Animal>("animals");

        var animal = new Animal
        {
            PetName = addAnimalDto.pet_name,
            Age = addAnimalDto.age,
            Species = addAnimalDto.species,
            Breed = addAnimalDto.breed
        };

        employeeCollection.InsertOne(animal);
        return animal;
    }
}
