using AnimalAdoptionAPI.Models;
using MongoDB.Driver;



namespace AnimalAdoptionAPI.MongodbServices;

public class MongodbService
{
    private readonly IMongoDatabase _database;

    public MongodbService(IMongoDatabase database)
    {
        _database = database;
    }


    public List<Employees> GetAllEmployees()
    {
        var employeeCollection = _database.GetCollection<Employees>("Employees");
        var result = employeeCollection.Find(FilterDefinition<Employees>.Empty).ToList();

        return result;

    }


}