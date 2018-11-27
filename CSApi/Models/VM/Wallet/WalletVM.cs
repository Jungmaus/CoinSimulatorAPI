using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSApi.Models.VM.Wallet
{
    public class WalletVM
    {
        public Coin Coin { get; set; }
        public List<OperationHistory> OperationHistories { get; set; }
        public decimal CoinCount { get; set; }
    }
}