using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Mapping
{
    public class CoinMap:EntityTypeConfiguration<Coin>
    {
        public CoinMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.Name).HasMaxLength(20).IsRequired();
            this.Property(x => x.PicturePath).IsRequired();

            this.HasIndex(x => x.ID);
        }
    }
}
