using MongoDB.Driver;
using AnimalAdoptionAPI.MongodbModels;
using System.Collections.Generic;

namespace AnimalAdoptionAPI.MongodbServices;

public class MongodbAnimalService
{

   
    private readonly IMongoDatabase _database;

    public MongodbAnimalService(IMongoDatabase database)
    {
        _database = database;
    }

    public Task<List<Employees>> GetAllAnimals()
    {
        var animalCollection = _database.GetCollection<Employees>("animals");
        var result = animalCollection.Find(FilterDefinition<Employees>.Empty).ToList();

        return result;
    }
}