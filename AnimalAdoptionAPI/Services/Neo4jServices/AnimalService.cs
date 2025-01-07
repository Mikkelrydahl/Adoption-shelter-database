// using Neo4j.Driver;
// using AnimalAdoptionAPI.Interfaces;
// using AnimalAdoptionAPI.Models;
// using AnimalAdoptionAPI.Models.Neo4j;
// using System;
// using System.Threading.Tasks;

// namespace AnimalAdoptionAPI.AnimalServices
// {
//     public class AnimalService : IAnimalService
//     {
//         private readonly IDriver _neo4jDriver;

//         public AnimalService(IDriver neo4jDriver)
//         {
//             _neo4jDriver = neo4jDriver;
//         }

//         public async Task<List<Animals>> GetAllAnimals()
//         {
//             var neo4janimals = new List<Animals>();

//             var query = "MATCH (a:Animal) RETURN a";

//             using var session = _neo4jDriver.AsyncSession();
//             var result = await session.RunAsync(query);

//             await result.ForEachAsync(record =>
//             {
//                 var node = record["a"].As<INode>();
//                 neo4janimals.Add(new Animals
//                 {
//                     id = (int)node.Properties["id"],
//                     pet_name = node.Properties["name"].ToString(),
//                     age = (int)node.Properties["age"]
//                 });
//             });

//             return neo4janimals;
//         }

//         public async Task<Animals> GetAnimalById(int id)
//         {
//             var query = "MATCH (a:Animal {id: $id}) RETURN a";

//             using var session = _neo4jDriver.AsyncSession();
//             var result = await session.RunAsync(query, new { id });

//             var records = await result.ToListAsync();
//             var record = records.SingleOrDefault();

//             if (record == null)
//             {
//                 return null;
//             }

//             var node = record["a"].As<INode>();
//             return new Animals
//             {
//                 id = (int)node.Properties["id"],
//                 pet_name = node.Properties["name"].ToString(),
//                 age = (int)node.Properties["age"],
//             };
//         }

//         public async Task<string> AddAnimal(string name, int age)
//         {
//             var id = Guid.NewGuid().ToString(); // Generate a unique ID
//             string cypherQuery = @"
//                 CREATE (a:Animal { id: $id, name: $name, age: $age })
//                 RETURN a";

//             var parameters = new
//             {
//                 id,
//                 name,
//                 age
//             };

//             try
//             {
//                 var session = _neo4jDriver.AsyncSession();
//                 await session.WriteTransactionAsync(async tx =>
//                 {
//                     await tx.RunAsync(cypherQuery, parameters);
//                 });

//                 return id; // Return the generated ID
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception($"Error while adding animal: {ex.Message}");
//             }
//         }

//         public async Task UpdateAnimal(int id, Animals animal)
//         {
//             var query = @"
//                 MATCH (a:Animal {id: $id})
//                 SET a.name = $name, a.age = $age
//                 RETURN a";

//             var parameters = new
//             {
//                 id,
//                 name = animal.pet_name,
//                 age = animal.age
//             };

//             try
//             {
//                 var session = _neo4jDriver.AsyncSession();
//                 await session.WriteTransactionAsync(async tx =>
//                 {
//                     await tx.RunAsync(query, parameters);
//                 });
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception($"Error while updating animal: {ex.Message}");
//             }
//         }

//         public async Task DeleteAnimal(int id)
//         {
//             var query = "MATCH (a:Animal {id: $id}) DELETE a";

//             try
//             {
//                 var session = _neo4jDriver.AsyncSession();
//                 await session.WriteTransactionAsync(async tx =>
//                 {
//                     await tx.RunAsync(query, new { id });
//                 });
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception($"Error while deleting animal: {ex.Message}");
//             }
//         }
//     }
// }