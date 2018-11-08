using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;

namespace CurrencyTrader.AdoNet
{
    public class AsynchTradeStorage : ITradeStorage
    {
        AdoNetTradeStorage synchTradeStorage;
        public AsynchTradeStorage(ILogger logger)
        {
            synchTradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            Task.Run(() => synchTradeStorage.Persist(trades));
        }
    }
}
