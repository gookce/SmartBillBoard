using SmartBillBoard.Models.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SmartBillBoard.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddBanner : Page
    {
        public AddBanner()
        {
            this.InitializeComponent();
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
                byte[] photoBytes = await BitmapImageToByteArray(pickedImage);
                string photoString = ByteArrayToString(photoBytes);
                AppDataManager.SaveString("Photo", photoString);
                //await azure.AddBanner(photoString);
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
    }
}
