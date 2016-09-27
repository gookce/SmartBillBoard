using SmartBillBoard.Models.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SmartBillBoard.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddBanner : Page
    {
        ConnectToAzureService azure = new ConnectToAzureService();
        StorageFile pickedImage = null;

        public AddBanner()
        {
            this.InitializeComponent();
            Loaded += AddBanner_Loaded;
        }

        private void AddBanner_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppDataManager.GetString("BoardFromSale") == null)
                Frame.Navigate(typeof(Sale));
            else if (AppDataManager.GetString("UserName") == null)
                Frame.Navigate(typeof(MainPage));
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

        private void btnHamburgerMenu_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Sale));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddBanner));
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(History));
        }

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker imagePicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                FileTypeFilter = { ".jpg", ".png", ".bmp", ".gif", ".tif" }
            };

            pickedImage = await imagePicker.PickSingleFileAsync();
            imageFromSelect.Source = await StorageFileToBitmapImage(pickedImage);
        }

        private static async Task<BitmapImage> StorageFileToBitmapImage(StorageFile file)
        {
            var stream = await file.OpenAsync(FileAccessMode.Read);
            var bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(stream);

            return bitmapImage;
        }

        private async void btnAddBoard_Click(object sender, RoutedEventArgs e)
        {
            if (pickedImage != null)
            {
                byte[] photoBytes = await BitmapImageToByteArray(pickedImage);
                string photoString = ByteArrayToString(photoBytes);
                await azure.AddBanner(photoString, AppDataManager.GetString("UserName"), AppDataManager.GetString("BoardFromSale"));
            }
        }
    }
}
