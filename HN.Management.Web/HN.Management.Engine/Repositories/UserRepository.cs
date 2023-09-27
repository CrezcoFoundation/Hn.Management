using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Repositories.Generic;
using HN.Management.Engine.Repositories.Interfaces;
using Microsoft.Azure.Cosmos;
using User = HN.ManagementEngine.Models.User;

namespace HN.Management.Engine.Repositories
{
    public class UserRepository : CosmosRepository<User>, IUserRepository
    {
        /// <summary>
        ///     CosmosDB container name
        /// </summary>
        public override string ContainerName { get; } = "TODO";

        /// <summary>
        ///  Generate Id.
        ///  e.g. "shoppinglist:783dfe25-7ece-4f0b-885e-c0ea72135942"
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override string GenerateId(User entity) => $"{entity.Id}:{Guid.NewGuid()}";

        /// <summary>
        ///  Returns the value of the partition key
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId.Split(':')[0]);

        public UserRepository(ICosmosContainerFactory factory) : base(factory)
        {
        }

        // Use Cosmos DB Parameterized Query to avoid SQL Injection. 
        public async Task<IEnumerable<User>> GetUserByEmail(string email)
        {
            List<User> results = new List<User>();
            string query = @$"SELECT c.Name FROM c WHERE c.Email = @Email";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                                                    .WithParameter("@Email", email);
            string queryString = queryDefinition.QueryText;

            IEnumerable<User> entities = await this.GetItemsAsync(queryString);

            return results;
        }

        // Use Cosmos DB Parameterized Query to avoid SQL Injection.
        public async Task<IEnumerable<User>> FilterUsers(User user)
        {

            List<User> results = new List<User>();
            string query = @$"SELECT c.Name FROM c WHERE c.Email = @Email";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                                                    .WithParameter("@Email", user.Email);
            string queryString = queryDefinition.QueryText;

            IEnumerable<User> entities = await this.GetItemsAsync(queryString);

            return results;
        }
    }
}
