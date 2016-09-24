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

        private void cbRememberMe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(History));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddBanner));
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Sale));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnHamburgerMenu_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}
