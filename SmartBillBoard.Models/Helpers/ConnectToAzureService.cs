using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBillBoard.Models.Helpers
{
    public class ConnectToAzureService
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://ingilicekelimeler.azure-mobile.net/", "PDLFhURJDlYUbUxJoYRGomYaudVSlJ34"); 
        public static IMobileServiceTable<Account> accountTableClient = MobileService.GetTable<Account>();
        public static IMobileServiceTable<Banner> bannerTableClient = MobileService.GetTable<Banner>();
        public static IMobileServiceTable<Board> boardTableClient = MobileService.GetTable<Board>();
        public static IMobileServiceTable<Sale> saleTableClient = MobileService.GetTable<Sale>();

        public static ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        public static ObservableCollection<Banner> banners = new ObservableCollection<Banner>();
        public static ObservableCollection<Board> boards = new ObservableCollection<Board>();
        public static ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

        public ConnectToAzureService()
        {
            accountTableClient = MobileService.GetTable<Account>();
            bannerTableClient = MobileService.GetTable<Banner>();
            boardTableClient = MobileService.GetTable<Board>();
        }

        public async Task<ObservableCollection<Account>> GetAccount(string user,string password)
        { 
            accounts.Clear(); 
            var result = await accountTableClient.Where(x => x.username == user && x.password==password).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    accounts.Add(item);
                }
            }

            return accounts;
        }

        public async Task<ObservableCollection<Account>> GetAccounts()
        {
            accounts.Clear();
            var result = await accountTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    accounts.Add(item);
                }
            }

            return accounts;
        }

        public async Task AddAccount(string user, string password)
        {
            var newAccount = new Account()
            {
                username = user,
                password = password
            };

            await accountTableClient.InsertAsync(newAccount);
        }

        public async Task DeleteAccount(string user,string password)
        {
            var delAccount = new Account()
            {
                username = user,
                password = password
            };

            await accountTableClient.DeleteAsync(delAccount);
        }

        public async Task UpdateAccount(string user, string password)
        {
            var alterAccount = new Account()
            {
                username = user,
                password = password
            };

            await accountTableClient.UpdateAsync(alterAccount);
        }

        public async Task<ObservableCollection<Banner>> GetBanner(string boardname)
        {
            banners.Clear();
            var result = await bannerTableClient.Where(x => x.boardname == boardname).ToEnumerableAsync();
            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    banners.Add(item);
                }
            }
            return banners;
        }

        public async Task<ObservableCollection<Banner>> GetBanners()
        {
            banners.Clear();
            var result = await bannerTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    banners.Add(item);
                }
            }

            return banners;
        }

        public async Task AddBanner(string photo,string boardname,string username)
        {
            var newBanner = new Banner()
            {
                photo = photo,
                boardname=boardname,
                username=username              
            };

            await bannerTableClient.InsertAsync(newBanner);
        }

        public async Task DeleteBanner(string photo)
        {
            var delBanner = new Banner()
            {
                photo = photo
            };

            await bannerTableClient.DeleteAsync(delBanner);
        }

        public async Task UpdateBanner(string photo, string boardname, string username)
        {
            var alterBanner = new Banner()
            {
                photo = photo,
                boardname = boardname,
                username = username
            };

            await bannerTableClient.UpdateAsync(alterBanner);
        }

        public async Task<ObservableCollection<Board>> GetBoard(string boardname)
        {
            boards.Clear();
            var result = await boardTableClient.Where(x => x.boardname == boardname).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    boards.Add(item);
                }
            }
            return boards;
        }

        public async Task<ObservableCollection<Board>> GetBoards()
        {
            boards.Clear();
            var result = await boardTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    boards.Add(item);
                }
            }
            return boards;
        }

        public async Task AddBoard(string boardname) //Only I can add board 
        {
            var newBoard = new Board()
            {
                boardname = boardname,
                price = 100 //for only one day
            };

            await boardTableClient.InsertAsync(newBoard);
        }

        public async Task DeleteBoard(string boardname)
        {
            boards.Clear();
            var delBoard = new Board()
            {
                boardname = boardname
            };

            await boardTableClient.DeleteAsync(delBoard);
        }

        public async Task DeleteBoards()
        {
            boards.Clear();
            boards = await GetBoards();

            foreach (var item in boards)
            {
                await boardTableClient.DeleteAsync(item);
            }
        }

        public async Task UpdateBoard(string boardname,int price)
        {
            var alterBoard = new Board()
            {
                boardname = boardname,
                price=price
            };

            await boardTableClient.UpdateAsync(alterBoard);
        }

        public async Task<ObservableCollection<Sale>> GetSale(string username)
        {
            sales.Clear();
            var result = await saleTableClient.Where(x => x.username == username).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    sales.Add(item);
                }
            }

            return sales;
        }

        public async Task<ObservableCollection<Sale>> GetSales()
        {
            sales.Clear();
            var result = await saleTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    sales.Add(item);
                }
            }

            return sales;
        }

        public async Task AddSale(string username,string boardname,string firstDay,string lastDay,int price)
        {
            var newSale = new Sale()
            {
                username = username,
                boardname = boardname,
                firstdayforsale=firstDay,
                lastdayforsale = lastDay,
                price = price
            };

            await saleTableClient.InsertAsync(newSale);
        }

        public async Task DeleteSale(string username, string boardname, string firstDay, string lastDay, int price)
        {
            var delSale = new Sale()
            {
                username = username,
                boardname = boardname,
                firstdayforsale = firstDay,
                lastdayforsale = lastDay,
                price = price
            };

            await saleTableClient.DeleteAsync(delSale);
        }

        public async Task UpdateSale(string username, string boardname, string firstDay, string lastDay, int price)
        {
            var alterSale = new Sale()
            {
                username = username,
                boardname = boardname,
                firstdayforsale = firstDay,
                lastdayforsale = lastDay,
                price = price
            };

            await saleTableClient.UpdateAsync(alterSale);
        }
    }
}
