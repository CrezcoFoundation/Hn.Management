using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IRolePrivilegeService
    {
        IEnumerable<RolePrivilege> GetAll();
    }
}