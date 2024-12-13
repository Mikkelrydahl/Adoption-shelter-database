using Neo4j.Driver;



namespace AnimalAdoptionAPI.Neo4JServices
{

    public class Neo4jService
    {
        private readonly IDriver _driver;

        public Neo4jService(IDriver driver)
        {
            _driver = driver;
        }

        public async Task<List<string>> GetAllNodesAsync()
        {
            var result = new List<string>();
            var session = _driver.AsyncSession();

            await using (session)
            {
                var query = "MATCH (n) RETURN n.name AS name, labels(n) AS labels";
                var nodes = await session.RunAsync(query);


                await foreach (var node in nodes)
                {
                    string tempResult = "" + node["labels"].As<List<string>>()[0];
                    tempResult += " " + node["name"].As<string>();

                    if (tempResult != null)
                    {
                        result.Add(tempResult);
                    }
                }
            }

            return result;
        }

        public async Task AddNodeAsync(string label, string name)
        {
            var session = _driver.AsyncSession();
            try
            {
                var query = $"CREATE (n:{label} {{name: $name}})";


                await session.RunAsync(query, new { name = name });
            }
            finally
            {
                await session.CloseAsync();
            }
        }
    }
}