using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Engine.ViewModels.Donations;
using HN.ManagementEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories
{
    public class DonationRepository: IDonationRepository
    {
        internal const string DonationPartition = "Donation";
        private readonly IDataManager<Donation> dataManager;
        public DonationRepository(IDataManager<Donation> donationManager)
        {
            this.dataManager = donationManager;
        }

        public IQueryable<Donation> GetAllQueryable()
        {
            return this.dataManager.GetAllAccessibleItemsAsQueryable();
        }

        public IEnumerable<Donation> GetAll()
        {
            var filter = this.GetAllQueryable();

            Expression<Func<Donation, bool>> matchPartitionKey = x => x.PartitionKey ==
            DonationPartition;
            filter = filter.Where(matchPartitionKey);

            return filter.AsEnumerable();
        }

        public async Task<IEnumerable<Donation>> GetAllAsync()
        {
            return await this.dataManager.GetAllAccessibleItemsAsync();
        }

        public async Task<Donation> GetAsync(string id)
        {
            return await this.dataManager.GetItemByIdAsync(id, DonationPartition);
        }

        public async Task<List<Donation>> GetListOfDonations(SearchDonationRequest searchDonationRequest)
        {
            var result = await this.dataManager.GetAllItemsByExpressionAsync(donation =>
                                                donation.DateDonated == searchDonationRequest.DateDonated);

            return result.Skip(searchDonationRequest.Skip).Take(searchDonationRequest.Top).ToList();
        }

        public async Task<Donation> InsertAsync(Donation item)
        {
            if (item == null)
            {
                throw new ArgumentException("One or more of the required properities its missing or has null value");
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString("D");
            }
            item.IsDeleted = true;

            return await this.dataManager.CreateItemAsync(item);
        }

        public async Task<Donation> UpdateAsync(Donation item)
        {
            item.LastUpdatedAt = DateTime.UtcNow;
            //TODO: we really need log the session name of the user (username, email, userId), for now I let "System", but this must change.
            item.LastUpdatedByName = "System";

            return await this.dataManager.UpsertItemAsync(item);
        }

        public async Task Delete(string id)
        {
            await this.dataManager.DeleteItemAsync(id);
        }
    }
}
