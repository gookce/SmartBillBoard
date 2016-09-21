using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using System.Text;
using SmartBillBoard.Models.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartBillBoard.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ConnectToAzureService azure = new ConnectToAzureService();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker imagePicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                FileTypeFilter = { ".jpg", ".png", ".bmp", ".gif", ".tif" }
            };

            StorageFile pickedImage = await imagePicker.PickSingleFileAsync();

            if (pickedImage != null)
            {
                //IRandomAccessStream displayStream = await pickedImage.OpenAsync(FileAccessMode.Read);
                //BitmapImage bitmapImage = new BitmapImage();
                //bitmapImage.SetSource(displayStream);

                byte[] photoBytes = await BitmapImageToByteArray(pickedImage);
                string photoString = ByteArrayToString(photoBytes);
                await azure.AddBanner(photoString, pickedImage.Path);
            }
        }

        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public async Task<byte[]> BitmapImageToByteArray(StorageFile file)
        {
            Stream stream = await file.OpenStreamForReadAsync();
            byte[] byteArray = new byte[(int)stream.Length];
            await stream.ReadAsync(byteArray, 0, (int)stream.Length);
            return byteArray;
        }
    }
}
