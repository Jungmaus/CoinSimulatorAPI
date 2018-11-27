using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Entities
{
    public class Coin:BaseEntity
    {
        public Coin()
        {
            this.Wallets = new List<Wallet>();
        }

        public string Name { get; set; }
        public string PicturePath { get; set; }
        public decimal Price { get; set; }
        public int ChangeType { get; set; }
        public decimal Change { get; set; }

        public virtual List<Wallet> Wallets { get; set; }
    }
}
