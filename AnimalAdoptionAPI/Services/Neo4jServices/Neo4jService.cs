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
                var query = @"
            MATCH (a:Animal)
            RETURN a.pet_name AS result, 'Animal' AS type
            UNION
            MATCH (a:Animal)
            RETURN a.name as result, 'Animal' AS type
            UNION
            MATCH (e:Employee)
            RETURN e.first_name AS result, 'Employee' AS type
            UNION
            MATCH (c:Category)
            RETURN c.category_name AS result, 'Category' AS type
            UNION
            MATCH (m:MedicalAppointment)
            RETURN m.appointment_description AS result, 'MedicalAppointment' AS type
            UNION
            MATCH (o:Order)
            RETURN o.email AS result, 'Order' AS type
            UNION
            MATCH (p:Product)
            RETURN p.product_name AS result, 'Product' AS type
        ";

                var nodes = await session.RunAsync(query);

                await foreach (var node in nodes)
                {
                    // Combine the result and type into a formatted string
                    string tempResult = $"{node["type"].As<string>()}: {node["result"].As<string>()}";

                    if (!string.IsNullOrEmpty(tempResult))
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