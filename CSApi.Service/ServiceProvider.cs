using CSApi.Service.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Service
{
    public class ServiceProvider : IDisposable
    {
        private CoinService _coin;
        private OperationHistoryService _operationHistory;
        private UserService _user;
        private WalletService _wallet;


        public CoinService Coin { get { return _coin ?? new CoinService(); } }
        public OperationHistoryService OperationHistory { get { return _operationHistory ?? new OperationHistoryService(); } }
        public UserService User { get { return _user ?? new UserService(); } }
        public WalletService Wallet { get { return _wallet ?? new WalletService(); } }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
