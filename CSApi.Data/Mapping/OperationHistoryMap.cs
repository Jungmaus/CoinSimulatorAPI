using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Mapping
{
    public class OperationHistoryMap:EntityTypeConfiguration<OperationHistory>
    {
        public OperationHistoryMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.CoinCount).IsRequired();
            this.Property(x => x.CoinPrice).IsRequired();
            this.Property(x => x.OperationType).IsRequired();
            this.Property(x => x.TotalPrice).IsRequired();
            this.Property(x => x.WalletID).IsRequired();

            this.HasIndex(x => x.WalletID);
        }
    }
}
