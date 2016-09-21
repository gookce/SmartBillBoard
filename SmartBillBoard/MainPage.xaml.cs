using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SmartBillBoard.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using SmartBillBoard.Models.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartBillBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ConnectToAzureService azure=new ConnectToAzureService();
        private ObservableCollection<Banner> banner;
        private BitmapImage image = null;
        private Board Ayazaga = new Board(){ locationname="Ayazağa Köyü", issold=true };
        private Byte[] photoArray = null;

        public MainPage()
        {
            this.InitializeComponent();
            // I am a Bill Board in Ayazağa Köyü
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //await azure.GetSaleInfo(Ayazaga);

            if (Ayazaga.issold)
            {
                banner = await azure.GetBanner(@"C:\Users\gookc\Pictures\Camera Roll\res4.jpg");              
                photoArray = StringToByteArray(banner[0].photo);
                image = await ByteArrayToBitmapImage(photoArray);
                myBanner.Source = image;
            }   
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public async Task<BitmapImage> ByteArrayToBitmapImage(byte[] array)
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(array);
                    await writer.StoreAsync();
                }

                BitmapImage image = new BitmapImage();
                await image.SetSourceAsync(stream);
                return image;
            }
        }

    }
}
