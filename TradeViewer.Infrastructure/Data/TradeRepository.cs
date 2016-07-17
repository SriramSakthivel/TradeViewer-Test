using System.Collections.Generic;
using TradeViewer.Core;
using TradeViewer.Core.Data;

namespace TradeViewer.Infrastructure.Data
{
    public class TradeRepository : ITradeRepository
    {
        public IEnumerable<Trade> GetAllTrades()
        {
            yield return new Trade()
            {
                Security = "AUD",
                Quantity = 15
            };
            yield return new Trade()
            {
                Security = "JPY",
                Quantity = 20

            };
            yield return new Trade()
            {
                Security = "CHF",
                Quantity = 12
            };
            yield return new Trade()
            {
                Security = "CAD",
                Quantity = 6
            };
        }
    }
}