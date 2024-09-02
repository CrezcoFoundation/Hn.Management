using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.BlobStorage
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;
        private readonly string _containerName;
        private readonly string _accountName;
        private readonly string _accountKey;

        public BlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = configuration["AzureBlobStorage:ConnectionString"];
            _containerName = configuration["AzureBlobStorage:ContainerName"];
            _accountName = configuration["AzureBlobStorage:AccountName"];
            _accountKey = configuration["AzureBlobStorage:AccountKey"];

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(_containerName))
            {
                throw new ArgumentNullException("Azure Blob Storage connection string and container name must be provided.");
            }

            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> DownloadBlobAsync(string blobName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                var blobClient = containerClient.GetBlobClient(blobName);

                if (!await blobClient.ExistsAsync())
                {
                    throw new FileNotFoundException($"Blob '{blobName}' not found in container '{_containerName}'.");
                }

                var downloadFilePath = Path.Combine(Path.GetTempPath(), blobName);
                BlobDownloadInfo download = await blobClient.DownloadAsync();

                using (FileStream fs = File.OpenWrite(downloadFilePath))
                {
                    await download.Content.CopyToAsync(fs);
                }

                return downloadFilePath;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error downloading blob '{blobName}': {ex.Message}", ex);
            }
        }

        public async Task UploadBlobAsync(Stream fileStream, string blobName)
        {
            try
            {
                if (string.IsNullOrEmpty(blobName))
                {
                    throw new ArgumentException("Blob Name cant be empty.");
                }
                 
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                var blobClient = containerClient.GetBlobClient(blobName);

                // Upload the stream to Blob Storage
                fileStream.Position = 0; // Ensure the stream is at the beginning
                await blobClient.UploadAsync(fileStream, overwrite: true);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error uploading blob '{blobName}': {ex.Message}", ex);
            }
        }

        public string GetMediaUrl(string blobName)
        {
            var sasToken = GenerateSasToken(blobName);
            return $"https://{_accountName}.blob.core.windows.net/{_containerName}/{blobName}?{sasToken}";
        }

        public string GenerateSasToken(string blobName)
        {

            var blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = _containerName,
                BlobName = blobName,
                Resource = "b",
                ExpiresOn = DateTimeOffset.UtcNow.AddYears(1) // Set expiration time as needed
            };

            blobSasBuilder.SetPermissions(BlobSasPermissions.Read); // Read permission

            var sasToken = blobSasBuilder
                           .ToSasQueryParameters(new StorageSharedKeyCredential(_accountName, _accountKey))
                           .ToString();
            return sasToken;
        }
    }
}
