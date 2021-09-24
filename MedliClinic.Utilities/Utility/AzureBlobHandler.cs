using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Http;

namespace MedliClinic.Utilities.Utility
{
    public static class AzureBlobHandler
    {
        public async static Task<string> UploadBase64(string path)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfigurations.AZURE_STORAGE_CONNECTION_STRING);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(AzureConfigurations.AZURE_BLOB_CONTAINER);
                await cloudBlobContainer.CreateIfNotExistsAsync();
                string postedFileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + ".jpg";
                //var strImage = Regex.Replace(path, @"/^data:image\/[a-z]+;base64,/", "");
                string strImage = path.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "").Replace("data:image/gif;base64,", "").Replace("data:image/bmp;base64,", "");
                var bytes = Convert.FromBase64String(strImage);
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(postedFileName);
                using (var stream = new MemoryStream(bytes))
                {
                    await cloudBlockBlob.UploadFromStreamAsync(stream);
                }
                return cloudBlockBlob.SnapshotQualifiedUri.OriginalString;
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }
        public async static Task<string> Upload(IFormFile file)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfigurations.AZURE_STORAGE_CONNECTION_STRING);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(AzureConfigurations.AZURE_BLOB_CONTAINER);
            await cloudBlobContainer.CreateIfNotExistsAsync();
            string postedFileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + file.FileName;
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(postedFileName);
            await cloudBlockBlob.UploadFromStreamAsync(file.OpenReadStream());
            return cloudBlockBlob.SnapshotQualifiedUri.OriginalString;
        }
        public async static Task<string> UploadAttachments(IFormFile file)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfigurations.AZURE_STORAGE_CONNECTION_STRING);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(AzureConfigurations.AZURE_BLOB_CONTAINER);
                await cloudBlobContainer.CreateIfNotExistsAsync();
                string postedFileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + file.FileName;
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(postedFileName);
                await cloudBlockBlob.UploadFromStreamAsync(file.OpenReadStream());
                return cloudBlockBlob.SnapshotQualifiedUri.OriginalString;

                
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
