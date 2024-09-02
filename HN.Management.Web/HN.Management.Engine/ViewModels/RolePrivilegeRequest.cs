using System.Collections.Generic;

namespace HN.Management.Engine.ViewModels
{
    public class RolePrivilegeRequest
    {
        public string RoleId { get; set; }
        public List<string> PrivilegesIds { get; set; }
    }
}
