using SmartBillBoard.Models;
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
    public sealed partial class Sale : Page
    {
        private ConnectToAzureService azure = new ConnectToAzureService();
        private ObservableCollection<Board> board = null;

        public Sale()
        {
            this.InitializeComponent();
            Loaded += Sale_Loaded;
        }

        private void Sale_Loaded(object sender, RoutedEventArgs e)
        {
            SetBoardsToList();
        }

        public async void SetBoardsToList()
        {
            board = await azure.GetBoards();
            listData.ItemsSource = board;
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

        private void btnTake_Click(object sender, RoutedEventArgs e)
        {
            if(AppDataManager.GetString("BoardFromSale") != null)
                Frame.Navigate(typeof(TakeBoard), AppDataManager.GetString("BoardFromSale"));
            else
                Frame.Navigate(typeof(TakeBoard),"Ayazağa Köyü");
        }

        private void listData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(var selectedvalue in board)
            {
                if (selectedvalue == listData.SelectedItem)
                    AppDataManager.SaveString("BoardFromSale", selectedvalue.boardname);               
            }
        }
    }
}
