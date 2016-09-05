using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage; 
using Microsoft.WindowsAzure.Storage.Blob;

namespace SmartBillBoard.Models
{
    public class ConnectToAzure
    {
        public static StorageCredentials credentials = new StorageCredentials("smarterbillboard", "Mvl+ScH9K7ffepy98v0TT3FSmh+gEwFJMWQFjHcucr+aTH8SZy4xixxlydlLfcpBHXkx6aSW0CSJLtXVlcGNPg==");
        public static CloudStorageAccount account = new CloudStorageAccount(credentials, true);
        public static CloudBlobClient blobClient = account.CreateCloudBlobClient();
        public static CloudBlobContainer container = blobClient.GetContainerReference("MyBannerContainer");

        public ConnectToAzure()
        {
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        public static void UploadToBlob(string photoPath)
        {
            //photoPath = @"path\myfile"
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("MyBanners");

            using (var fileStream = System.IO.File.OpenRead(photoPath))
            {
                blockBlob.UploadFromStreamAsync(fileStream);
            }
        }

        public static void DownloadPhoto(string photo,string photoPath)
        {
            //photo="photo1.jpg"
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(photo);

            using (var fileStream = System.IO.File.OpenWrite(photoPath))
            {
                blockBlob.DownloadToStreamAsync(fileStream);
            }
        }

        public static void DeletePhoto(string photo)
        {
            //photo="photo1.jpg"
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(photo);

            blockBlob.DeleteAsync();
        }

        async public static Task ListBlobsSegmentedInFlatListing(CloudBlobContainer container)
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

        public static void AppendFromBlob()
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
