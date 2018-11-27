using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Mapping
{
    public class WalletMap:EntityTypeConfiguration<Wallet>
    {
        public WalletMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.CoinCount).IsRequired();
            this.Property(x => x.CoinID).IsRequired();
            this.Property(x => x.UserID).IsRequired();
        }
    }
}
