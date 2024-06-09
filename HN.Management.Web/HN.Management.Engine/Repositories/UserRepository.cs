﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Repositories.Interfaces;
using User = HN.ManagementEngine.Models.User;
using HN.Management.Engine.ViewModels;
using HN.Management.Engine.Util;

namespace HN.Management.Engine.Repositories
{
    public class UserRepository : IUserRepository
    {
        internal const string UserPartition = "User";
        private readonly IDataManager<User> dataManager;

        public UserRepository(IDataManager<User> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IQueryable<User> GetAllQueryable()
        {
            return this.dataManager.GetAllAccessibleItemsAsQueryable();
        }

        public IEnumerable<User> GetAll()
        {
            var filter = this.GetAllQueryable();

            Expression<Func<User, bool>> matchPartitionKey = x => x.PartitionKey ==
            UserPartition;
            filter = filter.Where(matchPartitionKey);

            return filter.AsEnumerable();
        }

        public async Task<User> GetUserAsync(LoginRequest loginRequest)
        {

            var users = await this.dataManager.GetAllItemsByExpressionAsync(user =>
            user.Email == loginRequest.Email
            && user.Password ==loginRequest.Password);

            return users.ToList().FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.dataManager.GetAllAccessibleItemsAsync();
        }

        public async Task<User> GetAsync(string id)
        {
            return await this.dataManager.GetItemByIdAsync(id, UserPartition);
        }

        public async Task<User> InsertAsync(User item)
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

        public async Task<User> UpdateAsync(User item)
        {
            item.LastUpdatedAt = DateTime.UtcNow;
            //TODO: we really need log the session name of the user (username, email, userId), for now I let "System", but this must change.
            item.LastUpdatedByName = "System";

            return await this.dataManager.UpsertItemAsync(item);
        }

        public async Task Delete(string id)
        {
            await this.dataManager.DeleteItemAsync(id, UserPartition);
        }
    }
}
