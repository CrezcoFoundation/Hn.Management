using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Auth
{
    public class PrivilegeService : IPrivilegeService
    {
        private readonly IPrivilegeRepository _privilegeRepository;
        public PrivilegeService(IPrivilegeRepository privilegeRepository)
        {
            _privilegeRepository = privilegeRepository;
        }

        public Task Delete(string id)
        {
            return _privilegeRepository.Delete(id);
        }

        public IEnumerable<Privilege> GetAll()
        {
            return _privilegeRepository.GetAll();
        }

        public async Task<IEnumerable<Privilege>> GetAllAsync()
        {
            return await _privilegeRepository.GetAllAsync();
        }

        public IQueryable<Privilege> GetAllQueryable()
        {
            return _privilegeRepository.GetAllQueryable();
        }

        public async Task<Privilege> GetAsync(string id)
        {
            return await _privilegeRepository.GetAsync(id);
        }

        public Privilege GetPrivilegeByName(string privilegeName)
        {
            return _privilegeRepository.GetPrivilegeByName(privilegeName);
        }

        public List<Privilege> GetPrivilegesByIds(List<string> ids)
        {
            return _privilegeRepository.GetPrivilegesByIds(ids);
        }

        public async Task<Privilege> InsertAsync(Privilege item)
        {
            return await _privilegeRepository.InsertAsync(item);
        }

        public async Task<Privilege> UpdateAsync(Privilege item)
        {
            return await _privilegeRepository.UpdateAsync(item);
        }
    }
}
