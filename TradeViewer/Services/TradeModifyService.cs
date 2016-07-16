using System.Windows;
using TradeViewer.ViewModels;
using TradeViewer.Views;

namespace TradeViewer.Services
{
    public class TradeModifyService : ITradeModifyService
    {
        public bool? AddNewTrade(AddTradeViewModel viewModel)
        {
            AddNewTradeView window = new AddNewTradeView
            {
                Owner = Application.Current.MainWindow,
                DataContext = viewModel
            };
            return window.ShowDialog();
        }
    }
}