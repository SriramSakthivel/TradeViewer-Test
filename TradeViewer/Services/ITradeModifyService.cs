using TradeViewer.ViewModels;

namespace TradeViewer.Services
{
    public interface ITradeModifyService
    {
        bool? AddNewTrade(AddTradeViewModel viewModel);
    }
}