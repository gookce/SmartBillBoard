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
using SmartBillBoard.Models;
using System.Collections.ObjectModel;

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
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if(AppDataManager.GetString("UserName")!=null)
            {
                txtName.Text = AppDataManager.GetString("UserName");
                txtPassword.Password= AppDataManager.GetString("UserPassword");
                cbRememberMe.IsChecked = true;
                btnSignUp.IsEnabled = false;
            }
            else
            {
                cbRememberMe.IsChecked = false;
                btnSignUp.IsEnabled = true;
            }
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if(AppDataManager.GetString("SaleInfo")!=null)
            {
                Frame.Navigate(typeof(AddBanner));
            }
            else
            {
                Frame.Navigate(typeof(Sale));
            }            
        }

        private async void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            await azure.AddAccount(txtName.Text,txtPassword.Password);

            if(cbRememberMe.IsChecked== true)
            {
                AppDataManager.SaveString("UserName", txtName.Text);
                AppDataManager.SaveString("UserPassword", txtPassword.Password);
            }

            if (AppDataManager.GetString("SaleInfo") != null)
            {
                Frame.Navigate(typeof(AddBanner));
            }
            else
            {
                Frame.Navigate(typeof(Sale));
            }
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
