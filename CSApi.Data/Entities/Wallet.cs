using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Entities
{
    public class Wallet:BaseEntity
    {
        public Wallet()
        {
            this.OperationHistories = new List<OperationHistory>();
        }

        public decimal CoinCount { get; set; }


        public int CoinID { get; set; }
        public int UserID { get; set; }

        [ForeignKey("CoinID")]
        public virtual Coin Coin { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual List<OperationHistory> OperationHistories { get; set; }
    }
}
