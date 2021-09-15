using HN.ManagementEngine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
    }
}
