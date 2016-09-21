using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Drawing;

namespace SmartBillBoard.Models.Helpers
{
    public class ConnectToAzureStorage
    {
        public static StorageCredentials credentials = new StorageCredentials("smarterbillboard", "79cdihcryMvvK7WvKc3+/btewgk+wsq+d939LCcVcBJ1XHBb7naJBS/vUzcOD2wZZ+Hxb5ldkBlR7TnD9obclg==");
        public static CloudStorageAccount account = new CloudStorageAccount(credentials, true);
        public static CloudBlobClient blobClient = account.CreateCloudBlobClient();
        public static CloudBlobContainer container = blobClient.GetContainerReference("MyBannerContainer");

        public ConnectToAzureStorage()
        {
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        public void UploadToBlob(string photoPath)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("MyBanners");

            Task.Run(() =>
            {
                using (var fileStream = System.IO.File.OpenRead(photoPath))
                {
                    blockBlob.UploadFromStreamAsync(fileStream);
                }
            });
        }

        public void DownloadPhoto(Image photo,string photoPath)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("MyBanners");

            using (var fileStream = System.IO.File.OpenWrite(photoPath))
            {
                blockBlob.DownloadToStreamAsync(fileStream);
            }
        }

        public void DeletePhoto(Image photo)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("MyBanners");
            blockBlob.DeleteAsync();
        }

        public async Task ListBlobsSegmentedInFlatListing(CloudBlobContainer container)
        {
            int i = 0;
            Uri photoUri;
            BlobContinuationToken continuationToken = null;
            BlobResultSegment resultSegment = null;

            do
            {
                resultSegment = await container.ListBlobsSegmentedAsync("", true, BlobListingDetails.All, 10, continuationToken, null, null);
                if (resultSegment.Results.Count<IListBlobItem>() > 0)
                {
                    ++i;
                }

                foreach (var blobItem in resultSegment.Results)
                {
                    photoUri = blobItem.StorageUri.PrimaryUri;
                }

                continuationToken = resultSegment.ContinuationToken;
            }
            while (continuationToken != null);
        }

        public void AppendFromBlob()
        {
            CloudAppendBlob appendBlob = container.GetAppendBlobReference("append-blob.log");
            appendBlob.CreateOrReplaceAsync();

            int numBlocks = 10;
            Random rnd = new Random();
            byte[] bytes = new byte[numBlocks];
            rnd.NextBytes(bytes);

            for (int i = 0; i < numBlocks; i++)
            {
                appendBlob.AppendTextAsync(String.Format("Timestamp: {0:u} \tLog Entry: {1}{2}",
                    DateTime.UtcNow, bytes[i], Environment.NewLine));
            }

            appendBlob.DownloadTextAsync();
        }

    }
}
