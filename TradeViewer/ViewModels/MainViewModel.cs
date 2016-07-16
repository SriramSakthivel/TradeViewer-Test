using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TradeViewer.Core;
using TradeViewer.Core.Data;

namespace TradeViewer.ViewModels
{
    public class MainViewModel
    {
        private readonly IPriceSource priceSource;
        public MainViewModel(IPriceSource priceSource)
        {
            this.priceSource = priceSource;

            Trades = new ObservableCollection<Trade>();
            Trades.CollectionChanged += Trades_CollectionChanged;
        }

        public ObservableCollection<Trade> Trades { get; set; }

        public void Initialize()
        {
            var trades = TradeRepository.GetStaticTrades();
            foreach (var trade in trades)
            {
                Trades.Add(trade);
            }

            priceSource.StartPublishingAsync();
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