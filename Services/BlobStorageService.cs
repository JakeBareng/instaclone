using Azure.Storage.Blobs;
using Azure.Identity;
using System;
using System.IO;
using System.Threading.Tasks;

public class BlobStorageService 
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _containerClient;
    private string containerName = "instacloneblobs";

    public BlobStorageService()
    {
        _blobServiceClient = new BlobServiceClient(
            new Uri("https://instaclone.blob.core.windows.net"),
            new DefaultAzureCredential());

        _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        _containerClient.CreateIfNotExists();

    }
    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        BlobClient blobClient = _containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(fileStream, true);

        return blobClient.Uri.ToString();
    }

}
