using PropertyChanged;

namespace TradeViewer.Core
{
    [ImplementPropertyChanged]
    public class Trade : IPriceSubscriber
    {
        public string Security { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public Trend PriceTrend { get; set; }

        public void PriceUpdated(decimal price)
        {
            decimal previousPrice = this.Price;
            this.Price = price;

            if (price > previousPrice)
            {
                PriceTrend = Trend.Up;
            }
            else if (price < previousPrice)
            {
                PriceTrend = Trend.Down;
            }
            else
            {
                PriceTrend = Trend.None;
            }
        }
    }
}