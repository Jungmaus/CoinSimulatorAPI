using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Data.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Wallets = new List<Wallet>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? LastLogin { get; set; }
        public decimal? Balance { get; set; }

        public virtual List<Wallet> Wallets { get; set; }
    }
}
