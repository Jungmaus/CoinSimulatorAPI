using CSApi.Data.Entities;
using CSApi.Models.VM.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSApi.Controllers
{
    public class WalletController : BaseController
    {

        public WalletVM Get(int walletId)
        {
            Wallet wallet = Service.Wallet.FirstOrDefault(x => x.ID == walletId);
            WalletVM model = new WalletVM() { Coin = Service.Coin.FirstOrDefault(x => x.ID == wallet.CoinID), CoinCount = wallet.CoinCount, OperationHistories = Service.OperationHistory.GetListWithQuery(x => x.WalletID == wallet.ID) };
            return model;
        }

        public List <WalletVM> GetList(int userId)
        {
            return Service.Wallet.GetListWithQuery(x => x.UserID == userId).Select(s => new WalletVM
            {
                Coin = s.Coin,
                CoinCount = s.CoinCount,
                OperationHistories = s.OperationHistories
            }).OrderBy(x => x.Coin?.Name).ToList();
        }

        public List<WalletVM> GetListBasedCoin(int userId,int coinId)
        {
            return Service.Wallet.GetListWithQuery(x => x.UserID == userId && x.CoinID == coinId).Select(s => new WalletVM
            {
                Coin = s.Coin,
                CoinCount = s.CoinCount,
                OperationHistories = s.OperationHistories
            }).OrderBy(x => x.Coin.Name).ToList();
        }

        public WalletVM Insert(Wallet wallet)
        {
            wallet = Service.Wallet.Insert(wallet);
            return new WalletVM { Coin = Service.Coin.FirstOrDefault(x => x.ID == wallet.CoinID), CoinCount = wallet.CoinCount };
        }

        public void Delete(int walletId)
        {
            Wallet wallet = Service.Wallet.FirstOrDefault(x => x.ID == walletId);
            if(wallet != null)
            {
                Coin coin = wallet.Coin;
                User user = wallet.User;
                if(wallet.CoinCount > 0)
                {
                    user.Balance = (user.Balance + (coin.Price * wallet.CoinCount));
                    Service.User.Update(user);
                }

                foreach (var history in wallet.OperationHistories.Where(x => x.IsDeleted == false))
                    Service.OperationHistory.Delete(history.ID);
                Service.Wallet.Delete(walletId);
            }
        }

    }
}
