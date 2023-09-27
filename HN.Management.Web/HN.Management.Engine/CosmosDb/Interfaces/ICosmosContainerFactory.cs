using System.Threading.Tasks;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
	public interface ICosmosContainerFactory
	{
        /// <summary>
        /// Returns a CosmosDbContainer wrapper
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        ICosmosContainer GetContainer(string containerName);

        /// <summary>
        /// Ensure the database is created
        /// </summary>
        /// <returns></returns>
        Task EnsureDbSetupAsync();
    }
}

