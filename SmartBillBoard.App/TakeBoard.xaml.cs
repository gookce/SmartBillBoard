using SmartBillBoard.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SmartBillBoard.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TakeBoard : Page
    {
        private ConnectToAzureService azure = new ConnectToAzureService();

        public TakeBoard()
        {
            this.InitializeComponent();
            tbLocationName.Text = "Ayazağa Köyü";
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

        private async void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (AppDataManager.GetString("UserName") != null)
                await azure.AddSale(AppDataManager.GetString("UserName"),AppDataManager.GetString("BoardFromSale"),dpFirstDay.Date.ToString(),dpLastDay.Date.ToString(),price);
            else
                await azure.AddSale("Gökçe Demir", "Ayazağa Köyü", dpFirstDay.Date.ToString(), dpLastDay.Date.ToString(), price);

            Frame.Navigate(typeof(AddBanner));
        }
    }
}
