using System.Collections.Generic;

namespace TradeViewer.Core.Data
{
    public interface ITradeRepository
    {
        IEnumerable<Trade> GetAllTrades();
    }
}