using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IDataInitializerService
    {
        Task SeedDatabase();
    }
}
