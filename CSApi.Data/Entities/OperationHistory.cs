using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Entities
{
    public class OperationHistory : BaseEntity
    {
        public int OperationType { get; set; }

        public decimal CoinCount { get; set; }
        public decimal CoinPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public int WalletID { get; set; }

        [ForeignKey("WalletID")]
        public virtual Wallet Wallet { get; set; }
    }
}
