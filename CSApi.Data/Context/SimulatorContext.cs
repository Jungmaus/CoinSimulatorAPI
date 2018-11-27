using CSApi.Data.Entities;
using CSApi.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Context
{
    public class SimulatorContext : DbContext
    {
        public SimulatorContext() { Database.Connection.ConnectionString = @"Data Source=DESKTOP-CE1GVBQ\SQLEXPRESS;Initial Catalog=SimulatorDB;Integrated Security=True"; }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<OperationHistory> OperationHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CoinMap());
            modelBuilder.Configurations.Add(new OperationHistoryMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new WalletMap());
        }

    }
}
