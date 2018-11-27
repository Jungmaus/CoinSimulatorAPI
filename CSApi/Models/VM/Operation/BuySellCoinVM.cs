using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSApi.Models.VM.Operation
{
    public class BuySellCoinVM
    {
        public int userId { get; set; }
        public int coinId { get; set; }
        public int walletId { get; set; }
        public decimal coinCount { get; set; }
    }
}