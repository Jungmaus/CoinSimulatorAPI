using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Mapping
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.Username).HasMaxLength(15).IsRequired();
            this.Property(x => x.Password).HasMaxLength(15).IsRequired();
            this.Property(x => x.Name).HasMaxLength(15);
            this.Property(x => x.Surname).HasMaxLength(15);
            this.Property(x => x.Email).HasMaxLength(50);
        }
    }
}
