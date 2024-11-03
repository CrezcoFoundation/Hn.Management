using AutoMapper;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;
using User = HN.ManagementEngine.Models;
namespace HN.Management.Web.Resolvers
{
    public class ImageUrlResolver : IValueResolver<User.User, UserResponse, string>
    {
        private readonly IBlobStorageService _blobStorageService;

        public ImageUrlResolver(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        public string Resolve(User.User source, UserResponse destination, string destMember, ResolutionContext context)
        {
            // You can make this method asynchronous if needed, but AutoMapper resolves synchronously
            return _blobStorageService.GetMediaUrl(source.BlobName);
        }
    }
}
