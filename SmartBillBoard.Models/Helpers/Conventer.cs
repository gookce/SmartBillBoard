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

namespace SmartBillBoard.Models.Helpers
{
    public class Conventer
    {
        public static string BytesToString(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public static BitmapImage StringToBitmapImage(string photoString)
        {
            BitmapImage bitmapImage = new BitmapImage();
            byte[] imageBytes = Convert.FromBase64String(photoString);
            //IRandomAccessStream stream = await;
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            //bitmapImage.SetSource(stream);
            return bitmapImage;
        }
    }
}
