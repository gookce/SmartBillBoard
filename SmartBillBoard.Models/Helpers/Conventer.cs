using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Data.Linq;
using System.Drawing;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.Storage;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SmartBillBoard.Models.Helpers
{
    public static class Conventer
    {
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static async Task<byte[]> StorageFileToByteArray(StorageFile file)
        {
            IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read);
            var reader = new DataReader(fileStream.GetInputStreamAt(0));
            await reader.LoadAsync((uint)fileStream.Size);
            byte[] pixels = new byte[fileStream.Size];
            reader.ReadBytes(pixels);
            return pixels;
        }

        public static BitmapImage AsBitmapImage(byte[] byteArray)
        {

            if (byteArray != null)
            {
                using (var stream = new InMemoryRandomAccessStream())
                {
                    //stream.WriteAsync(byteArray.AsBuffer()).GetResults();
                    var image = new BitmapImage();
                    stream.Seek(0);
                    image.SetSource(stream);
                    return image;
                }
            }

            return null;
        }

        public static async Task<StorageFile> ByteArrayToStorageFile(byte[] array)
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync("C:\\Users\\gookc\\Desktop\\Resim\\deneme.txt");

            //using (Stream stream = File.OpenWrite())
            //{
            //    File.WriteAllBytes("C:\\Users\\gookc\\Desktop\\Resim", array);
            //}
            //bu file a yaz 
            return file;
        }

        private static async Task<BitmapImage> StorageFileToBitmapImage(StorageFile file)
        {
            var stream = await file.OpenAsync(FileAccessMode.Read);
            var bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(stream);
            return bitmapImage;
        }
    }
}
