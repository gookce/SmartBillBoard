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
using SmartBillBoard.Models;
using SmartBillBoard.Models.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartBillBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ConnectToAzureService azure=new ConnectToAzureService();

        // I am a Bill Board in Ayazağa Köyü
        public Board Ayazaga = new Board(){ locationname="Ayazağa Köyü", issold=true };

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //await azure.GetSaleInfo(Ayazaga);

            if(Ayazaga.issold)
            {
                Task.Run(() =>
                {
                    azure.GetBanner(@"C:\Users\gookc\Pictures\Camera Roll\res1.jpg");                    
                });
            }
            
           // myBanner.Source=   
        }
    }
}
