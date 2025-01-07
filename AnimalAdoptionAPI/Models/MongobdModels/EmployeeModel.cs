using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AnimalAdoptionAPI.MongodbModels;

public class Employees
{

    [BsonId]

    public int _id { get; set; }

    public string first_name { get; set; }

    public string? last_name { get; set; }

    public string email { get; set; }

}
