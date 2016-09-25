using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SmartBillBoard.Models.Helpers;
using SmartBillBoard.Models;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Text;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartBillBoard.Boat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ConnectToAzureService azure = new ConnectToAzureService();

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
                byte[] photoBytes = await BitmapImageToByteArray(pickedImage);
                string photoString = ByteArrayToString(photoBytes);
                await azure.AddBanner(photoString, "Maslak", "Gökçe Demir");
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

        public async void Connect()
        {
            ConnectToAzureService aa = new ConnectToAzureService();

            await aa.AddAccount("Gökçe Demir", 12345);
            await aa.AddAccount("Deneme", 12345);
            await aa.AddAccount("Ben", 12345);

            await aa.AddBoard("Bahçelievler");
            await aa.AddBoard("Maslak");
            await aa.AddBoard("Beşiktaş");
            await aa.AddBoard("Kadıköy");
            await aa.AddBoard("Üsküdar");
            await aa.AddBoard("Ayazağa Köyü");
            await aa.AddBoard("Taksim");
            await aa.AddBoard("Beyoğlu");
            await aa.AddBoard("Mecidiyeköy");
            await aa.AddBoard("Sarıyer");
            await aa.AddBoard("Kabataş");
            await aa.AddBoard("Levent");
            await aa.AddBoard("Beylikdüzü");
        }
    }
}
