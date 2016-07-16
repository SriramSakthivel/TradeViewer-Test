using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TradeViewer.Commands;
using TradeViewer.Core;
using TradeViewer.Core.Data;
using TradeViewer.Services;

namespace TradeViewer.ViewModels
{
    public class MainViewModel
    {
        private readonly IPriceSource priceSource;
        private readonly ITradeModifyService tradeModifyService;
        public MainViewModel(IPriceSource priceSource, ITradeModifyService tradeModifyService)
        {
            this.priceSource = priceSource;
            this.tradeModifyService = tradeModifyService;

            AddTradeCommand = new RelayCommand<object>(AddNewTrade);
            Trades = new ObservableCollection<Trade>();
            Trades.CollectionChanged += Trades_CollectionChanged;
        }

        public ObservableCollection<Trade> Trades { get; private set; }
        public RelayCommand<object> AddTradeCommand { get; private set; }

        public void Initialize()
        {
            var trades = TradeRepository.GetStaticTrades();
            foreach (var trade in trades)
            {
                Trades.Add(trade);
            }

            priceSource.StartPublishingAsync();
        }
        private void AddNewTrade(object _)
        {
            var viewModel = new AddTradeViewModel(new Trade());
            bool? result = tradeModifyService.AddNewTrade(viewModel);
            if (result ?? false)
            {
                Trades.Add(viewModel.Trade);
            }
        }

        void Trades_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
            {
                foreach (Trade trade in e.NewItems)
                {
                    priceSource.Subscribe(trade);
                }
            }
        }
    }
}