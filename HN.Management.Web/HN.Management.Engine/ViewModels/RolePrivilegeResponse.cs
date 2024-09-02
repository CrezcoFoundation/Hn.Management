using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;

namespace HN.Management.Engine.ViewModels
{
    public class RolePrivilegeResponse
    {
        public Role Role { get; set; }
        public List<PrivilegeDetails> PrivilegeDetails { get; set; }
    }
}
