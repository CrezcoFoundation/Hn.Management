using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Auth
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Task<IEnumerable<Role>> GetAllAsync()
        {
            return _roleRepository.GetAllAsync();
        }
         
        public Task<Role> GetAsync(string id)
        {
            return _roleRepository.GetAsync(id);
        }

        public Task<Role> InsertAsync(Role item)
        {
            return _roleRepository.InsertAsync(item);
        }

        public Task<Role> UpdateAsync(Role item)
        {
            return _roleRepository.UpdateAsync(item);
        }
    }
}
