using HN.Management.Engine.CosmosDb.Interfaces;
using Microsoft.Azure.Cosmos;

namespace HN.Management.Engine.CosmosDb
{
    public class CosmosDbContainer : ICosmosContainer
    {
        public Container _container { get; }

        public CosmosDbContainer(CosmosClient cosmosClient,
                                 string databaseName,
                                 string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }
    }
}

