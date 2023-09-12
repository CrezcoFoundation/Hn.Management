using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IEmailService
	{
        Task<string> ContactMe(ContactRequest contactRequest);
        Task<string> SendNewsletterProgram(string email);
    }
}

