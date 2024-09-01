using System.IO;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> DownloadBlobAsync(string blobName);
        Task UploadBlobAsync(Stream fileStream, string blobName);
        string GenerateSasToken(string blobName);
        string GetMediaUrl(string blobName);
    }
}
