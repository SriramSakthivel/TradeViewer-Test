using System.Collections.Generic;

namespace TradeViewer.Core.Data
{
    public static class TradeRepository
    {
        public static IEnumerable<Trade> GetStaticTrades()
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