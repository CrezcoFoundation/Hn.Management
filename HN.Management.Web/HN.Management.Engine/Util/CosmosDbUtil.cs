using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.Management.Engine.Util
{
    public static class CosmosDBUtil
    {
        public const int DefaultPageSize = 15;
        public const int DefaultSkipSize = 0;

        public static async Task<IList<T>> ToListAsync<T>(
            this FeedIterator<T> feedIterator,
            bool logRequestCharges,
            string databaseName,
            string collectionName)
        {
            var requestChargeLog = logRequestCharges ? new Dictionary<string, dynamic>
                {
                    { "requestOrigin", "CosmosDbUtil" },
                    { "method", "ToListAsync" },
                    { "database", databaseName },
                    { "collection", collectionName },
                    { "requestCharges", 0 },
                }
                : null;

            var results = new List<T>();
            while (feedIterator.HasMoreResults)
            {
                var result = await feedIterator.ReadNextAsync();
                results.AddRange(result);

                if (logRequestCharges)
                {
                    requestChargeLog["requestCharges"] = requestChargeLog["requestCharges"] += result.RequestCharge;
                    requestChargeLog["activityId"] = result.ActivityId;
                }
            }

            if (logRequestCharges)
            {
                Console.WriteLine(requestChargeLog.ToJsonString());
            }

            return results;
        }

        public static async Task<IList<T>> ToListAsync<T>(
            this IQueryable<T> queryable,
            bool logRequestCharges,
            string databaseName,
            string collectionName)
        {
            var feedIterator = queryable.ToFeedIterator();
            return await feedIterator.ToListAsync(
                logRequestCharges,
                databaseName,
                collectionName);
        }
    }
}
