using Microsoft.Azure.Cosmos;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
	public interface ICosmosContainer
	{
        /// <summary>
        /// Instance of Azure Cosmos DB Container class
        /// </summary> 
        Container _container { get; }
    }
}

