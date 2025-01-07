using Neo4j.Driver;
using AnimalAdoptionAPI.Interfaces;
using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Models.Neo4j;
using System;
using AnimalAdoptionAPI.Neo4jDtos;
using System.Threading.Tasks;

namespace AnimalAdoptionAPI.Neo4jAnimalServices
{
    public class Neo4jAnimalService : IAnimalNeo4jService
    {
        private readonly IDriver _neo4jDriver;

        public Neo4jAnimalService(IDriver neo4jDriver)
        {
            _neo4jDriver = neo4jDriver;
        }

        public async Task<List<Animals>> GetAllAnimals()
        {
            var neo4janimals = new List<Animals>();

            var query = "MATCH (a:Animal) RETURN a";

            using var session = _neo4jDriver.AsyncSession();
            var result = await session.RunAsync(query);

            await result.ForEachAsync(record =>
            {
                var node = record["a"].As<INode>();
                neo4janimals.Add(new Animals
                {
                    id = (int)node.Properties["id"],
                    pet_name = node.Properties["name"].ToString(),
                    age = (int)node.Properties["age"]
                });
            });

            return neo4janimals;
        }

        public async Task<Animals> GetAnimalById(int id)
        {
            var query = "MATCH (a:Animal {id: $id}) RETURN a";

            using var session = _neo4jDriver.AsyncSession();
            var result = await session.RunAsync(query, new { id });

            var records = await result.ToListAsync();
            var record = records.SingleOrDefault();

            if (record == null)
            {
                return null;
            }

            var node = record["a"].As<INode>();
            return new Animals
            {
                id = (int)node.Properties["id"],
                pet_name = node.Properties["name"].ToString(),
                age = (int)node.Properties["age"],
            };
        }

        public async Task AddAnimal(AddAnimalNodeDto animal)
        {
            var session = _neo4jDriver.AsyncSession();

            var id = Guid.NewGuid().ToString(); // Generate a unique ID
            string cypherQuery = @"
                MERGE (a:Animal { id: $id, name: $name, age: $age })
                RETURN a";

            try
            {
                await session.RunAsync(cypherQuery, new { name = animal.pet_name });
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public async Task<Animals> UpdateAnimal(int id, Animals updatedAnimal)
        {
            var query = @"
                MATCH (a:Animal {id: $id})
                SET a.name = $name, a.age = $age
                RETURN a";

            var parameters = new
            {
                id,
                name = updatedAnimal.pet_name,
                age = updatedAnimal.age
            };

            try
            {
                var session = _neo4jDriver.AsyncSession();
                Animals result = null;

                await session.ExecuteWriteAsync(async tx =>
                {
                    var cursor = await tx.RunAsync(query, parameters);
                    var record = await cursor.SingleAsync();

                    if (record != null)

                    {
                        var node = record["a"].As<INode>();

                        {
                            result = new Animals
                            {
                                id = id,
                                pet_name = node["name"].As<string>(),
                                age = node["age"].As<int>()
                            };
                        }
                    }
                });
                return result ?? throw new Exception("Animal not found or could not be updated.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating animal: {ex.Message}");
            }

        }

        public async Task DeleteAnimal(int id)
        {
            var query = "MATCH (a:Animal {id: $id}) DELETE a";

            try
            {
                var session = _neo4jDriver.AsyncSession();

                await session.ExecuteWriteAsync(async tx =>
                {
                    await tx.RunAsync(query, new { id });
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting animal: {ex.Message}");
            }
        }
    }
}