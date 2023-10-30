using HN.ManagementEngine.Models;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
