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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartBillBoard.Boat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Connect();          
        }

        public async void Connect()
        {
            ConnectToAzureService aa = new ConnectToAzureService();

            await aa.AddAccount("Gökçe", 12345);
            await aa.AddAccount("Deneme", 12345);
            await aa.AddAccount("Ben", 12345);

            await aa.AddBoard("Bahçelievler");
            await aa.AddBoard("Maslak");
            await aa.AddBoard("Beşiktaş");
            await aa.AddBoard("Ataşehir");
            await aa.AddBoard("Kadıköy");
            await aa.AddBoard("Üsküdar");
            await aa.AddBoard("Ayazağa Köyü");
            await aa.AddBoard("Zincirlikuyu");
            await aa.AddBoard("Taksim");
            await aa.AddBoard("Beyoğlu");
            await aa.AddBoard("Mecidiyeköy");
            await aa.AddBoard("Sarıyer");
            await aa.AddBoard("Kabataş");
            await aa.AddBoard("Pendik");
            await aa.AddBoard("Levent");
            await aa.AddBoard("Beylikdüzü");
        }
    }
}
