namespace TradeViewer.Core
{
    public interface IPriceSubscriber
    {
        void PriceUpdated(decimal price);
    }
}