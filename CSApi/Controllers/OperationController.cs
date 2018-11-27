using CSApi.Data.Entities;
using CSApi.Models.Types;
using CSApi.Models.VM.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSApi.Controllers
{
    public class OperationController : BaseController
    {

        public int BuyCoin(BuySellCoinVM model)
        {
            User user = Service.User.FirstOrDefault(x => x.ID == model.userId);
            Coin coin = Service.Coin.FirstOrDefault(x => x.ID == model.coinId);
            Wallet wallet = Service.Wallet.FirstOrDefault(x => x.ID == model.walletId && x.CoinID == model.coinId);
            if (user != null && coin != null && wallet != null)
            {
                decimal amount = (coin.Price * model.coinCount);
                if(amount <= user.Balance)
                {
                    user.Balance = (user.Balance - amount);
                    wallet.CoinCount = wallet.CoinCount + model.coinCount;
                    Service.User.Update(user);
                    Service.Wallet.Update(wallet);
                    Service.OperationHistory.Insert(new OperationHistory { CoinCount = model.coinCount, CoinPrice = coin.Price, OperationType = (int)EnumOperationType.Buy, WalletID = wallet.ID, TotalPrice = amount });
                    return 1;
                }
                else
                    return 0;
            }
            else
                return 0;
        }

        public int SellCoin(BuySellCoinVM model)
        {
            User user = Service.User.FirstOrDefault(x => x.ID == model.userId);
            Coin coin = Service.Coin.FirstOrDefault(x => x.ID == model.coinId);
            Wallet wallet = Service.Wallet.FirstOrDefault(x => x.ID == model.walletId && x.CoinID == model.coinId);
            if (user != null && coin != null && wallet != null)
            {
                if (wallet.CoinCount >= model.coinCount)
                {
                    decimal amount = (coin.Price * model.coinCount);
                    user.Balance = (user.Balance + amount);                    
                    wallet.CoinCount = wallet.CoinCount - model.coinCount;
                    Service.User.Update(user);  
                    Service.Wallet.Update(wallet);
                    Service.OperationHistory.Insert(new OperationHistory { CoinCount = model.coinCount, CoinPrice = coin.Price, OperationType = (int)EnumOperationType.Sell, WalletID = wallet.ID, TotalPrice = amount });
                    return 1;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
