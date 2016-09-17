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
        public static IMobileServiceTable<Authority> authorityTableClient = MobileService.GetTable<Authority>();
        public static IMobileServiceTable<Banner> bannerTableClient = MobileService.GetTable<Banner>();
        public static IMobileServiceTable<Board> boardTableClient = MobileService.GetTable<Board>();
        public static IMobileServiceTable<SaleInfo> saleTableClient = MobileService.GetTable<SaleInfo>();

        public static ObservableCollection<object> accounts = new ObservableCollection<object>();
        public static ObservableCollection<object> banners = new ObservableCollection<object>();
        public static ObservableCollection<object> boards = new ObservableCollection<object>();
        public static ObservableCollection<object> authority = new ObservableCollection<object>();
        public static ObservableCollection<object> sales = new ObservableCollection<object>();

        public ConnectToAzureService()
        {
            accountTableClient = MobileService.GetTable<Account>();
            bannerTableClient = MobileService.GetTable<Banner>();
            boardTableClient = MobileService.GetTable<Board>();
            authorityTableClient = MobileService.GetTable<Authority>();
            saleTableClient = MobileService.GetTable<SaleInfo>();
        }

        public async Task GetAccount(string user,int password)
        { 
            accounts.Clear(); 
            var result = await accountTableClient.Where(x => x.username == user && x.password==password).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    accounts.Add(item.ToString());
                }
            }
        }

        public async Task GetAccounts()
        {
            accounts.Clear();
            var result = await accountTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    accounts.Add(item.ToString());
                }
            }
        }

        public async Task AddAccount(string user, int password)
        {
            accounts.Clear();
            var newAccount = new Account()
            {
                username = user,
                password = password
            };

            await accountTableClient.InsertAsync(newAccount);
            accounts.Add(newAccount);
        }

        public async Task DeleteAccount(string user)
        {
            accounts.Clear();
            var delAccount = new Account()
            {
                username = user
            };

            await accountTableClient.DeleteAsync(delAccount);
            accounts.Remove(delAccount);
        }

        public async Task UpdateAccount(string user, int password)
        {
            accounts.Clear();
            var alterAccount = new Account()
            {
                username = user,
                password = password
            };

            await accountTableClient.UpdateAsync(alterAccount);
            accounts.Add(alterAccount);
        }

        public async Task GetPermission(Account user, SaleInfo sale)
        {
            authority.Clear();
            var result = await authorityTableClient.Where(x => x.soldid == sale.id && x.accountid == user.id).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    authority.Add(item.ToString());
                }
            }
        }

        public async Task GetPermissions()
        {
            authority.Clear();
            var result = await authorityTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    authority.Add(item.ToString());
                }
            }
        }

        public async Task AddAuthority(Account user, SaleInfo sale,bool permiss)
        {
            authority.Clear();
            var newPermission = new Authority()
            {
                accountid = user.id,
                soldid = sale.id,
                permission = permiss
            };

            await authorityTableClient.InsertAsync(newPermission);
            authority.Add(newPermission);
        }

        public async Task DeleteAuthority(Account user)
        {
            authority.Clear();
            var delPermission = new Authority()
            {
                accountid = user.id
            };

            await authorityTableClient.DeleteAsync(delPermission);
            authority.Remove(delPermission);
        }

        public async Task UpdateAuthority(Account user, SaleInfo sale,bool permiss)
        {
            authority.Clear();
            var alterPermission = new Authority()
            {
                accountid = user.id,
                soldid = sale.id,
                permission=permiss
            };

            await authorityTableClient.UpdateAsync(alterPermission);
            authority.Add(alterPermission);
        }

        public async Task GetBanner(Byte[] photo, string photopath)
        {
            banners.Clear();
            var result = await bannerTableClient.Where(x => x.photo == photo && x.photopath == photopath).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    banners.Add(item.ToString());
                }
            }
        }

        public async Task GetBanners()
        {
            banners.Clear();
            var result = await bannerTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    banners.Add(item.ToString());
                }
            }
        }

        public async Task AddBanner(Byte[] photo, string photopath)
        {
            banners.Clear();
            var newBanner = new Banner()
            {
                photo = photo,
                photopath = photopath
            };

            await bannerTableClient.InsertAsync(newBanner);
            banners.Add(newBanner);
        }

        public async Task DeleteBanner(Byte[] photo)
        {
            banners.Clear();
            var delBanner = new Banner()
            {
                photo = photo
            };

            await bannerTableClient.DeleteAsync(delBanner);
            banners.Remove(delBanner);
        }

        public async Task UpdateBanner(Byte[] photo, string photopath)
        {
            banners.Clear();
            var alterBanner = new Banner()
            {
                photo = photo,
                photopath = photopath
            };

            await bannerTableClient.UpdateAsync(alterBanner);
            banners.Add(alterBanner);
        }

        public async Task GetBoard(string boardname)
        {
            boards.Clear();
            var result = await boardTableClient.Where(x => x.locationname == boardname).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    boards.Add(item.ToString());
                }
            }
        }

        public async Task GetBoards()
        {
            boards.Clear();
            var result = await boardTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    boards.Add(item.ToString());
                }
            }
        }

        public async Task AddBoard(string boardname,bool isSold)
        {
            boards.Clear();
            var newBoard = new Board()
            {
                issold = isSold,
                locationname = boardname
            };

            await boardTableClient.InsertAsync(newBoard);
            boards.Add(newBoard);
        }

        public async Task DeleteBoard(string boardname)
        {
            boards.Clear();
            var delBoard = new Board()
            {
                locationname = boardname
            };

            await boardTableClient.DeleteAsync(delBoard);
            boards.Remove(delBoard);
        }

        public async Task UpdateBoard(string boardname, bool isSold)
        {
            boards.Clear();
            var alterBoard = new Board()
            {
                issold = true,
                locationname = boardname
            };

            await boardTableClient.UpdateAsync(alterBoard);
            boards.Add(alterBoard);
        }

        public async Task GetSaleInfo(Board board,Account user)
        {
            sales.Clear();
            var result = await saleTableClient.Where(x => x.boardid == board.id  && x.accountid == user.id).ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    sales.Add(item.ToString());
                }
            }
        }

        public async Task GetSales()
        {
            sales.Clear();
            var result = await saleTableClient.ToEnumerableAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    sales.Add(item.ToString());
                }
            }
        }

        public async Task AddSaleInfo(Board board, Account user,int whichday,string firstday,string lastday)
        {
            sales.Clear();
            var newSale = new SaleInfo()
            {
                boardid = board.id,
                accountid = user.id,
                howmanydayissold = whichday,
                soldfirstday = firstday,
                soldlastday= lastday
            };

            await saleTableClient.InsertAsync(newSale);
            sales.Add(newSale);
        }

        public async Task DeleteSaleInfo(Board board)
        {
            sales.Clear();
            var delSale = new SaleInfo()
            {
                boardid = board.id
            };

            await saleTableClient.DeleteAsync(delSale);
            sales.Remove(delSale);
        }

        public async Task UpdateSaleInfo(Board board, Account user, int whichday, string firstday, string lastday)
        {
            sales.Clear();
            var alterSale = new SaleInfo()
            {
                boardid = board.id,
                accountid = user.id,
                howmanydayissold = whichday,
                soldfirstday = firstday,
                soldlastday = lastday
            };

            await saleTableClient.UpdateAsync(alterSale);
            sales.Add(alterSale);
        }
    }
}
